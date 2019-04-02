using NUnit.Framework;
// using System.Linq;
using System.Collections.Generic;
namespace PokerHandShowdown
{
    [TestFixture]
    class HandEvaluateToolTest {

        [TestCase( "AS, QS, 8S, 6S, 4S", true)]
        [TestCase( "AS, AD, 8S, 6S, 4S", false)]
        [TestCase( "2S, 2D, 2C, 6S, 4S", false)]
        public void shouldReturnCorrectIsFlush(string cards, bool result) {
            Assert.AreEqual(PokerHandEvaluateTool.isFlush(TestUtility.convertCards(cards)), result);
        }

        [TestCase( "AS, QS, 8S, 6S, 4S", true)]
        [TestCase( "AS, AD, AD, 6S, 4S", false)]
        public void shouldReturnCorrectisValidCardList(string cards, bool result) {
            Assert.AreEqual(PokerHandEvaluateTool.isFlush(TestUtility.convertCards(cards)), result);
        }
        
        [TestCase( "4S, 4H, 3H, QC, 8C", 4, 2, 1, 1, 1, 0)] // One Pair
        [TestCase( "4H, 2H, JH, QH, 8H", 1, 5, 0, 0, 0, 0)] // Flush
        [TestCase( "4H, 2C, JH, QS, 8D", 5, 1, 1, 1, 1, 1)] // HighCards
        [TestCase( "4H, 4C, JH, 4S, 8D", 3, 3, 1, 1, 0, 0)] // Three of a Kind
        public void shouldReturnCorrectGenerateGrouping(string cards, int totalCount, int count1, int count2, int count3, int count4, int count5) {
            List<Card> cardList = TestUtility.convertCards(cards);
            List<CardGroup> cardGroupList = PokerHandEvaluateTool.generateCardGrouping(cardList);
            Assert.AreEqual(cardGroupList.Count, totalCount);
            Assert.AreEqual(cardGroupList[0].CardList.Count, count1);
            if(count2 > 0) {
                Assert.AreEqual(cardGroupList[1].CardList.Count, count2);
            }
            if(count3 > 0) {
                Assert.AreEqual(cardGroupList[2].CardList.Count, count3);
            }
            if(count4 > 0) {
                Assert.AreEqual(cardGroupList[3].CardList.Count, count4);
            }
            if(count5 > 0) {
                Assert.AreEqual(cardGroupList[4].CardList.Count, count5);
            }
        }
    }
}
