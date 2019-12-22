using CompetitionPrograming2.Library;
using Xunit;

namespace Test.LibraryTest
{
    public class CombinationTest
    {
        readonly Combination comb;
        public CombinationTest()
        {
            comb = new Combination(4000, 10000007);
        }

        [Fact]
        public void 組み合わせ数を取得できる()
        {
            Assert.Equal(1, comb.Get(1, 1));
            Assert.Equal(1, comb.Get(5, 0));
            Assert.Equal(5, comb.Get(5, 1));
            Assert.Equal(10, comb.Get(5, 2));
            Assert.Equal(10, comb.Get(5, 3));
            Assert.Equal(5, comb.Get(5, 4));
            Assert.Equal(1, comb.Get(5, 5));
        }

        [Fact]
        public void 境界値チェック()
        {
            Assert.Equal(1, comb.Get(4000, 0));
            Assert.Equal(4000, comb.Get(4000, 1));
            Assert.Equal(1, comb.Get(4000, 4000));
        }
    }
}
