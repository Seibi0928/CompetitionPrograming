using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace CompetitionPrograming2
{
    public sealed class Program : BaseProgram
    {
        public static void Main(string[] _) { using (new SetConsole()) { Solve(); } }
        public static void Solve()
        {            
        }
    }
    public abstract class BaseProgram
    {
        protected readonly static long divisor = 1000000007;
        protected static Action<object> Write => Console.WriteLine;
        protected static string GetString()
        {
            var str = Console.ReadLine();
            if (str == null) { throw new NullReferenceException("標準入力がnullです Solveメソッド内の解答コードが間違っています"); }
            return str;
        }
        protected static T GetNumber<T>() where T : IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
        {
            var str = GetString();
            var t = typeof(T);
            try
            {
                if (t == typeof(int))
                {
                    return (T)(object)str.ToInt();
                }
                else if (t == typeof(long))
                {
                    return (T)(object)str.ToLong();
                }
                else if (t == typeof(double))
                {
                    return (T)(object)str.ToDouble();
                }
                else if (t == typeof(decimal))
                {
                    return (T)(object)str.ToDecimal();
                }
                else if (t == typeof(BigInteger))
                {
                    return (T)(object)str.ToBigInteger();
                }
            }
            catch (OverflowException)
            {
                throw new OverflowException("より大きい数値型を指定してください");
            }
            throw new NotSupportedException();
        }
        protected static T[] GetArray<T>() where T : IComparable, IComparable<T>, IConvertible, IEquatable<T> => ToArray<T>(GetString());
        protected static List<T> GetList<T>() where T : IComparable, IComparable<T>, IConvertible, IEquatable<T> => ToList<T>(GetString());
        protected static void Swap<T>(ref T item1, ref T item2)
        {
            var tmp = item1;
            item1 = item2;
            item2 = tmp;
        }
        protected static IEnumerable<char> AtoZ()
        {
            for (char i = 'a'; i <= 'z'; i++)
            {
                yield return i;
            }
        }
        private static T[] ToArray<T>(string str) where T : IComparable, IComparable<T>, IConvertible, IEquatable<T>
        {
            return ConvertEnumerator<T>(str).ToArray();
        }
        private static List<T> ToList<T>(string str) where T : IComparable, IComparable<T>, IConvertible, IEquatable<T>
        {
            if (typeof(T) == typeof(string)) { return (List<T>)(object)str.Split().ToList(); }

            return ConvertEnumerator<T>(str).ToList();
        }
        private static IEnumerable<T> ConvertEnumerator<T>(string str) where T : IComparable, IComparable<T>, IConvertible, IEquatable<T>
        {
            var t = typeof(T);
            if (t == typeof(byte))
            {
                return str.Split().Select(byte.Parse).Cast<T>();
            }
            if (t == typeof(int))
            {
                return str.Split().Select(int.Parse).Cast<T>();
            }
            if (t == typeof(long))
            {
                return str.Split().Select(long.Parse).Cast<T>();
            }
            if (t == typeof(double))
            {
                return str.Split().Select(double.Parse).Cast<T>();
            }
            if (t == typeof(decimal))
            {
                return str.Split().Select(decimal.Parse).Cast<T>();
            }
            if (t == typeof(BigInteger))
            {
                return str.Split().Select(BigInteger.Parse).Cast<T>();
            }
            throw new NotSupportedException();
        }
        protected sealed class SetConsole : IDisposable
        {
            readonly StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            public SetConsole()
            {
                sw.AutoFlush = false;
                Console.SetOut(sw);
            }
            public void Dispose()
            {
                Console.Out.Flush();
                sw.AutoFlush = true;
                Console.SetOut(sw);
            }
        }
    }
    public static class ExtentionsLibrary
    {
        public static long Choose(this int n, int a, long divisor = 1000000007)
        {
            long numerator = 1, denominator = 1;
            for (int i = 0; i < a; i++)
            {
                numerator *= n - i;
                numerator %= divisor;
                denominator *= i + 1;
                denominator %= divisor;
            }
            return numerator / denominator;
        }
        /// <summary>
        /// 階乗を求める
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static long Factorial(this long num)
        {
            var result = 1L;
            for (int i = 1; i <= num; i++)
            {
                result *= i;
            }
            return result;
        }
        private static T[] NextPermutation<T>(this IEnumerable<T> collection, IComparer<T> cmp) where T : IComparable
        {
            var array = collection.ToArray();
            int? exchangingNumIndex = null;
            for (int i = 1; i < array.Length; i++)
            {
                if (cmp.Compare(array[i - 1], array[i]) >= 0) { continue; }

                exchangingNumIndex = i - 1;
            }

            if (exchangingNumIndex == null) { return null; }

            for (int j = array.Length - 1; j >= 0; j--)
            {
                if (cmp.Compare(array[(int)exchangingNumIndex], array[j]) >= 0) { continue; }

                var tmp = array[j];
                array[j] = array[(int)exchangingNumIndex];
                array[(int)exchangingNumIndex] = tmp;
                array = array.Take((int)exchangingNumIndex + 1).Concat(array.Skip((int)exchangingNumIndex + 1).Reverse()).ToArray();
                break;
            }
            return array;
        }
        public static string[] NextPermutation(this IEnumerable<string> collection)
        {
            return NextPermutation(collection, StringComparer.Ordinal);
        }
        public static T[] NextPermutation<T>(this IEnumerable<T> collection) where T : IComparable
        {
            return NextPermutation(collection, Comparer<T>.Default);
        }
        public static IEnumerable<T[]> Permutations<T>(this IEnumerable<T> collection) where T : IComparable
        {
            var next = collection.NextPermutation();

            while (next != null)
            {
                yield return next;

                next = next.NextPermutation();
            }
        }
        public static long Gcd(this long a, long b)
        {
            if (a < b) { return Gcd(b, a); }
            long tmp;
            do
            {
                tmp = a % b;
                a = b;
                b = tmp;
            } while (tmp != 0);
            return a;
        }
        /// <summary>
        /// 素因数分解を行う
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static IEnumerable<Tuple<long, int>> Factorize(this long n)
        {
            yield return Tuple.Create(1L, 1);
            var rootN = Math.Sqrt(n);
            for (long i = 2; i <= rootN; i++)
            {
                if (n % i != 0) { continue; }

                var count = 1;
                n /= i;
                while (n % i == 0)
                {
                    n /= i;
                    count++;
                }
                yield return Tuple.Create(i, count);
            }
            if (n != 1) { yield return Tuple.Create(n, 1); }
        }
        public static int ToInt(this string str) => int.Parse(str);
        public static int ToInt(this char chr) => int.Parse(chr.ToString());
        public static long ToLong(this string str) => long.Parse(str);
        public static double ToDouble(this string str) => double.Parse(str);
        public static decimal ToDecimal(this string str) => decimal.Parse(str);
        public static BigInteger ToBigInteger(this string str) => BigInteger.Parse(str);
        public static DateTime ToDateTime(this string str) => DateTime.Parse(str);
        public static string StringJoin<T>(this IEnumerable<T> collection, string separator = "") => string.Join(separator, collection.Select(c => c.ToString()));
        public static string StringConcat(this IEnumerable<char> collection) => string.Concat(collection);
        public static int LowerBound<T>(this IReadOnlyList<T> a, T v) => LowerBound(a, v, Comparer<T>.Default);
        public static int LowerBound(this IReadOnlyList<string> str, string v) => LowerBound(str, v, StringComparer.Ordinal);
        public static int LowerBound<T>(this IReadOnlyList<T> a, T v, IComparer<T> cmp)
        {
            var l = 0;
            var r = a.Count - 1;
            while (l <= r)
            {
                var mid = l + (r - l) / 2;
                var result = cmp.Compare(a[mid], v);
                if (result == -1)
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }
            return l;
        }
        public static int UpperBound(this IReadOnlyList<string> str, string v) => UpperBound(str, v, StringComparer.Ordinal);
        public static int UpperBound<T>(this IReadOnlyList<T> a, T v) => UpperBound(a, v, Comparer<T>.Default);
        public static int UpperBound<T>(this IReadOnlyList<T> a, T v, IComparer<T> cmp)
        {
            var l = 0;
            var r = a.Count - 1;
            while (l <= r)
            {
                var mid = l + (r - l) / 2;
                var res = cmp.Compare(a[mid], v);
                if (res <= 0) l = mid + 1;
                else r = mid - 1;
            }
            return l;
        }
        public static IOrderedEnumerable<TSource> OrderBy<TSource>(this IEnumerable<TSource> source, Func<TSource, string> keySelector)
        {
            return source.OrderBy(keySelector, StringComparer.Ordinal);
        }
        public static IOrderedEnumerable<TSource> OrderByDescending<TSource>(this IEnumerable<TSource> source, Func<TSource, string> keySelector)
        {
            return source.OrderByDescending(keySelector, StringComparer.Ordinal);
        }
        public static void Deconstruct<T>
        (
            this IList<T> self,
            out T first,
            out IList<T> rest
        )
        {
            first = self.Count > 0 ? self[0] : default;
            rest = self.Skip(1).ToArray();
        }

        public static void Deconstruct<T>
        (
            this IList<T> self,
            out T first,
            out T second,
            out IList<T> rest
        )
        {
            first = self.Count > 0 ? self[0] : default;
            second = self.Count > 1 ? self[1] : default;
            rest = self.Skip(2).ToArray();
        }

        public static void Deconstruct<T>
        (
            this IList<T> self,
            out T first,
            out T second,
            out T third,
            out IList<T> rest
        )
        {
            first = self.Count > 0 ? self[0] : default;
            second = self.Count > 1 ? self[1] : default;
            third = self.Count > 2 ? self[2] : default;
            rest = self.Skip(3).ToArray();
        }

        public static void Deconstruct<T>
        (
            this IList<T> self,
            out T first,
            out T second,
            out T third,
            out T four,
            out IList<T> rest
        )
        {
            first = self.Count > 0 ? self[0] : default;
            second = self.Count > 1 ? self[1] : default;
            third = self.Count > 2 ? self[2] : default;
            four = self.Count > 3 ? self[3] : default;
            rest = self.Skip(4).ToArray();
        }
    }

    public struct Mint
    {
        private static readonly long MOD = (long)1e9 + 7;

        /// <summary>
        /// 0以上MOD未満の整数
        /// </summary>
        public long Value;

        public Mint(long val)
        {
            Value = val % MOD;
            if (Value < 0) Value += MOD;
        }

        private static Mint Ctor(long val) => new Mint() { Value = val };
        public static Mint operator +(Mint a, Mint b)
        {
            long res = a.Value + b.Value;
            if (res > MOD) res -= MOD;
            return Ctor(res);
        }
        public static Mint operator -(Mint a, Mint b)
        {
            long res = a.Value - b.Value;
            if (res < 0) res += MOD;
            return Ctor(res);
        }
        public static Mint operator *(Mint a, Mint b)
        {
            long res = a.Value * b.Value;
            if (res > MOD) res %= MOD;
            return Ctor(res);
        }
        public static Mint operator /(Mint a, Mint b) => a * Inv(b);
        public static Mint Pow(Mint a, long n)
        {
            if (n == 0) return new Mint(1);
            Mint b = Pow(a, n >> 1);
            b *= b;
            if ((n & 1) == 1) b *= a;
            return b;
        }
        public static Mint Inv(Mint n)
        {
            long a = n.Value;
            long b = MOD;

            long x = 1;
            long u = 0;
            while (b != 0)
            {
                long k = a / b;
                long _x = u;
                u = x - k * u;
                x = _x;

                long _a = a;
                a = b;
                b = _a - (k * b);
            }

            return new Mint(x);
        }
        public override string ToString() => Value.ToString();
        public static implicit operator Mint(long a) => new Mint(a);
        public static explicit operator long(Mint a) => a.Value;
        public static Mint Choose(long n, long k)
        {
            Mint numerator = 1, denominator = 1;
            for (int i = 0; i < k; i++)
            {
                numerator *= n - i;
                denominator *= i + 1;
            }
            return numerator / denominator;
        }
    }
    public enum Priority : byte
    {
        Smaller = 0,
        Larger = 1
    }
}
