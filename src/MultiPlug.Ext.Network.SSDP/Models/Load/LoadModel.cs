using System.Runtime.Serialization;
using MultiPlug.Base;
using MultiPlug.Ext.Network.SSDP.Models.Components;

namespace MultiPlug.Ext.Network.SSDP.Models.Load
{
    public class LoadModel : MultiPlugBase
    {
        [DataMember]
        public SSDPProperties[] SSDPs { get; set; }
    }
}