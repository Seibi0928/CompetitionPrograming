using System.Linq;

namespace CompetitionPrograming2.Library
{
    public class UnionFind
    {
        // 子は親のIDを正で持つ 根は木のサイズを負で持つ
        private readonly int[] d;
        public UnionFind(int n = 0)
        {
            // 初めはすべてが根
            d = Enumerable.Repeat(-1, n).ToArray();
        }

        /// <summary>
        /// 集合のIDを返す
        /// </summary>
        /// <param name="x">ノード</param>
        /// <returns>集合のID</returns>
        public int Find(int x)
        {
            // xが親だった場合
            if (d[x] < 0) { return x; }

            return d[x] = Find(d[x]);
        }

        /// <summary>
        /// 両引数が属する集合同士を連結する
        /// </summary>
        /// <param name="x">ノード1</param>
        /// <param name="y">ノード1</param>
        /// <returns>連結されたかどうか</returns>
        public bool Unite(int x, int y)
        {
            x = Find(x); y = Find(y);
            
            if (x == y) { return false; }

            // yをxへ連結するが、サイズが小さい方の木を大きい方の木へ連結すべきなので
            // size(y) > size(x)ならばswapする
            // サイズを表すd[x] d[y]は両方とも負なので、不等号の向きに注意
            if (d[x] > d[y]) { Swap(ref x, ref y); }

            d[x] += d[y];
            d[y] = x;
            return true;
        }

        /// <summary>
        /// 両引数が属する集合が同じかどうか
        /// </summary>
        /// <param name="x">ノード1</param>
        /// <param name="y">ノード2</param>
        /// <returns></returns>
        public bool Same(int x, int y) => Find(x) == Find(y);

        /// <summary>
        /// 集合の大きさを返す
        /// </summary>
        /// <param name="x">ノード</param>
        /// <returns>集合の大きさ</returns>
        public int Size(int x) => -d[Find(x)];
        
        private static void Swap<T>(ref T item1, ref T item2)
        {
            var tmp = item1;
            item1 = item2;
            item2 = tmp;
        }
    }
}
