using System;
using System.Linq;
using System.Collections.Generic;

namespace PokerHandShowdown
{
    public enum CardSuit {
        Club,
        Diamond,
        Heart,
        Spade
    }

    public enum CardRank {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
    public class Card : IComparable<Card> {
        public CardSuit Suit { get; private set; }
        public CardRank Rank { get; private set; }
        
        public Card(CardRank rank, CardSuit suit) {
            Rank = rank;
            Suit = suit;
        }
        public int CompareTo(Card other) {
            if (this.Rank == other.Rank) {
                return this.Suit.CompareTo(other.Suit);
            }
            return other.Rank.CompareTo(this.Rank);
        }
    }
};