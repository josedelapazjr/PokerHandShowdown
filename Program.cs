using System;
using System.Collections.Generic;

namespace PokerHandShowdown
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            var foobar = new List<CardsOnHand>();
            var playerCards1 = new CardsOnHand("Joe", new List<Card> { 
                    new Card(CardRank.Eight, CardSuit.Spade),
                    new Card(CardRank.Eight, CardSuit.Diamond),
                    new Card(CardRank.Ace, CardSuit.Diamond),
                    new Card(CardRank.Queen, CardSuit.Diamond),
                    new Card(CardRank.Jack, CardSuit.Heart),
                }
            );
            var playerCards2 = new CardsOnHand("Bob", new List<Card> { 
                    new Card(CardRank.Ace, CardSuit.Spade),
                    new Card(CardRank.Queen, CardSuit.Spade),
                    new Card(CardRank.Eight, CardSuit.Spade),
                    new Card(CardRank.Six, CardSuit.Spade),
                    new Card(CardRank.Four, CardSuit.Spade),
                }
            );
            var playerCards3 = new CardsOnHand("Sally", new List<Card> { 
                    new Card(CardRank.Four, CardSuit.Spade),
                    new Card(CardRank.Four, CardSuit.Heart),
                    new Card(CardRank.Three, CardSuit.Heart),
                    new Card(CardRank.Queen, CardSuit.Club),
                    new Card(CardRank.Eight, CardSuit.Club),
                }
            );
            new CardsOnHandEvaluator(new List<CardsOnHand> { 
                playerCards1, 
                playerCards2,
                playerCards3 
            });
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

    public class Card : IComparable<Card> {
        public CardSuit Suit { get; private set; }
        public CardRank Rank { get; private set; }
        
        public Card(CardRank rank, CardSuit suit) {
            Rank = rank;
            Suit = suit;
        }
        public int CompareTo(Card other) {
            // Alphabetic sort if salary is equal. [A to Z]
            if (this.Rank == other.Rank) {
                return this.Suit.CompareTo(other.Suit);
            }
            // Default to salary sort. [High to low]
            return other.Rank.CompareTo(this.Rank);
        }
    }

    public class CardsOnHand {
        public List<Card> Cards {get; set;}
        public string Name {get; set;}

        public CardsOnHand(string name, List<Card> cards) {
            Cards = cards;
            Name = name;
        }
    }

    public class CardsOnHandEvaluator {
        public List<CardsOnHand> CardsOnHandList {get; set;}
        public CardsOnHandEvaluator(List<CardsOnHand> cardsOnHandList) {
            CardsOnHandList = cardsOnHandList;
            Console.WriteLine("CardsOnHandEvaluator!"); 
            foreach( CardsOnHand cardsOnHand in cardsOnHandList) {
                Console.Write("{0} => ", cardsOnHand.Name);   
                cardsOnHand.Cards.Sort();  
                foreach( Card card in cardsOnHand.Cards) {
                    Console.Write("{0}{1} ", card.Rank, card.Suit);
                }
                Console.WriteLine("");   
            }  
        }
    }

    // Enumerable
    // Comparable
}

// CardRank (Two ~ Ace) => OK
// CardSuit ( Club, Spade, Heart, Diamond) => OK
// PokerHand (Flush, Three Of A Kind, One Pair, High Card) => OK
// Card ( CardRank, CardSuit) => OK
// CardsOnHand ( Array of Cards, isFlush(), isThreeOfAKind, isHighCard)
// CardsOnHandEvaluator