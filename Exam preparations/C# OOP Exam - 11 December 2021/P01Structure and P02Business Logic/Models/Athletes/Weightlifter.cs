﻿namespace Gym.Models.Athletes
{
    using System;
    using Utilities.Messages;

    public class Weightlifter : Athlete
    {
        public Weightlifter(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, 50)
        {
        }

        public override void Exercise()
        {
            Stamina += 10;
            
        }
    }
}
