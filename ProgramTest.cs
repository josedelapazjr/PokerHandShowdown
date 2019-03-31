using NUnit.Framework;
namespace PokerHandShowdown
{
    [TestFixture]
    class TestTest {
        [TestCase(2,4,6)]
        [TestCase(1,2,3)]
        public void shouldFoobar(int x, int y, int z) {
            Assert.AreEqual(z, x+y);
        }
    }
}
