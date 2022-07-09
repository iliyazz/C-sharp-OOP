namespace Telephony.Models
{
    using System;

    public class Smartphone : ISmartphone
    {
        public string Browse(string urlLink)
        {
            return $"Browsing: {urlLink}!";
        }

        public string Call(string phoneNumber)
        {
            return $"Calling... {phoneNumber}";
        }
    }
}
