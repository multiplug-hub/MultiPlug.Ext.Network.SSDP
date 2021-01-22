using System;
using MultiPlug.Base.Exchange;
using MultiPlug.Base.Exchange.API;
using MultiPlug.Ext.Network.SSDP.Models.Components;

namespace MultiPlug.Ext.Network.SSDP.Components.SimpleServiceDiscoveryProtocol
{
    public class SSDPComponent : SSDPProperties
    {

        internal event Action EventsUpdated;
        internal event Action SubscriptionsUpdated;

        readonly ILoggingService m_LoggingService;

        private SSDPWorker m_SSDPWorker;

        public SSDPComponent(string theGuid, ILoggingService theLoggingService)
        {
            m_LoggingService = theLoggingService;

            Guid = theGuid;
            DiscoveryTarget = "";
            SearchSubscription = new Subscription { Guid = theGuid, Id = "" };

            m_SSDPWorker = new SSDPWorker(this);
            m_SSDPWorker.DeviceDiscovered += OnDeviceDiscovered;
            SearchSubscription.EventConsumer = m_SSDPWorker;

            DiscoveryEvent = new Event
            {
                Guid = theGuid,
                Id = "",
                Description = "",
                Subjects = new string[]
                    {
                        "Location",
                        "DeviceType",
                        "FriendlyName",
                        "Manufacturer",
                        "ManufacturerURL",
                        "ModelDescription",
                        "ModelName",
                        "ModelNumber",
                        "UDN",
                        "SerialNumber",
                        "PresentationURL" }
            };
    }

        public void UpdateProperties(SSDPProperties theProperties)
        {
            bool EventUpdatedFlag = false;
            bool SubscriptionUpdatedFlag = false;

            if (theProperties.DiscoveryEvent.Id != DiscoveryEvent.Id)
            {
                DiscoveryEvent.Id = theProperties.DiscoveryEvent.Id;
                EventUpdatedFlag = true;
            }

            if (theProperties.DiscoveryEvent.Description != DiscoveryEvent.Description)
            {
                DiscoveryEvent.Description = theProperties.DiscoveryEvent.Description;
                EventUpdatedFlag = true;
            }

            if (theProperties.DiscoveryTarget != DiscoveryTarget)
            {
                DiscoveryTarget = theProperties.DiscoveryTarget;
            }

            if (theProperties.SearchSubscription != null && theProperties.SearchSubscription.Id != SearchSubscription.Id)
            {
                SearchSubscription.Id = theProperties.SearchSubscription.Id;
                SubscriptionUpdatedFlag = true;
            }



            ///
            /// ...
            /// 

            if (EventUpdatedFlag)
            {
                EventsUpdated?.Invoke();
            }

            if( SubscriptionUpdatedFlag)
            {
                SubscriptionsUpdated?.Invoke();
            }
        }

        public void OnDeviceDiscovered( string theIPAddress, Device theDeviceDesription)
        {
            DiscoveryEvent.Fire(new Payload
            (
                DiscoveryEvent.Id,
                new []
                {
                    new PayloadSubject( DiscoveryEvent.Subjects[0], theIPAddress ),
                    new PayloadSubject( DiscoveryEvent.Subjects[1], string.IsNullOrEmpty(theDeviceDesription.DeviceType)? string.Empty: theDeviceDesription.DeviceType  ),
                    new PayloadSubject( DiscoveryEvent.Subjects[2], string.IsNullOrEmpty(theDeviceDesription.FriendlyName)? string.Empty: theDeviceDesription.FriendlyName ),
                    new PayloadSubject( DiscoveryEvent.Subjects[3], string.IsNullOrEmpty(theDeviceDesription.Manufacturer)? string.Empty: theDeviceDesription.Manufacturer ),
                    new PayloadSubject( DiscoveryEvent.Subjects[4], string.IsNullOrEmpty(theDeviceDesription.ManufacturerURL)? string.Empty: theDeviceDesription.ManufacturerURL ),
                    new PayloadSubject( DiscoveryEvent.Subjects[5], string.IsNullOrEmpty(theDeviceDesription.ModelDescription)? string.Empty: theDeviceDesription.ModelDescription ),
                    new PayloadSubject( DiscoveryEvent.Subjects[6], string.IsNullOrEmpty(theDeviceDesription.ModelName)? string.Empty: theDeviceDesription.ModelName ),
                    new PayloadSubject( DiscoveryEvent.Subjects[7], string.IsNullOrEmpty(theDeviceDesription.ModelNumber)? string.Empty: theDeviceDesription.ModelNumber ),
                    new PayloadSubject( DiscoveryEvent.Subjects[8], string.IsNullOrEmpty(theDeviceDesription.UDN)? string.Empty: theDeviceDesription.UDN ),
                    new PayloadSubject( DiscoveryEvent.Subjects[9], string.IsNullOrEmpty(theDeviceDesription.SerialNumber)? string.Empty: theDeviceDesription.SerialNumber ),
                    new PayloadSubject( DiscoveryEvent.Subjects[10], string.IsNullOrEmpty(theDeviceDesription.PresentationURL)? string.Empty: theDeviceDesription.PresentationURL )
                }
            ));
        }
    }
}
