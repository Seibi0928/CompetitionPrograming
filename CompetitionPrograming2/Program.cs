using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using static System.Math;

namespace CompetitionPrograming2
{
    public sealed class Program : BaseProgram
    {
        public static void Main(string[] args)
        {
            using (var sc = new SetConsole()) { Solve(); }
        }
        public static void Solve()
        {
        }
    }

    public abstract class BaseProgram
    {
        protected readonly static long divisor = 1000000007;

        protected static void Write(object obj) => Console.WriteLine(obj);
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
            if ((t == typeof(byte)))
            {
                return (T)(object)str.ToByte();
            }
            else if (t == typeof(int))
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
            throw new NotSupportedException();
        }
        protected static T[] GetArray<T>() where T : IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
        {
            return GetString().ToArray<T>();
        }
        protected static TResult[] GetArray<TResult>(Func<string, TResult> selector)
        {
            return (TResult[])(object)GetString().Split().Select(selector).ToArray();
        }
        protected static void Swap<T>(ref T item1, ref T item2)
        {
            var tmp = item1;
            item1 = item2;
            item2 = tmp;
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

    static class ExtentionsLibrary
    {
        public static T[,] CopyArray<T>(this T[,] array)
        {
            var firstDimentionLength = array.GetLength(0);
            var secondDimentionLength = array.GetLength(1);
            var newDArray = new T[firstDimentionLength, secondDimentionLength];
            Array.Copy(array, newDArray, firstDimentionLength * secondDimentionLength);
            return newDArray;
        }
        public static T[] ToArray<T>(this string str) where T : IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
        {
            if (typeof(T) == typeof(string)) { return (T[])(object)str.Split(); }

            return str.ConvertEnumerator<T>().ToArray();
        }
        public static IEnumerable<T> ConvertEnumerator<T>(this string str) where T : IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
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
        public static string StringJoin(this object[] array, string separator) => string.Join(separator, array);
        public static string StringJoin<T>(this IEnumerable<T> collection, string separator) => string.Join(separator, collection.Select(c => c.ToString()));
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
        public static int UpperBound<T>(IReadOnlyList<T> a, T v) => UpperBound(a, v, Comparer<T>.Default);
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

    public sealed class Settings
    {
        public enum Priority : byte
        {
            Smaller = 0,
            Larger = 1
        }
    }
}
