namespace HighStakes.Domain.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ChipTotal { get; set; }
    }
}