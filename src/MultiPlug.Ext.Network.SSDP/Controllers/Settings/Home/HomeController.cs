using MultiPlug.Base.Attribute;
using MultiPlug.Base.Http;

namespace MultiPlug.Ext.Network.SSDP.Controllers.Settings.Home
{
    [Route("")]
    public class HomeController : SettingsApp
    {
        public Response Get()
        {
            return new Response
            {
                Model = new Models.Settings.Home { SSDPs = Core.Instance.SSDPs, SSDPCount = Core.Instance.SSDPs.Length.ToString() },
                Template = "NetworkSSDPHomeView"
            };
        }
    }
}
