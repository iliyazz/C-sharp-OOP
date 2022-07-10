

namespace FoodShortage.Models
{
    using Contracts;
    public class Robot : IRobot
    {
        public string Identity { get; set; }
        public string NameModel { get; set; }

        public Robot(string model, string id)
        {
            this.Identity = model;
            this.NameModel = id;
        }
    }
}
