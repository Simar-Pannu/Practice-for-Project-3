namespace HighStakes.Domain.Models
{
    public class DUser
    {
        public int UserId { get; set; }
        public DAccount Account { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ChipTotal { get; set; }
    }
}