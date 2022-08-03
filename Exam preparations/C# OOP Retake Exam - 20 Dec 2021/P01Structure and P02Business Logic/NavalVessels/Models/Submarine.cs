namespace NavalVessels.Models
{
    using System;
    using Contracts;

    public class Submarine : Vessel, ISubmarine
    {
        private const double SubmarineInitialArmorThickness = 200.0;
        private bool submergeMode;
        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, SubmarineInitialArmorThickness)
        {
            this.SubmergeMode = false;
        }

        public bool SubmergeMode
        {
            get => submergeMode;
            private set
            {
                submergeMode = value;
            }
        }

        public void ToggleSubmergeMode()
        {
            if (this.SubmergeMode == true)
            {
                this.MainWeaponCaliber -= 40.0;
                this.Speed += 4.0;
                this.SubmergeMode = false;
            }
            else
            {
                this.MainWeaponCaliber += 40.0;
                this.Speed -= 4.0;
                this.SubmergeMode = true;
            }
        }
        public override void RepairVessel()
        {
            if (this.ArmorThickness < SubmarineInitialArmorThickness)
            {
                this.ArmorThickness = SubmarineInitialArmorThickness;
            }
        }

        public override string ToString()
        {
            var addSonarModeToParentString = this.SubmergeMode == true ? " *Submerge mode: ON" : " *Submerge mode: OFF";
            return base.ToString() + Environment.NewLine + addSonarModeToParentString;
        }
    }
}
