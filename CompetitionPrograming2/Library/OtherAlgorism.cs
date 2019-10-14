using System;
using System.Collections.Generic;

namespace CompetitionPrograming2.Library
{
    public sealed class OtherAlgorism
    {
        public static int Lcm(int a, int b) => a * b / Gcd(a, b);
        public static int Gcd(int a, int b)
        {
            if (a < b) { return Gcd(b, a); }
            int tmp;
            do
            {
                tmp = a % b;
                a = b;
                b = tmp;
            } while (tmp != 0);
            return a;
        }
        public static IEnumerable<int> GetDivisors(int num)
        {
            yield return 1;
            yield return num;
            for (int i = 2; i <= Math.Pow(num, 0.5); i++)
            {
                if (num % i == 0)
                {
                    yield return i;
                    int div = num / i;
                    if (i != div) { yield return div; }
                }
            }
        }
        public static bool IsPrime(long n)
        {
            if (n <= 1) { return false; }

            if (n <= 3) { return true; }

            if (((n % 2) == 0) || ((n % 3) == 0)) { return false; }

            for (int i = 5; i * i <= n; i += 6)
            {
                if (((n % i) == 0) || ((n % (i + 2)) == 0)) { return false; }
            }

            return true;
        }
        public static IEnumerable<Tuple<long, int>> Factorize(long n)
        {
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
    }
}
