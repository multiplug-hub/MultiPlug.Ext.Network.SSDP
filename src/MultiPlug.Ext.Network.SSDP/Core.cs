using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MultiPlug.Base;
using MultiPlug.Base.Exchange;
using MultiPlug.Base.Exchange.API;
using MultiPlug.Ext.Network.SSDP.Components.SimpleServiceDiscoveryProtocol;
using MultiPlug.Ext.Network.SSDP.Models.Components;

namespace MultiPlug.Ext.Network.SSDP
{
    internal class Core : MultiPlugBase
    {
        private static Core m_Instance = null;

        internal IMultiPlugServices MultiPlugServices { get; set; }

        internal event Action EventsUpdated;
        internal event Action SubscriptionsUpdated;

        public Subscription[] Subscriptions { get; private set; } = new Subscription[0];
        public Event[] Events { get; private set; } = new Event[0];

        public static Core Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new Core();
                }
                return m_Instance;
            }
        }

        [DataMember]
        public SSDPComponent[] SSDPs { get; set; } = new SSDPComponent[0];

        private void OnEventsUpdated()
        {
            List<Event> EventsList = new List<Event>();
            Array.ForEach(SSDPs, SSDPComponent => EventsList.Add(SSDPComponent.DiscoveryEvent));
            Events = EventsList.ToArray();
            EventsUpdated?.Invoke();
        }

        private void OnSubscriptionsUpdated()
        {
            List<Subscription> SubscriptionList = new List<Subscription>();
            Array.ForEach(SSDPs, SSDPComponent => SubscriptionList.Add(SSDPComponent.SearchSubscription));
            Subscriptions = SubscriptionList.ToArray();
            SubscriptionsUpdated?.Invoke();
        }

        public void Add(SSDPComponent[] theSSDPComponents)
        {
            foreach (var item in theSSDPComponents)
            {
                item.SubscriptionsUpdated += OnSubscriptionsUpdated;
                item.EventsUpdated += OnEventsUpdated;

                var SSDPsAdd = new List<SSDPComponent>(SSDPs);

                SSDPsAdd.Add(item as SSDPComponent);

                SSDPs = SSDPsAdd.ToArray();
            }
        }

        public void Remove(SSDPComponent[] theSSDPComponents)
        {
            foreach (SSDPComponent SSDPComponent in theSSDPComponents)
            {
                SSDPComponent.SubscriptionsUpdated -= OnSubscriptionsUpdated;
                SSDPComponent.EventsUpdated -= OnEventsUpdated;

                var SSDPsRemove = new List<SSDPComponent>(SSDPs);
                SSDPsRemove.Remove(SSDPComponent as SSDPComponent);
                SSDPs = SSDPsRemove.ToArray();
            }

            if(theSSDPComponents.Any())
            {
                OnEventsUpdated();
                OnSubscriptionsUpdated();
            }
        }

        internal void Update(SSDPProperties[] model)
        {
            foreach (var item in model)
            {
                SSDPComponent SSDPSearch = SSDPs.FirstOrDefault(SSDP => SSDP.Guid == item.Guid);

                if (SSDPSearch != null)
                {
                    SSDPSearch.UpdateProperties(item);
                }
                else
                {
                    if (!string.IsNullOrEmpty(item.Guid))
                    {
                        var Logger = MultiPlugServices.Logging.New(item.Guid, Diagnostics.EventLogDefinitions.DefinitionsId);
                        SSDPSearch = new SSDPComponent(item.Guid, Logger);
                        Add(new SSDPComponent[] { SSDPSearch });
                        SSDPSearch.UpdateProperties(item);
                    }
                }
            }
        }
    }
}
