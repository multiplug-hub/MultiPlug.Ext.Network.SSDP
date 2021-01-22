using MultiPlug.Base;
using MultiPlug.Ext.Network.SSDP.Models.Components;

namespace MultiPlug.Ext.Network.SSDP.Controllers.Models.Settings
{
    public class Home : MultiPlugBase
    {
        public string SSDPCount { get; set; }
        public SSDPProperties[] SSDPs { get; set; }
    }
}
