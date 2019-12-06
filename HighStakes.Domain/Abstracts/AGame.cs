using System.Collections.Generic;
using HighStakes.Domain.Models;

namespace HighStakes.Domain.Abstracts
{
    public abstract class AGame
    {
        public List<Card> Flop { get; set; }
    }
}