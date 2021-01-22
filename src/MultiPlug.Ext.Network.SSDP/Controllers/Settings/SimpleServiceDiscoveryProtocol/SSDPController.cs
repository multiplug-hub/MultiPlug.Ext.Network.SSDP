using System;
using System.Linq;
using MultiPlug.Base.Attribute;
using MultiPlug.Base.Exchange;
using MultiPlug.Base.Http;
using MultiPlug.Ext.Network.SSDP.Models.Components;
using MultiPlug.Ext.Network.SSDP.Models.Settings;

namespace MultiPlug.Ext.Network.SSDP.Controllers.Settings.SimpleServiceDiscoveryProtocol
{
    [Route("ssdp")]
    public class SSDPController : SettingsApp
    {
        public Response Get(string id)
        {
            SSDPProperties SSDPProperties = null;

            if( ! string.IsNullOrEmpty(id))
            {
                SSDPProperties = Core.Instance.SSDPs.FirstOrDefault(SSDP => SSDP.Guid == id);
            }

            if (SSDPProperties == null)
            {
                var guid = Guid.NewGuid().ToString();
                SSDPProperties = new SSDPProperties
                {
                    Guid = guid,
                    DiscoveryTarget = "",
                    DiscoveryEvent = new Event { Guid = guid, Description = "", Id = guid },
                    SearchSubscription = new Subscription { Guid = Guid.NewGuid().ToString(), Id = "" }
                };
            }

            return new Response
            {
                Model = SSDPProperties,
                Template = "NetworkSSDPView"
            };
        }

        public Response Post(PostSSDPModel theModel)
        {
            string Guid = string.Empty;

            if( theModel != null)
            {
                Core.Instance.Update(new[] { new SSDPProperties {
                    Guid = theModel.guid,
                    SearchSubscription = new Subscription {Id = theModel.subscription },
                    DiscoveryEvent = new Event { Id = theModel.eventid, Description = theModel.eventdescription},
                    DiscoveryTarget = theModel.discoverytarget }
                });

                Guid = theModel.guid;
            }

            return new Response
            {
                StatusCode = System.Net.HttpStatusCode.Moved,
                Location = new Uri(Context.Referrer, "?id=" + Guid)
            };
        }

    }
}
