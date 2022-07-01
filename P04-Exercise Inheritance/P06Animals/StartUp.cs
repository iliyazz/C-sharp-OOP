using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string animalType = Console.ReadLine();
                if (animalType == "Beast!")
                {
                    break;
                }
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                if (age < 0)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                Animal animal = default;
                if (animalType == "Dog")
                {
                    string gender = tokens[2];
                    animal = new Dog(name, age, gender);
                }
                else if (animalType == "Cat")
                {
                    string gender = tokens[2];
                    animal = new Cat(name, age, gender);
                }
                else if (animalType == "Frog")
                {
                    string gender = tokens[2];
                    animal = new Frog(name, age, gender);
                }
                else if (animalType == "Kittens")
                {
                    animal = new Kitten(name, age);
                }
                else if(animalType == "Tomcat")
                {
                    animal = new Tomcat(name, age);
                }
                Console.WriteLine(animalType);
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
