using BirthdayCelebrations.Models.Contracts;

namespace BirthdayCelebrations.Models
{
    public class Pet : IPet
    {
        public string NameModel { get; private set; }
        public string Birthdate { get; private set; }

        public Pet(string nameModel, string birthdate)
        {
            NameModel = nameModel;
            Birthdate = birthdate;
        }
    }
}
