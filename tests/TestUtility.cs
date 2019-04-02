using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
namespace PokerHandShowdown
{
    public class TestUtility {
        private static Dictionary<string, CardRank> RANK_MAPPING = new Dictionary<string, CardRank> {
            { "2", CardRank.Two},
            { "3", CardRank.Three},
            { "4", CardRank.Four},
            { "5", CardRank.Five},
            { "6", CardRank.Six},
            { "7", CardRank.Seven},
            { "8", CardRank.Eight},
            { "9", CardRank.Nine},
            { "10", CardRank.Ten},
            { "J", CardRank.Jack},
            { "Q", CardRank.Queen},
            { "K", CardRank.King},
            { "A", CardRank.Ace},    
        
        };

        private static Dictionary<string, CardSuit> SUIT_MAPPING = new Dictionary<string, CardSuit> {
            { "S", CardSuit.Spade},
            { "D", CardSuit.Diamond},
            { "C", CardSuit.Club},
            { "H", CardSuit.Heart},
        };

        public static List<Card> convertCards(string cards) {
            return cards.Split(",").Select(card => {
                card.Trim();
                return new Card(RANK_MAPPING[card.Substring(0, card.Length - 1).Trim()], SUIT_MAPPING[card.Substring(card.Length - 1, 1).Trim()]);
            }).ToList();
        }    
    }
}