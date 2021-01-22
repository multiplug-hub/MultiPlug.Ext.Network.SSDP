using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MultiPlug.Ext.Network.SSDP.Models.Components;

namespace MultiPlug.Ext.Network.SSDP.Components.SimpleServiceDiscoveryProtocol
{
    public class SSDPReceive
    {
        private IPAddress m_IpAddress;
        private UdpClient m_UdpClient;

        internal event Action<string, Device> DeviceDiscovered;

        public SSDPReceive(UdpClient theUdpClient, IPAddress theIPAddress)
        {
            m_UdpClient = theUdpClient;
            m_IpAddress = theIPAddress;
        }

        public void BeginReceive()
        {
            m_UdpClient.BeginReceive(Response, null);
        }

        private void Response(IAsyncResult ar)
        {
            var remote = new IPEndPoint(m_IpAddress, 0);
            var bytes = m_UdpClient.EndReceive(ar, ref remote);

            var payload = Encoding.UTF8.GetString(bytes);

            string[] Lines = payload.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);


            int index = Array.FindIndex(Lines, v => v.StartsWith("ST:"));

            if (index != -1)
            {
                string SearchTarget = Lines[index].Replace("ST:", "").Trim();

                index = Array.FindIndex(Lines, v => v.StartsWith("LOCATION:"));

                if (index != -1)
                {
                    string LocationUrl = Lines[index].Replace("LOCATION:", "").Trim();

                    Task.Run(() =>
                    {
                        Lookup(LocationUrl);
                    });
                }
            }

            BeginReceive();
        }

        private void Lookup(string m_Url)
        {
            WebRequest request = WebRequest.Create(m_Url);
            using (WebResponse response = request.GetResponse())
            {
                try
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    XmlSerializer serializer = new XmlSerializer(typeof(SSDPDeviceDescription));
                    SSDPDeviceDescription deserialized = (SSDPDeviceDescription)serializer.Deserialize(reader);

                    DeviceDiscovered?.Invoke(m_Url, deserialized.Device);
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
