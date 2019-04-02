using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
namespace PokerHandShowdown
{
    [TestFixture]
    class PokerHandShowdownTest {

        [TestCase( new object[] {"QD, 8D, KD, 7D, 3D", "AS, QS, 8S, 6S, 4S", "4S, 4H, 3H, QC, 8C"}, new object[] {"2nd Player"})]
        [TestCase( new object[] {"3H, 5D, 9C, 9D, QH", "2H, 2C, 5S, 10C, AH", "5C, 7D, 9H, 9S, QS"}, new object[] {"3rd Player"})]
        [TestCase( new object[] {"5C, 7D, 8H, 9S, QD", "2H, 3D, 4C, 5D, 10H", "2C, 4D, 5S, 10C, JH"}, new object[] {"1st Player"})]
        [TestCase( new object[] {"4D, 5S, 3C, 2S, JD", "2H, 3D, 4C, 5D, 10H", "4S, 5D, 3H, 2D, JS"}, new object[] {"1st Player", "3rd Player"})]
        
        public void shouldReturnCorrectWinner(object[] cards, object[] expectedWinner) {
            List<PokerPlayer> pokerPlayerList = new List<PokerPlayer> {
                new PokerPlayer("1st Player", TestUtility.convertCards(cards[0].ToString())),
                new PokerPlayer("2nd Player", TestUtility.convertCards(cards[1].ToString())),
                new PokerPlayer("3rd Player", TestUtility.convertCards(cards[2].ToString())),
            };

            List<string> result = PokerHandShowdown.GetWinners(pokerPlayerList);
            Assert.AreEqual(result.Count, expectedWinner.Count());
            for(var index = 0; index < result.Count; index ++) {
               Assert.AreEqual(result[index], expectedWinner[index]);
            }
        }
    }
}
