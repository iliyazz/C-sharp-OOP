﻿namespace WildFarm.Factories.Contracts
{
    using Models.Animals;
    public interface IAnimalFactory
    {
        Animal CreateAnimal(string type, string name, double weight, string thirdParam, string fourthParam = null);
    }
}
