using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace CompetitionPrograming2.Library
{
    public static class ExtentionsLibrary
    {
        public static T[] NextPermutation<T>(this IEnumerable<T> collection) where T : IComparable
        {
            var array = collection.ToArray();
            int? exchangingNumIndex = null;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1].CompareTo(array[i]) >= 0) { continue; }

                exchangingNumIndex = i - 1;
            }

            if (exchangingNumIndex is null) { return null; }

            for (int j = array.Length - 1; j >= 0; j--)
            {
                if (array[(int)exchangingNumIndex].CompareTo(array[j]) >= 0) { continue; }

                var tmp = array[j];
                array[j] = array[(int)exchangingNumIndex];
                array[(int)exchangingNumIndex] = tmp;
                break;
            }
            return array;
        }
        public static IEnumerable<T[]> Permutations<T>(this IEnumerable<T> collection) where T : IComparable
        {
            var next = collection.NextPermutation();
            
            while (!(next is null))
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
        public static T[,] CopyArray<T>(this T[,] array)
        {
            var firstDimentionLength = array.GetLength(0);
            var secondDimentionLength = array.GetLength(1);
            var newDArray = new T[firstDimentionLength, secondDimentionLength];
            Array.Copy(array, newDArray, firstDimentionLength * secondDimentionLength);
            return newDArray;
        }
        public static T[] ToArray<T>(this string str) where T : IComparable, IComparable<T>, IConvertible, IEquatable<T>
        {
            if (typeof(T) == typeof(string)) { return (T[])(object)str.Split(); }

            return str.ConvertEnumerator<T>().ToArray();
        }
        public static List<T> ToList<T>(this string str) where T : IComparable, IComparable<T>, IConvertible, IEquatable<T>
        {
            if (typeof(T) == typeof(string)) { return (List<T>)(object)str.Split().ToList(); }

            return str.ConvertEnumerator<T>().ToList();
        }
        public static IEnumerable<T> ConvertEnumerator<T>(this string str) where T : IComparable, IComparable<T>, IConvertible, IEquatable<T>
        {
            var t = typeof(T);
            if (t == typeof(byte))
            {
                return (IEnumerable<T>)str.Split().Select(byte.Parse);
            }
            if (t == typeof(int))
            {
                return (IEnumerable<T>)str.Split().Select(int.Parse);
            }
            if (t == typeof(long))
            {
                return (IEnumerable<T>)str.Split().Select(long.Parse);
            }
            if (t == typeof(double))
            {
                return (IEnumerable<T>)str.Split().Select(double.Parse);
            }
            if (t == typeof(decimal))
            {
                return (IEnumerable<T>)str.Split().Select(decimal.Parse);
            }
            if (t == typeof(BigInteger))
            {
                return (IEnumerable<T>)str.Split().Select(BigInteger.Parse);
            }
            throw new NotSupportedException();
        }
        public static byte ToByte(this string str) => byte.Parse(str);
        public static byte ToByte(this char chr) => byte.Parse(chr.ToString());
        public static int ToInt(this string str) => int.Parse(str);
        public static int ToInt(this char chr) => int.Parse(chr.ToString());
        public static long ToLong(this string str) => long.Parse(str);
        public static double ToDouble(this string str) => double.Parse(str);
        public static decimal ToDecimal(this string str) => decimal.Parse(str);
        public static BigInteger ToBigInteger(this string str) => BigInteger.Parse(str);
        public static DateTime ToDateTime(this string str) => DateTime.Parse(str);
        public static string StringJoin(this object[] array, string separator = "") => string.Join(separator, array);
        public static string StringJoin<T>(this IEnumerable<T> collection, string separator = "") => string.Join(separator, collection.Select(c => c.ToString()));
        public static int LowerBound<T>(this IReadOnlyList<T> a, T v) => LowerBound(a, v, Comparer<T>.Default);
        public static int LowerBound<T>(this IReadOnlyList<T> a, T v, Comparer<T> cmp)
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
        public static int UpperBound<T>(this IReadOnlyList<T> a, T v) => UpperBound(a, v, Comparer<T>.Default);
        public static int UpperBound<T>(this IReadOnlyList<T> a, T v, Comparer<T> cmp)
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
    }
}
