using BorderControl.Models.Contracts;

namespace BorderControl.Models
{
    public class Robot : IRobot
    {
        public string Model { get; set; }
        public string Id { get; set; }

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
    }
}
