namespace TodoApp.Models
{
    public class Vendor
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public double HourlyRate { get; set; }
        public string Status { get; set; } = "";
        // public Status Status { get; set; }
        // public string? AccountNumber { get; set; }
    }
}
