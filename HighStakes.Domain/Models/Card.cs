namespace HighStakes.Domain.Models
{
    public class DCard
    {
        public int CardId { get; set; }
        public int Value { get; set; }
        public string Suit { get; set; }
        public string Name { get; set; }

        public DCard(int cardId, int value, string suit)
        {
            CardId = cardId;
            Value = value;
            Suit = suit;
        }

        public void Initialize(int value, string suit, string name)
        {
            Value = value;
            Suit = suit;
            Name = name;
        }
    }
}