using System.Collections.Generic;

namespace HighStakes.Domain.Models
{
    public class DPot
    {
        public int PotId { get; set; }
        public List<DUser> PossibleWinners { get; set; }
        public int PotValue { get; set; }
        public bool Active { get; set; }
        public int AllInValue { get; set; }

        public void Initialize()
        {
            PossibleWinners = new List<DUser>();
            Active = true;
            PotValue = 0;
        }
    }
}