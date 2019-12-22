using System;
using System.Collections.Generic;
using System.Text;

namespace CompetitionPrograming2.Library
{
    public class Combination
    {
        private readonly long max;
        private readonly long mod;
        private readonly long[] factorial;
        private readonly long[] inverse;
        private readonly long[] factInv;

        public Combination(long max, long mod)
        {
            this.max = max;
            this.mod = mod;
            factorial = new long[this.max + 1];
            inverse = new long[this.max + 1];
            factInv = new long[this.max + 1];

            factorial[0] = factorial[1] = 1;
            factInv[0] = factInv[1] = 1;
            inverse[1] = 1;

            for (int i = 2; i <= this.max; i++)
            {
                factorial[i] = factorial[i - 1] * i % this.mod;
                inverse[i] = this.mod - inverse[this.mod % i] * (this.mod / i) % this.mod;
                factInv[i] = factInv[i - 1] * inverse[i] % this.mod;
            }
        }

        public long Get(int n, int k)
        {
            if (n < k) { return 0; }
            if (n < 0 || k < 0) { return 0; }
            if (n == k) { return 1; }
            if (k == 0) { return 1; }
            if (k == 1) { return n % mod; }
            return factorial[n] * (factInv[k] * factInv[n - k] % mod) % mod;
        }
    }
}
