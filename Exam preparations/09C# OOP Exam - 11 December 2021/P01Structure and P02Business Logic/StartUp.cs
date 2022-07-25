namespace Gym
{
    using System;
    using Gym.Core;
    using Gym.Core.Contracts;
    using Models.Athletes;
    using Models.Equipment;
    using Models.Gyms;
    using Repositories;

    public class StartUp
    {
        public static void Main()
        {
            //EquipmentRepository equipmentRepository = new EquipmentRepository();
            //equipmentRepository.Add(new BoxingGloves());
            //Console.WriteLine(equipmentRepository.FindByType("BoxingGloves"));
            //Gym gym = new BoxingGym("Boxing gym");
            //gym.AddAthlete(new Boxer("Gosho", "All", 0));
            //Gym gymWeightL = new WeightliftingGym("WeghtLifter gym");
            //gym.AddAthlete(new Weightlifter("Pesho", "Low motivation", 0));
            //gym.Exercise();
            //gym.AddEquipment(new BoxingGloves());
            //gym.AddEquipment(new Kettlebell());
            //Console.WriteLine(gym.GymInfo());
            //return;

            // Don't forget to comment out the commented code lines in the Engine class!
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
