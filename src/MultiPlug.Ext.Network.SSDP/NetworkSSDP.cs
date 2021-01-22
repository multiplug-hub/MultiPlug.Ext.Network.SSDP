using System.Collections.Generic;
using MultiPlug.Base.Exchange;
using MultiPlug.Extension.Core;
using MultiPlug.Extension.Core.Http;
using MultiPlug.Ext.Network.SSDP.Properties;
using MultiPlug.Ext.Network.SSDP.Models.Load;

namespace MultiPlug.Ext.Network.SSDP
{
    public class NetworkSSDP : MultiPlugExtension
    {
        private List<LoadModel> m_Load = new List<LoadModel>();

        public NetworkSSDP()
        {
            Core.Instance.SubscriptionsUpdated += OnSubscriptionsUpdated;
            Core.Instance.EventsUpdated += OnEventsUpdated;

            MultiPlugServices.Logging.RegisterDefinitions(Diagnostics.EventLogDefinitions.DefinitionsId, Diagnostics.EventLogDefinitions.Definitions, true);

            Core.Instance.MultiPlugServices = MultiPlugServices;
        }

        private void OnEventsUpdated()
        {
            MultiPlugActions.Extension.Updates.Events();
        }

        public override Event[] Events
        {
            get
            {
                return Core.Instance.Events;
            }
        }

        private void OnSubscriptionsUpdated()
        {
            MultiPlugActions.Extension.Updates.Subscriptions();
        }

        public override Subscription[] Subscriptions
        {
            get
            {
                return Core.Instance.Subscriptions;
            }
        }

        public override RazorTemplate[] RazorTemplates
        {
            get
            {
                return new RazorTemplate[]
                {
                    new RazorTemplate("NetworkSSDPHomeView", Resources.HomeRazor),
                    new RazorTemplate("NetworkSSDPView", Resources.SSDPRazor),
                    new RazorTemplate("NetworkSSDPItemNotFound", Resources.NotFound),
                };
            }
        }

        public void Load(LoadModel config)
        {
            m_Load.Add(config);
        }

        public override void Initialise()
        {
            LoadModel[] Load = m_Load.ToArray();
            m_Load.Clear();

            foreach (LoadModel LoadModel in Load)
            {
                if (LoadModel.SSDPs != null)
                {
                    Core.Instance.Update(LoadModel.SSDPs);
                }
            }
        }

        public override object Save()
        {
            return Core.Instance;
        }
    }
}