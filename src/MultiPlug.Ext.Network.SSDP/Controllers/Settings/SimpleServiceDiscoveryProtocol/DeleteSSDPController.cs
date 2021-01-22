using System.Linq;
using MultiPlug.Base.Attribute;
using MultiPlug.Base.Http;

namespace MultiPlug.Ext.Network.SSDP.Controllers.Settings.SimpleServiceDiscoveryProtocol
{
    [Route("ssdp/delete")]
    public class DeleteSSDPController : SettingsApp
    {
        public Response Get(string id)
        {
            if( !string.IsNullOrEmpty(id))
            {
                var SSDPComponent = Core.Instance.SSDPs.FirstOrDefault(SSDP => SSDP.Guid == id);

                if( SSDPComponent == null)
                {
                    return new Response
                    {
                        StatusCode = System.Net.HttpStatusCode.NotFound,
                    };
                }
                else
                {
                    Core.Instance.Remove(new []{ SSDPComponent});
                    return new Response
                    {
                        StatusCode = System.Net.HttpStatusCode.Redirect,
                        Location = Context.Referrer
                    };
                }
            }
            else
            {
                return new Response
                {
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                };
            }
        }
    }
}
