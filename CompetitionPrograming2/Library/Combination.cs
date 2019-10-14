using System;
using System.Collections.Generic;
using System.Text;

namespace CompetitionPrograming2.Library
{
    public class Combination
    {
        private readonly int[][] p;
        public Combination(int size)
        {
            p = new int[size + 1][];
            for (int i = 0; i <= size; i++) { p[i] = new int[size + 1]; }
            p[0][0] = 1;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    p[i + 1][j] += p[i][j];
                    p[i + 1][j + 1] += p[i][j];
                }
            }
        }
        public int Get(int n, int k) => p[n][k];
    }
}
