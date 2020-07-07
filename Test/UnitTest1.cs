using CompetitionPrograming2;
using System;
using System.IO;
using Xunit;

namespace Test
{
    public sealed class ProblemsTest
    {
        [Fact]
        public void Test1()
        {
            AssertInOut(Input1, Output1);
        }

        [Fact]
        public void Test2()
        {
            AssertInOut(Input2, Output2);
        }

        [Fact]
        public void Test3()
        {
            AssertInOut(Input3, Output3);
        }

        [Fact]
        public void Test4()
        {
            AssertInOut(Input4, Output4);
        }

        private void AssertInOut(string inputFileName, string outputFileName)
        {
            using var input = new StreamReader(inputFileName);
            using var output = new StringWriter();
            Console.SetIn(input);
            Console.SetOut(output);

            Program.Solve();

            Assert.Equal(File.ReadAllText(outputFileName).Trim(), output.ToString().Trim());
        }

        private static readonly string Input1 = "Input1.txt";
        private static readonly string Input2 = "Input2.txt";
        private static readonly string Input3 = "Input3.txt";
        private static readonly string Input4 = "Input4.txt";

        private static readonly string Output1 = "Output1.txt";
        private static readonly string Output2 = "Output2.txt";
        private static readonly string Output3 = "Output3.txt";
        private static readonly string Output4 = "Output4.txt";
    }
}
