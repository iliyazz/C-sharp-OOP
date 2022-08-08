namespace Easter.Models.Dyes
{
    using System;
    using Contracts;

    public class Dye : IDye
    {
        private int power;

        public Dye(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get => power;
            private set
            {
                if (value < 0)
                {
                    this.power = 0;
                }
                else
                {
                    power = value;
                }
            }
        }
        public void Use()
        {
            if (this.Power - 10 < 0)
            {
                this.Power = 0;
            }
            else
            {
                this.Power -= 10;
            }
        }

        public bool IsFinished()
        {
            return this.Power == 0;
        }
    }
}
