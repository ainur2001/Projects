namespace BShop.Models
{
    public class Appointment
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string phoneNumber { get; set; }
        public DateTime DateOfHaircut { get; set; }
        
        public string MasterName { get; set; }
        public string created_at { get; set; }
    }
}
