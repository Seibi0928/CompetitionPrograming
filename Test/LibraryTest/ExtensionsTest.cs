using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using CompetitionPrograming2.Library;

namespace Test.LibraryTest
{
    public class ExtensionsTest
    {
        public class NextPermutationTest
        {
            [Fact]
            public void 次の辞書順の組み合わせを取得できること()
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
            public void 次の辞書順の組み合わせを取得できること2()
            {
                var tmp = new int[] { 2, 3, 1, 4 };
                Assert.Equal(new int[] { 2, 3, 4, 1 }, tmp.NextPermutation());
            }

            [Fact]
            public void 降順のとき次の辞書順の組み合わせは存在しないのでnullが返されること()
            {
                Assert.Null(new int[] { 3, 2, 1 }.NextPermutation());
            }
        }
        

        public class PermutationsTest
        {
            [Fact]
            public void 順列を引数にした場合全ての組み合わせが辞書順で列挙されること()
            {
                var collections = new int[] { 1, 2, 3 }.Permutations();
                Assert.Equal(new int[] { 1, 3, 2 }, collections.ElementAt(0));
                Assert.Equal(new int[] { 2, 1, 3 }, collections.ElementAt(1));
                Assert.Equal(new int[] { 2, 3, 1 }, collections.ElementAt(2));
                Assert.Equal(new int[] { 3, 1, 2 }, collections.ElementAt(3));
                Assert.Equal(new int[] { 3, 2, 1 }, collections.ElementAt(4));
            }

            [Fact]
            public void 引数以降の組み合わせが辞書順で列挙されること()
            {
                var collections = new int[] { 1, 3, 2 }.Permutations();
                Assert.Equal(new int[] { 2, 1, 3 }, collections.ElementAt(0));
                Assert.Equal(new int[] { 2, 3, 1 }, collections.ElementAt(1));
            }
        }
    }
}
