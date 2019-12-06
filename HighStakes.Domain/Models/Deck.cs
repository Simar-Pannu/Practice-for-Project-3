using System;
using System.Collections.Generic;

namespace HighStakes.Domain.Models
{
    public class DDeck
    {
        public int DeckId { get; set; }
        public List<DCard> Cards { get; set; }

        public DDeck(int deckId, List<DCard> cards)
        {
            DeckId = deckId;
            Cards = cards;
        }
        public void Initialize()
        {
            Cards = new List<DCard>();

            for (int i = 0; i < 13; i++) 
            {
                DCard club = new DCard(0, 0, "");
                DCard heart = new DCard(0, 0, "");
                DCard spade = new DCard(0, 0, "");
                DCard diamond = new DCard(0, 0, "");
                if (i == 0)
                {
                    club.Initialize(2, "Club", "Two of Clubs");
                    heart.Initialize(2, "Heart", "Two of Hearts");
                    spade.Initialize(2, "Spade", "Two of Spades");
                    diamond.Initialize(2, "Diamond", "Two of Diamonds");
                } else if (i == 1)
                {
                    club.Initialize(3, "Club", "Three of Clubs");
                    heart.Initialize(3, "Heart", "Three of Hearts");
                    spade.Initialize(3, "Spade", "Three of Spades");
                    diamond.Initialize(3, "Diamond", "Three of Diamonds");
                } else if (i == 2)
                {
                    club.Initialize(4, "Club", "Four of Clubs");
                    heart.Initialize(4, "Heart", "Four of Hearts");
                    spade.Initialize(4, "Spade", "Four of Spades");
                    diamond.Initialize(4, "Diamond", "Four of Diamonds");
                } else if (i == 3)
                {
                    club.Initialize(5, "Club", "Five of Clubs");
                    heart.Initialize(5, "Heart", "Five of Hearts");
                    spade.Initialize(5, "Spade", "Five of Spades");
                    diamond.Initialize(5, "Diamond", "Five of Diamonds");
                } else if (i == 4)
                {
                    club.Initialize(6, "Club", "Six of Clubs");
                    heart.Initialize(6, "Heart", "Six of Hearts");
                    spade.Initialize(6, "Spade", "Six of Spades");
                    diamond.Initialize(6, "Diamond", "Six of Diamonds");
                } else if (i == 5)
                {
                    club.Initialize(7, "Club", "Seven of Clubs");
                    heart.Initialize(7, "Heart", "Seven of Hearts");
                    spade.Initialize(7, "Spade", "Seven of Spades");
                    diamond.Initialize(7, "Diamond", "Seven of Diamonds");
                } else if (i == 6)
                {
                    club.Initialize(8, "Club", "Eight of Clubs");
                    heart.Initialize(8, "Heart", "Eight of Hearts");
                    spade.Initialize(8, "Spade", "Eight of Spades");
                    diamond.Initialize(8, "Diamond", "Eight of Diamonds");
                } else if (i == 7)
                {
                    club.Initialize(9, "Club", "Nine of Clubs");
                    heart.Initialize(9, "Heart", "Nine of Hearts");
                    spade.Initialize(9, "Spade", "Nine of Spades");
                    diamond.Initialize(9, "Diamond", "Nine of Diamonds");
                } else if (i == 8)
                {
                    club.Initialize(10, "Club", "Ten of Clubs");
                    heart.Initialize(10, "Heart", "Ten of Hearts");
                    spade.Initialize(10, "Spade", "Ten of Spades");
                    diamond.Initialize(10, "Diamond", "Ten of Diamonds");
                } else if (i == 9)
                {
                    club.Initialize(11, "Club", "Jack of Clubs");
                    heart.Initialize(11, "Heart", "Jack of Hearts");
                    spade.Initialize(11, "Spade", "Jack of Spades");
                    diamond.Initialize(11, "Diamond", "Jack of Diamonds");
                } else if (i == 10)
                {
                    club.Initialize(12, "Club", "Queen of Clubs");
                    heart.Initialize(12, "Heart", "Queen of Hearts");
                    spade.Initialize(12, "Spade", "Queen of Spades");
                    diamond.Initialize(12, "Diamond", "Queen of Diamonds");
                } else if (i == 11)
                {
                    club.Initialize(13, "Club", "King of Clubs");
                    heart.Initialize(13, "Heart", "King of Hearts");
                    spade.Initialize(13, "Spade", "King of Spades");
                    diamond.Initialize(13, "Diamond", "King of Diamonds");
                } else if (i == 12)
                {
                    club.Initialize(14, "Club", "Ace of Clubs");
                    heart.Initialize(14, "Heart", "Ace of Hearts");
                    spade.Initialize(14, "Spade", "Ace of Spades");
                    diamond.Initialize(14, "Diamond", "Ace of Diamonds");
                } 
                Cards.Add(club);
                Cards.Add(heart);
                Cards.Add(spade);
                Cards.Add(diamond);
            }

            Shuffle();
        }

        public void Shuffle()
        {
            Random rng = new Random();
            int count = Cards.Count;  
            while (count > 1) {  
                count--;  
                int rand = rng.Next(count + 1);  
                DCard card = Cards[rand];  
                Cards[rand] = Cards[count];  
                Cards[count] = card;  
            }  
        }

        public DCard Draw()
        {
            DCard draw = Cards[0];
            Cards.RemoveAt(0);
            return draw;
        }
    }
}