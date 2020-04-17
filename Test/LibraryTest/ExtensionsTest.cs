using System.Linq;
using CompetitionPrograming2;
using Xunit;

namespace Test.LibraryTest
{
    public class ExtensionsTest
    {
        public class NextPermutationTest
        {
            [Fact]
            public void 数値の場合_次の辞書順の組み合わせを取得できること()
            {
                var tmp = new int[] { 1, 2, 3 };
                Assert.Equal(new int[] { 1, 3, 2 }, tmp.NextPermutation());

                tmp = new int[] { 1, 3, 2 };
                Assert.Equal(new int[] { 2, 1, 3 }, tmp.NextPermutation());

                tmp = new int[] { 2, 1, 3 };
                Assert.Equal(new int[] { 2, 3, 1 }, tmp.NextPermutation());

                tmp = new int[] { 2, 3, 1 };
                Assert.Equal(new int[] { 3, 1, 2 }, tmp.NextPermutation());

                tmp = new int[] { 3, 1, 2 };
                Assert.Equal(new int[] { 3, 2, 1 }, tmp.NextPermutation());
            }

            [Fact]
            public void 数値の場合_次の辞書順の組み合わせを取得できること2()
            {
                var tmp = new int[] { 2, 3, 1, 4 };
                Assert.Equal(new int[] { 2, 3, 4, 1 }, tmp.NextPermutation());
            }

            [Fact]
            public void 数値の場合_降順のとき次の辞書順の組み合わせは存在しないのでnullが返されること()
            {
                Assert.Null(new int[] { 3, 2, 1 }.NextPermutation());
            }

            [Fact]
            public void 文字列の場合_次の辞書順の組み合わせを取得できること()
            {
                var tmp = new string[] { "a", "b", "c" };
                Assert.Equal(new string[] { "a", "c", "b" }, tmp.NextPermutation());

                tmp = new string[] { "a", "c", "b" };
                Assert.Equal(new string[] { "b", "a", "c" }, tmp.NextPermutation());

                tmp = new string[] { "b", "a", "c" };
                Assert.Equal(new string[] { "b", "c", "a" }, tmp.NextPermutation());

                tmp = new string[] { "b", "c", "a" };
                Assert.Equal(new string[] { "c", "a", "b" }, tmp.NextPermutation());

                tmp = new string[] { "c", "a", "b" };
                Assert.Equal(new string[] { "c", "b", "a" }, tmp.NextPermutation());
            }

            [Fact]
            public void 文字列の場合_数値の場合_次の辞書順の組み合わせを取得できること2()
            {
                var tmp = new string[] { "c", "d", "b", "e" };
                Assert.Equal(new string[] { "c", "d", "e", "b" }, tmp.NextPermutation());
            }

            [Fact]
            public void 文字列の場合_降順のとき次の辞書順の組み合わせは存在しないのでnullが返されること()
            {
                Assert.Null(new string[] { "c", "b", "a" }.NextPermutation());
            }
        }
        
        public class PermutationsTest
        {
            [Fact]
            public void 数値の場合_順列を引数にした場合全ての組み合わせが辞書順で列挙されること()
            {
                var collections = new int[] { 1, 2, 3 }.Permutations();
                Assert.Equal(new int[] { 1, 3, 2 }, collections.ElementAt(0));
                Assert.Equal(new int[] { 2, 1, 3 }, collections.ElementAt(1));
                Assert.Equal(new int[] { 2, 3, 1 }, collections.ElementAt(2));
                Assert.Equal(new int[] { 3, 1, 2 }, collections.ElementAt(3));
                Assert.Equal(new int[] { 3, 2, 1 }, collections.ElementAt(4));
            }

            [Fact]
            public void 数値の場合_引数以降の組み合わせが辞書順で列挙されること()
            {
                var collections = new int[] { 1, 3, 2 }.Permutations();
                Assert.Equal(new int[] { 2, 1, 3 }, collections.ElementAt(0));
                Assert.Equal(new int[] { 2, 3, 1 }, collections.ElementAt(1));
            }

            [Fact]
            public void 文字列の場合_順列を引数にした場合全ての組み合わせが辞書順で列挙されること()
            {
                var collections = new string[] { "b", "c", "d" }.Permutations();
                Assert.Equal(new string[] { "b", "d", "c" }, collections.ElementAt(0));
                Assert.Equal(new string[] { "c", "b", "d" }, collections.ElementAt(1));
                Assert.Equal(new string[] { "c", "d", "b" }, collections.ElementAt(2));
                Assert.Equal(new string[] { "d", "b", "c" }, collections.ElementAt(3));
                Assert.Equal(new string[] { "d", "c", "b" }, collections.ElementAt(4));
            }

            [Fact]
            public void 文字列の場合_引数以降の組み合わせが辞書順で列挙されること()
            {
                var collections = new string[] { "a", "c", "b" }.Permutations();
                Assert.Equal(new string[] { "b", "a", "c" }, collections.ElementAt(0));
                Assert.Equal(new string[] { "b", "c", "a" }, collections.ElementAt(1));
            }
        }

        public class ChooseTest
        {
            [Fact]
            public void 組み合わせ数を取得できること()
            {
                var num = 4;
                Assert.Equal(6, num.Choose(2));
            }
        }
    }
}
