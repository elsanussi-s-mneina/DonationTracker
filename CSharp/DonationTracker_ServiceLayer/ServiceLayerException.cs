using System;
using DonationTracker.Integration;

namespace DonationTracker.Service
{
    public class ServiceLayerException : Exception
    {
        public ServiceLayerException(IntegrationLayerException exception)
 : base(exception.Message, exception)
        {
        }

        public ServiceLayerException(string message, Exception exception) :
            base(message, exception)
        {

        }
    }
}

