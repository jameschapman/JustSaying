﻿using System;

namespace SimplesNotificationStack.Messaging.Lookups
{
    public interface IPublishEndpointProvider
    {
        string GetLocationEndpoint(PublishTopics location);
        string GetLocationName(PublishTopics location);
    }

    public class SnsPublishEndpointProvider : IPublishEndpointProvider
    {
        public string GetLocationEndpoint(PublishTopics location)
        {
            // Eventually this should come from the Settings API (having been published somewhere by the create process).
            switch (location)
            {
                case PublishTopics.OrderDispatch:
                    return "arn:aws:sns:eu-west-1:507204202721:uk-qa12-order-dispatch";

                case PublishTopics.CustomerCommunication:
                    return "arn:aws:sns:eu-west-1:507204202721:uk-qa12-customer-order-communication";
            } 

            throw new IndexOutOfRangeException("There is no endpoint defined for the provided location type");
        }

        public string GetLocationName(PublishTopics location)
        {
            // Eventually this should include the environment etc.
            switch (location)
            {
                case PublishTopics.OrderDispatch:
                    return "order-dispatch";

                case PublishTopics.CustomerCommunication:
                    return "customer-order-communication";
            }
            
            throw new IndexOutOfRangeException("There is no location defined for the provided location type");
        }
    }
}