using System;
using System.Linq;
using System.Collections.Generic;

namespace PokerHandShowdown
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Card> listofCards1 = new List<Card> { 
                new Card(CardRank.Eight, CardSuit.Spade),
                new Card(CardRank.Eight, CardSuit.Diamond),
                new Card(CardRank.Ace, CardSuit.Diamond),
                new Card(CardRank.Queen, CardSuit.Diamond),
                new Card(CardRank.Jack, CardSuit.Heart)
            };
            
            List<Card> listofCards2 = new List<Card> { 
                new Card(CardRank.Ace, CardSuit.Spade),
                new Card(CardRank.Queen, CardSuit.Spade),
                new Card(CardRank.Eight, CardSuit.Spade),
                new Card(CardRank.Six, CardSuit.Spade),
                new Card(CardRank.Four, CardSuit.Spade)
            };
            
            List<Card> listofCards3 = new List<Card> { 
                new Card(CardRank.Four, CardSuit.Spade),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Three, CardSuit.Heart),
                new Card(CardRank.Queen, CardSuit.Club),
                new Card(CardRank.Eight, CardSuit.Club)
            };
            
            
            /*List<Card> listofCards1 = new List<Card> { 
                new Card(CardRank.Three, CardSuit.Heart),
                new Card(CardRank.Five, CardSuit.Diamond),
                new Card(CardRank.Nine, CardSuit.Club),
                new Card(CardRank.Nine, CardSuit.Diamond),
                new Card(CardRank.Queen, CardSuit.Heart)
            };
            
            List<Card> listofCards2 = new List<Card> { 
                new Card(CardRank.Five, CardSuit.Club),
                new Card(CardRank.Seven, CardSuit.Diamond),
                new Card(CardRank.Nine, CardSuit.Heart),
                new Card(CardRank.Nine, CardSuit.Spade),
                new Card(CardRank.Queen, CardSuit.Spade)
            };
            
            List<Card> listofCards3 = new List<Card> { 
                new Card(CardRank.Two, CardSuit.Heart),
                new Card(CardRank.Two, CardSuit.Club),
                new Card(CardRank.Five, CardSuit.Spade),
                new Card(CardRank.Ten, CardSuit.Club),
                new Card(CardRank.Ace, CardSuit.Heart)
            };
              
            */

            PokerHandShowdown pokerHandShowdown = new PokerHandShowdown(
                new List<PokerPlayer> {
                    new PokerPlayer("Joe", listofCards1),  
                    new PokerPlayer("Bob", listofCards2),
                    new PokerPlayer("Sally", listofCards3),  
                }
            );
            Console.WriteLine("{0} wins", pokerHandShowdown.GetWinner());
        }
    }

    public enum PokerHand {
        HighCard,
        OnePair,
        ThreeOfAKind,
        Flush
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
            if (this.Rank == other.Rank) {
                return this.Suit.CompareTo(other.Suit);
            }
            return other.Rank.CompareTo(this.Rank);
        }
    }

    public class CardGroup : IComparable<CardGroup> {
        public PokerHand PokerHand { get; private set; }
        public List<Card> CardList { get; private set; }
        public CardRank Rank { get; private set; }
        
        public CardGroup(PokerHand pokerHand, List<Card> cardList) {
            PokerHand = pokerHand;
            CardList = cardList;
            Rank = cardList[0].Rank;
        }
        
        public int CompareTo(CardGroup other) {
            return other.PokerHand.CompareTo(this.PokerHand);
        }
    }

    public class PokerPlayer : IComparable<PokerPlayer> {
        public string Name { get; private set; }
        public List<CardGroup> CardGroupList { get; private set; }
        
        public PokerPlayer(string name, List<Card> cardList) {
            Name = name;
            CardGroupList = HandEvaluate.generateGrouping(cardList);
        }
        
               
        public int CompareTo(PokerPlayer other) {
            var length = Math.Min(this.CardGroupList.Count, other.CardGroupList.Count);
            var index = 0;
            while(index < length) {
                var cardGroup = this.CardGroupList[index];
                var otherCardGroup = other.CardGroupList[index];
                if(otherCardGroup.PokerHand != cardGroup.PokerHand) {
                    return otherCardGroup.PokerHand.CompareTo(cardGroup.PokerHand);
                }
                if(otherCardGroup.Rank != cardGroup.Rank) {
                    return otherCardGroup.Rank.CompareTo(cardGroup.Rank);
                }
                index++;
            }
            return 0;
        }
        
        public void display() {
            Console.WriteLine("{0} => {1}", Name, CardGroupList[0].PokerHand);
            foreach(CardGroup cardGroup in CardGroupList) {
                Console.Write(" {0} => {1} => ", cardGroup.PokerHand, cardGroup.Rank);
                foreach(Card card in cardGroup.CardList) {
                    Console.Write("{0}{1} ", card.Rank, card.Suit);
                }
                Console.WriteLine(""); 
            }  
        }    
    }

    public class HandEvaluate {
        private const int NUMBER_OF_CARDS =  5;
        public static List<CardGroup> generateGrouping(List<Card> cardList) {
            if(isValidCardList(cardList)) {
                cardList.Sort();
                var cardGroupList = isFlush(cardList) 
                    ? new List<CardGroup> { new CardGroup(PokerHand.Flush, cardList )}
                    : cardList.GroupBy(card => card.Rank).Select( group => {
                        List<Card> cardListPerGroup = group.ToList();
                        if(isThreeOfAKind(cardListPerGroup)) return new CardGroup(PokerHand.ThreeOfAKind, cardListPerGroup);
                        if(isPair(cardListPerGroup)) return new CardGroup(PokerHand.OnePair, cardListPerGroup);
                        return new CardGroup(PokerHand.HighCard, cardListPerGroup);    
                }).ToList(); 
                cardGroupList.Sort();
                return cardGroupList;   
            }
            return new List<CardGroup>();
        } 

        public static bool isFlush(List<Card> cardList) {
            return cardList.GroupBy(card => card.Rank).Count() == NUMBER_OF_CARDS && cardList.GroupBy(card => card.Suit).Count() == 1;
        }
        public static bool isValidCardList(List<Card> cardList) {
            return cardList.GroupBy(card => new { card.Rank, card.Suit}).Where(group => group.Count() > 1).Count() == 0;
        }

        private static bool isThreeOfAKind(List<Card> cardList) {
            return cardList.Count() == 3;
        }

        private static bool isPair(List<Card> cardList) {
            return cardList.Count() == 2;
        }
    }

    public class PokerHandShowdown {
        public List<PokerPlayer> PokerPlayerList { get; private set; }

        public PokerHandShowdown(List<PokerPlayer> pokerPlayerList) {
            PokerPlayerList = pokerPlayerList;    
        }

        public string GetWinner() {
            PokerPlayerList.Sort();
            foreach(PokerPlayer pokerPlayer in PokerPlayerList) {
                pokerPlayer.display();    
            }
            return PokerPlayerList[0].Name;
        }
    }

    // Enumerable
    // Comparable
}

// CardRank (Two ~ Ace) => OK
// CardSuit ( Club, Spade, Heart, Diamond) => OK
// PokerHand (Flush, Three Of A Kind, One Pair, High Card) => OK
// Card ( CardRank, CardSuit) => OK
// CardsOnHand ( Array of Cards, isFlush(), isThreeOfAKind, isHighCard) => OK
// CardsOnHandEvaluator => ? (Tools/Utility class)
// Test => ?
// Validator => Just check duplicates
// Tie => ?
// HighCard => OK
// Same Cards => OK