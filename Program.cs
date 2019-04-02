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
}

// CardRank (Two ~ Ace) => OK
// CardSuit ( Club, Spade, Heart, Diamond) => OK
// PokerHand (Flush, Three Of A Kind, One Pair, High Card) => OK
// Card ( CardRank, CardSuit) => OK
// CardsOnHand ( Array of Cards, isFlush(), isThreeOfAKind, isHighCard) => OK
// CardsOnHandEvaluator => ? (Tools/Utility class)
// Test => OK
// Validator => OK
// Tie => ?
// HighCard => OK
// Same Cards => OK