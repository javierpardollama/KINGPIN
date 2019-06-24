using System;

namespace Kingpin.Tier.Exceptions.Classes
{
    public class ServiceException : Exception
    {
        public ServiceException(string message) : base(message) { }
    }
}
