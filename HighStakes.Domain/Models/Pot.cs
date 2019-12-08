using System.Collections.Generic;

namespace HighStakes.Domain.Models
{
    public class DPot
    {
        public int PotId { get; set; }
        public List<DUser> PossibleWinners { get; set; }

        public void Initialize()
        {
            PossibleWinners = new List<DUser>();
        }
    }
}