namespace HighStakes.Domain.Models
{
    public class Seat
    {
        public int SeatId { get; set; }
        public bool BigBlind { get; set; }
        public bool SmallBlind { get; set; }
    }
}