using System.ComponentModel.DataAnnotations.Schema;

namespace HighStakes.Domain.Models
{
    public class DUser
    {
        public int UserId { get; set; }
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public DAccount Account { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ChipTotal { get; set; }
    }
}