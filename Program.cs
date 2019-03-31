using System;

namespace PokerHandShowdown
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            new Test();
        }
    }

    public enum PokerHand {
        Flush,
        ThreeOfAKind,
        OnePair,
        HighCard
    }

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

    public class Card {
        public CardSuit Suit { get; private set; }
        public CardRank Rank { get; private set; }
        
        public Card(CardSuit suit, CardRank rank) {
            Suit = suit;
            Rank = rank;
        }
    }

    public class Test {
        public Test() {
            Console.WriteLine("Hello world Jose!");    
        }
    }

    // Enumerable
    // Comparable
}
