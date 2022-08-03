namespace NavalVessels.Models
{
    using System;
    using Contracts;

    public class Battleship : Vessel, IBattleship
    {
        private const double BattleshipInitialArmorThickness = 300.0;
        private bool sonarMode;

        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, BattleshipInitialArmorThickness)
        {
            this.SonarMode = false;
        }

        public bool SonarMode
        {
            get => sonarMode;
            private set
            {
                sonarMode = value;
            }
        }

        public void ToggleSonarMode()
        {
            if (this.SonarMode == true)
            {
                this.MainWeaponCaliber -= 40.0;
                this.Speed += 5.0;
                this.SonarMode = false;
            }
            else
            {
                this.MainWeaponCaliber += 40.0;
                this.Speed -= 5.0;
                this.SonarMode = true;
            }
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < BattleshipInitialArmorThickness)
            {
                this.ArmorThickness = BattleshipInitialArmorThickness;
            }
        }

        public override string ToString()
        {
            var addSonarModeToParentString = this.SonarMode == true ? " *Sonar mode: ON" : " *Sonar mode: OFF";
            return base.ToString() + Environment.NewLine + addSonarModeToParentString;
        }
    }
}
