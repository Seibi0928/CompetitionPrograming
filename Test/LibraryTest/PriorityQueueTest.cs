using CompetitionPrograming2;
using CompetitionPrograming2.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Test.LibraryTest
{
    public class PriorityQueueTest : IDisposable
    {
        readonly List<int> sourceList = new List<int> { 3, 5, 2, 1, 6, 7, 9, 8, 0, 4 };
        readonly PriorityQueue<int> dscQue = new PriorityQueue<int>(Priority.Larger);
        readonly PriorityQueue<int> ascQue = new PriorityQueue<int>(Priority.Smaller);

        public PriorityQueueTest()
        {
            dscQue.EnqueueRange(sourceList);
            ascQue.EnqueueRange(sourceList);
        }

        [Fact]
        public void 降順設定の場合中身を列挙するとき大きいもの順で出てくる()
        {
            var prev = int.MaxValue;
            for (int i = 0; i < sourceList.Count; i++)
            {
                Assert.True(prev > dscQue.Peek());
                prev = dscQue.Dequeue();
            }
        }

        [Fact]
        public void 昇順設定の場合中身を列挙するとき小さいもの順で出てくる()
        {
            var prev = int.MinValue;
            for (int i = 0; i < sourceList.Count; i++)
            {
                Assert.True(prev < ascQue.Peek());
                prev = ascQue.Dequeue();
            }
        }

        [Fact]
        public void 一括登録機能を使用した際とそうでない場合も同じ()
        {
            var q = new PriorityQueue<int>(Priority.Larger);
            q.EnqueueRange(sourceList);
            Assert.Equal(dscQue.Count(), q.Count());
            for (int i = 0; i < sourceList.Count; i++)
            {
                Assert.Equal(dscQue.Dequeue(), q.Dequeue());
            }
        }

        [Fact]
        public void 正しい要素数を返す()
        {
            Assert.Equal(sourceList.Count, dscQue.Count());
        }

        [Fact]
        public void 要素を削除できる()
        {
            dscQue.Dequeue();
            Assert.Equal(sourceList.Count - 1, dscQue.Count());
        }

        [Fact]
        public void 降順設定の場合要素を削除するとき一番大きい値が削除される()
        {
            Assert.Equal(sourceList.Max(), dscQue.Dequeue());
        }

        [Fact]
        public void 昇順設定の場合要素を削除するとき一番小さい値が削除される()
        {
            Assert.Equal(sourceList.Min(), ascQue.Dequeue());
        }

        [Fact]
        public void 降順設定の場合要素を削除したときも大きいもの順で残りの要素が列挙される()
        {
            dscQue.Dequeue();
            var prev = int.MaxValue;
            for (int i = 0; i < dscQue.Count(); i++)
            {
                Assert.True(prev > dscQue.Peek());
                prev = dscQue.Dequeue();
            }
        }

        [Fact]
        public void 昇順設定の場合要素を削除したときも小さいもの順で残りの要素が列挙される()
        {
            ascQue.Dequeue();
            var prev = int.MinValue;
            for (int i = 0; i < ascQue.Count(); i++)
            {
                Assert.True(prev < ascQue.Peek());
                prev = ascQue.Dequeue();
            }
        }

        [Fact]
        public void 要素が0のとき取り出そうとするとエラー()
        {
            try
            {
                for (int i = 0; i <= sourceList.Count; i++)
                {
                    dscQue.Dequeue();
                }
            }
            catch (Exception ex)
            {
                Assert.Equal("要素が空です", ex.Message);
            }
            try
            {
                dscQue.Peek();
            }
            catch (Exception ex)
            {
                Assert.Equal("要素が空です", ex.Message);
            }
        }

        [Fact]
        public void LINQを使用できる()
        {
            var result = dscQue.Where(q => q < 5).OrderBy(o => o);
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(i, result.ElementAt(i));
            }
            Assert.Equal((0 + 4) * 5 / 2, result.Sum());
        }

        [Fact]
        public void リストに変換できその中の要素も正しい()
        {
            Assert.Equal(typeof(List<int>), dscQue.ToList().GetType());
            Assert.Equal(sourceList.Count, dscQue.ToList().Count);
        }

        [Fact]
        public void 配列に変換できその中の要素も正しい()
        {
            Assert.Equal(typeof(int[]), dscQue.ToArray().GetType());
            Assert.Equal(sourceList.Count, dscQue.ToList().Count);
        }

        [Fact]
        public void クリアすると中身がなくなる()
        {
            ascQue.Clear();
            Assert.False(ascQue.Any());
        }

        public void Dispose() { }
    }
}
