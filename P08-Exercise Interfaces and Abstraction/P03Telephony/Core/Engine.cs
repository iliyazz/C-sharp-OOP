
namespace Telephony.Core
{
    using System;
    using IO.Contracts;
    using Telephony.Models;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly StationaryPhone stationaryPhone;
        private readonly Smartphone smartphone;

        private Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartphone = new Smartphone();
        }
        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            string[] phoneNumbers = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urlLinks = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var phoneNumber in phoneNumbers)
            {
                if (!this.CheckNumber(phoneNumber))
                {
                    this.writer.WriteLine("Invalid number!");
                }
                else if (phoneNumber.Length == 10)
                {
                    this.writer.WriteLine(this.smartphone.Call(phoneNumber));
                }
                else if (phoneNumber.Length == 7)
                {
                    this.writer.WriteLine(this.stationaryPhone.Call(phoneNumber));
                }
            }
            foreach (var urlLink in urlLinks)
            {
                if (!this.CheckUrlLink(urlLink))
                {
                    this.writer.WriteLine("Invalid URL!");
                }
                else
                {
                    this.writer.WriteLine(this.smartphone.Browse(urlLink));
                }
            }
        }


        private bool CheckNumber(string phoneNumber)
        {
            foreach (var ch in phoneNumber)
            {
                if (!char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }
        private bool CheckUrlLink(string urlLink)
        {
            foreach (var ch in urlLink)
            {
                if (char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
