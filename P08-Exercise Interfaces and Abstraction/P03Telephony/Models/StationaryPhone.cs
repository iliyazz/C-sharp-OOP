namespace Telephony
{
    using System;

    public class StationaryPhone : ICallable
    {

        public string Call(string phoneNumber)
        {
            return $"Dialing... {phoneNumber}";
        }
    }
}
