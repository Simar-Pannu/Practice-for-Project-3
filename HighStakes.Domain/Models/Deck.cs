using System;
using System.Collections.Generic;

namespace HighStakes.Domain.Models
{
    public class Deck
    {
        public int DeckId { get; set; }
        public List<Card> Cards { get; set; }

        public void Initialize()
        {
            Cards = new List<Card>();

            for (int i = 0; i < 13; i++) 
            {
                Card club = new Card();
                Card heart = new Card();
                Card spade = new Card();
                Card diamond = new Card();
                if (i == 0)
                {
                    club.Initialize(2, "Club", "Two of Clubs");
                    heart.Initialize(2, "Heart", "Two of Hearts");
                    spade.Initialize(2, "Spade", "Two of Spades");
                    diamond.Initialize(2, "Diamond", "Two of Diamonds");
                } else if (i == 1)
                {
                    club.Initialize(2, "Club", "Three of Clubs");
                    heart.Initialize(2, "Heart", "Three of Hearts");
                    spade.Initialize(2, "Spade", "Three of Spades");
                    diamond.Initialize(2, "Diamond", "Three of Diamonds");
                } else if (i == 2)
                {
                    club.Initialize(2, "Club", "Four of Clubs");
                    heart.Initialize(2, "Heart", "Four of Hearts");
                    spade.Initialize(2, "Spade", "Four of Spades");
                    diamond.Initialize(2, "Diamond", "Four of Diamonds");
                } else if (i == 3)
                {
                    club.Initialize(2, "Club", "Five of Clubs");
                    heart.Initialize(2, "Heart", "Five of Hearts");
                    spade.Initialize(2, "Spade", "Five of Spades");
                    diamond.Initialize(2, "Diamond", "Five of Diamonds");
                } else if (i == 4)
                {
                    club.Initialize(2, "Club", "Six of Clubs");
                    heart.Initialize(2, "Heart", "Six of Hearts");
                    spade.Initialize(2, "Spade", "Six of Spades");
                    diamond.Initialize(2, "Diamond", "Six of Diamonds");
                } else if (i == 5)
                {
                    club.Initialize(2, "Club", "Seven of Clubs");
                    heart.Initialize(2, "Heart", "Seven of Hearts");
                    spade.Initialize(2, "Spade", "Seven of Spades");
                    diamond.Initialize(2, "Diamond", "Seven of Diamonds");
                } else if (i == 6)
                {
                    club.Initialize(2, "Club", "Eight of Clubs");
                    heart.Initialize(2, "Heart", "Eight of Hearts");
                    spade.Initialize(2, "Spade", "Eight of Spades");
                    diamond.Initialize(2, "Diamond", "Eight of Diamonds");
                } else if (i == 7)
                {
                    club.Initialize(2, "Club", "Nine of Clubs");
                    heart.Initialize(2, "Heart", "Nine of Hearts");
                    spade.Initialize(2, "Spade", "Nine of Spades");
                    diamond.Initialize(2, "Diamond", "Nine of Diamonds");
                } else if (i == 8)
                {
                    club.Initialize(2, "Club", "Ten of Clubs");
                    heart.Initialize(2, "Heart", "Ten of Hearts");
                    spade.Initialize(2, "Spade", "Ten of Spades");
                    diamond.Initialize(2, "Diamond", "Ten of Diamonds");
                } else if (i == 9)
                {
                    club.Initialize(2, "Club", "Jack of Clubs");
                    heart.Initialize(2, "Heart", "Jack of Hearts");
                    spade.Initialize(2, "Spade", "Jack of Spades");
                    diamond.Initialize(2, "Diamond", "Jack of Diamonds");
                } else if (i == 10)
                {
                    club.Initialize(2, "Club", "Queen of Clubs");
                    heart.Initialize(2, "Heart", "Queen of Hearts");
                    spade.Initialize(2, "Spade", "Queen of Spades");
                    diamond.Initialize(2, "Diamond", "Queen of Diamonds");
                } else if (i == 11)
                {
                    club.Initialize(2, "Club", "King of Clubs");
                    heart.Initialize(2, "Heart", "King of Hearts");
                    spade.Initialize(2, "Spade", "King of Spades");
                    diamond.Initialize(2, "Diamond", "King of Diamonds");
                } else if (i == 12)
                {
                    club.Initialize(2, "Club", "Ace of Clubs");
                    heart.Initialize(2, "Heart", "Ace of Hearts");
                    spade.Initialize(2, "Spade", "Ace of Spades");
                    diamond.Initialize(2, "Diamond", "Ace of Diamonds");
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
                Card card = Cards[rand];  
                Cards[rand] = Cards[count];  
                Cards[count] = card;  
            }  
        }

        public Card Draw()
        {
            Card draw = Cards[0];
            Cards.RemoveAt(0);
            return draw;
        }
    }
}