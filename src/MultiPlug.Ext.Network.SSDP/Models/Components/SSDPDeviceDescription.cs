using System.Xml.Serialization;

namespace MultiPlug.Ext.Network.SSDP.Models.Components
{
        [XmlRoot(ElementName = "specVersion", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public class SpecVersion
        {
            [XmlElement(ElementName = "major", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public string Major { get; set; }
            [XmlElement(ElementName = "minor", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public string Minor { get; set; }
        }

        [XmlRoot(ElementName = "service", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public class Service
        {
            [XmlElement(ElementName = "serviceType", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public string ServiceType { get; set; }
            [XmlElement(ElementName = "serviceId", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public string ServiceId { get; set; }
            [XmlElement(ElementName = "controlURL", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public string ControlURL { get; set; }
            [XmlElement(ElementName = "eventSubURL", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public string EventSubURL { get; set; }
            [XmlElement(ElementName = "SCPDURL", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public string SCPDURL { get; set; }
        }

        [XmlRoot(ElementName = "serviceList", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public class ServiceList
        {
            [XmlElement(ElementName = "service", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public Service Service { get; set; }
        }

        [XmlRoot(ElementName = "icon", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public class Icon
        {
            [XmlElement(ElementName = "mimetype", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public string Mimetype { get; set; }
            [XmlElement(ElementName = "width", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public string Width { get; set; }
            [XmlElement(ElementName = "height", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public string Height { get; set; }
            [XmlElement(ElementName = "depth", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public string Depth { get; set; }
            [XmlElement(ElementName = "url", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public string Url { get; set; }
        }

        [XmlRoot(ElementName = "iconList", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public class IconList
        {
            [XmlElement(ElementName = "icon", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public Icon Icon { get; set; }
        }

        [XmlRoot(ElementName = "device", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public class Device
        {
            [XmlElement(ElementName = "deviceType", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public string DeviceType { get; set; }
            [XmlElement(ElementName = "friendlyName", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public string FriendlyName { get; set; }
            [XmlElement(ElementName = "manufacturer", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public string Manufacturer { get; set; }
            [XmlElement(ElementName = "manufacturerURL", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public string ManufacturerURL { get; set; }
            [XmlElement(ElementName = "modelDescription", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public string ModelDescription { get; set; }
            [XmlElement(ElementName = "modelName", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public string ModelName { get; set; }
            [XmlElement(ElementName = "modelNumber", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public string ModelNumber { get; set; }
            [XmlElement(ElementName = "UDN", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public string UDN { get; set; }
            [XmlElement(ElementName = "serialNumber", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public string SerialNumber { get; set; }
            [XmlElement(ElementName = "serviceList", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public ServiceList ServiceList { get; set; }
            [XmlElement(ElementName = "presentationURL", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public string PresentationURL { get; set; }
            [XmlElement(ElementName = "iconList", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public IconList IconList { get; set; }
            //[XmlElement(ElementName = "NoOfIOLines", Namespace = "urn:schemas-upnp-org:device-1-0")]
            //public string NoOfIOLines { get; set; }
            //[XmlElement(ElementName = "NoOfDigitalInputLines", Namespace = "urn:schemas-upnp-org:device-1-0")]
            //public string NoOfDigitalInputLines { get; set; }
            //[XmlElement(ElementName = "NoOfDigitalOutputLines", Namespace = "urn:schemas-upnp-org:device-1-0")]
            //public string NoOfDigitalOutputLines { get; set; }
            //[XmlElement(ElementName = "CurrentNetworkIOProtocol", Namespace = "urn:schemas-upnp-org:device-1-0")]
            //public string CurrentNetworkIOProtocol { get; set; }
            //[XmlElement(ElementName = "CurrentNetworkIOProtocolTcpPort", Namespace = "urn:schemas-upnp-org:device-1-0")]
            //public string CurrentNetworkIOProtocolTcpPort { get; set; }
            //[XmlElement(ElementName = "NoOfPorts", Namespace = "urn:schemas-upnp-org:device-1-0")]
            //public string NoOfPorts { get; set; }
            //[XmlElement(ElementName = "X_hardwareId", Namespace = "urn:schemas-upnp-org:device-1-0")]
            //public string X_hardwareId { get; set; }
            //[XmlElement(ElementName = "fwver", Namespace = "urn:schemas-upnp-org:device-1-0")]
            //public string Fwver { get; set; }
            //[XmlElement(ElementName = "blver", Namespace = "urn:schemas-upnp-org:device-1-0")]
            //public string Blver { get; set; }
            //[XmlElement(ElementName = "dhcp", Namespace = "urn:schemas-upnp-org:device-1-0")]
            //public string Dhcp { get; set; }
            //[XmlElement(ElementName = "sip", Namespace = "urn:schemas-upnp-org:device-1-0")]
            //public string Sip { get; set; }
            //[XmlElement(ElementName = "ipmask", Namespace = "urn:schemas-upnp-org:device-1-0")]
            //public string Ipmask { get; set; }
            //[XmlElement(ElementName = "gateway", Namespace = "urn:schemas-upnp-org:device-1-0")]
            //public string Gateway { get; set; }
            //[XmlElement(ElementName = "dns", Namespace = "urn:schemas-upnp-org:device-1-0")]
            //public string Dns { get; set; }
        }

        [XmlRoot(ElementName = "root", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public class SSDPDeviceDescription
    {
            [XmlElement(ElementName = "specVersion", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public SpecVersion SpecVersion { get; set; }
            [XmlElement(ElementName = "device", Namespace = "urn:schemas-upnp-org:device-1-0")]
            public Device Device { get; set; }
            [XmlAttribute(AttributeName = "xmlns")]
            public string Xmlns { get; set; }
        }

    }


