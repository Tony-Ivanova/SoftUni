namespace BorderControl
{
    public class Robot : IIdentification
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; set; }
        public string Id { get; private set; }
    }
}
