using System.Collections.Generic;

namespace HighStakes.Storing.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? ChipTotal { get; set; }

        public Account Account{get;set;}
    }
}