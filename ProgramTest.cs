using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
namespace PokerHandShowdown
{
    [TestFixture]
    class TestTest {
        private Dictionary<string, CardRank> RANK_MAPPING = new Dictionary<string, CardRank> {
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

        private Dictionary<string, CardSuit> SUIT_MAPPING = new Dictionary<string, CardSuit> {
            { "S", CardSuit.Spade},
            { "D", CardSuit.Diamond},
            { "C", CardSuit.Club},
            { "H", CardSuit.Heart},
        };

        private List<Card> convertCards(string cards) {
            return cards.Split(",").Select(card => {
                card.Trim();
                return new Card(RANK_MAPPING[card.Substring(0, card.Length - 1).Trim()], SUIT_MAPPING[card.Substring(card.Length - 1, 1).Trim()]);
            }).ToList();
        }
        [TestCase( "AS, QS, 8S, 6S, 4S", true)]
        [TestCase( "AS, AD, 8S, 6S, 4S", false)]
        [TestCase( "2S, 2D, 2C, 6S, 4S", false)]
        public void shouldReturnCorrectIsFlush(string cards, bool result) {
            Assert.AreEqual(HandEvaluate.isFlush(convertCards(cards)), result);
        }

        [TestCase( "AS, QS, 8S, 6S, 4S", true)]
        [TestCase( "AS, AD, AD, 6S, 4S", false)]
        public void shouldReturnCorrectisValidCardList(string cards, bool result) {
            Assert.AreEqual(HandEvaluate.isFlush(convertCards(cards)), result);
        }
        
        [TestCase( "4S, 4H, 3H, QC, 8C")]
        public void shouldReturnCorrectGenerateGroupingWithPair(string cards) {
            List<Card> cardList = convertCards(cards);
            List<CardGroup> cardGroupList = HandEvaluate.generateGrouping(cardList);
            Assert.AreEqual(cardGroupList.Count, 4);
            Assert.AreEqual(cardGroupList[0].CardList.Count, 2);
            Assert.AreEqual(cardGroupList[1].CardList.Count, 1);
            Assert.AreEqual(cardGroupList[2].CardList.Count, 1);
            Assert.AreEqual(cardGroupList[3].CardList.Count, 1);
        }

        [TestCase( "4H, 2H, JH, QH, 8H")]
        public void shouldReturnCorrectGenerateGroupingWithFlush(string cards) {
            List<Card> cardList = convertCards(cards);
            List<CardGroup> cardGroupList = HandEvaluate.generateGrouping(cardList);
            Assert.AreEqual(cardGroupList.Count, 1);
            Assert.AreEqual(cardGroupList[0].CardList.Count, 5);
        }

        [TestCase( "4H, 2C, JH, QS, 8D")]
        public void shouldReturnCorrectGenerateGroupingWithHighCards(string cards) {
            List<Card> cardList = convertCards(cards);
            List<CardGroup> cardGroupList = HandEvaluate.generateGrouping(cardList);
            Assert.AreEqual(cardGroupList.Count, 5);
            Assert.AreEqual(cardGroupList[0].CardList.Count, 1);
        }

        [TestCase( "4H, 4C, JH, 4S, 8D")]
        public void shouldReturnCorrectGenerateGroupingWithThreeOfAKind(string cards) {
            List<Card> cardList = convertCards(cards);
            List<CardGroup> cardGroupList = HandEvaluate.generateGrouping(cardList);
            Assert.AreEqual(cardGroupList.Count, 3);
            Assert.AreEqual(cardGroupList[0].CardList.Count, 3);
            Assert.AreEqual(cardGroupList[1].CardList.Count, 1);
            Assert.AreEqual(cardGroupList[2].CardList.Count, 1);
        }
    }
}
