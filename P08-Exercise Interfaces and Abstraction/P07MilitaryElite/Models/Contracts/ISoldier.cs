﻿namespace MilitaryElite.IO.Models.Contracts
{
    public interface ISoldier
    {
        public string Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        //public abstract void ToString();
    }
}
