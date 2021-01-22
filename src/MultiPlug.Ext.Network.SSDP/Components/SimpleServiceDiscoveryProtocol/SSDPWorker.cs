using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

using MultiPlug.Base.Exchange;
using MultiPlug.Ext.Network.SSDP.Models.Components;


namespace MultiPlug.Ext.Network.SSDP.Components.SimpleServiceDiscoveryProtocol
{
    internal class SSDPWorker : EventConsumer
    {
        private readonly List<UdpClient> m_UdpClients = new List<UdpClient>();
        internal const int c_DiscoveryPort = 1900;

        private SSDPProperties m_Properties;

        internal event Action<string, Device> DeviceDiscovered;

        internal SSDPWorker(SSDPProperties theProperties)
        {
            m_Properties = theProperties;

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    var UdpClient = new UdpClient();

                    UdpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                    UdpClient.Client.Bind(new IPEndPoint(ip, 0));

                    var ReceiveHandler = new SSDPReceive(UdpClient, ip);

                    ReceiveHandler.DeviceDiscovered += OnDeviceDiscovered;

                    try
                    {
                        UdpClient.AllowNatTraversal(true);
                    }
                    catch (SocketException)
                    {
                    }

                    m_UdpClients.Add(UdpClient);

                    ReceiveHandler.BeginReceive();
                }
            }
        }

        private void OnDeviceDiscovered(string theUrl, Device theDevice)
        {
            DeviceDiscovered?.Invoke(theUrl, theDevice);
        }

        public void Search( string theSearchTarget )
        {
            var String = new StringBuilder();

            String.Append("M-SEARCH * HTTP/1.1\r\nHOST: 239.255.255.250:1900\r\nST: ");
            String.Append(theSearchTarget);
            String.Append("\r\nMAN: \"ssdp:discover\"\r\nUSER-AGENT: MultiPlugExtNetworkSSDP MultiPlugExtNetworkSSDP/1.0.0.0 Windows\r\nMX: 3\r\n\r\n");

            var probe = Encoding.ASCII.GetBytes(String.ToString());

            m_UdpClients.ForEach(c => c.Send(probe, probe.Length, new IPEndPoint(IPAddress.Parse("239.255.255.250"), c_DiscoveryPort)));
        }

        public override void OnEvent(Payload thePayload)
        {
            Search(m_Properties.DiscoveryTarget);
        }
    }
}
