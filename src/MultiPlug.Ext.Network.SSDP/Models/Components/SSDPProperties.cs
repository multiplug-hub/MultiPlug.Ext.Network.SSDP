using MultiPlug.Base;
using MultiPlug.Base.Exchange;
using System.Runtime.Serialization;

namespace MultiPlug.Ext.Network.SSDP.Models.Components
{
    public class SSDPProperties : MultiPlugBase 
    {
        [DataMember]
        public string Guid { get; set; }
        [DataMember]
        public Event DiscoveryEvent { get; set; }
        [DataMember]
        public string DiscoveryTarget { get; set; }
        [DataMember]
        public Subscription SearchSubscription { get; set; }
    }
}
