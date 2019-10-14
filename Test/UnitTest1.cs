using CompetitionPrograming2;
using System;
using System.IO;
using Xunit;

namespace Test
{
    public class ProblemsTest
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

        //[Fact]
        public void Test4()
        {
            AssertInOut(Input4, Output4);
        }

        internal void AssertInOut(string inputFileName, string outputFileName)
        {
            using (var input = new StreamReader(inputFileName))
            using (var output = new StringWriter())
            {
                Console.SetIn(input);
                Console.SetOut(output);

                Program.Solve();

                Assert.Equal(File.ReadAllText(outputFileName).Trim(), output.ToString().Trim());
            }
        }

        internal static string Input1 { get; set; } = "Input1.txt";
        internal static string Input2 { get; set; } = "Input2.txt";
        internal static string Input3 { get; set; } = "Input3.txt";
        internal static string Input4 { get; set; } = "Input4.txt";

        internal static string Output1 { get; set; } = "Output1.txt";
        internal static string Output2 { get; set; } = "Output2.txt";
        internal static string Output3 { get; set; } = "Output3.txt";
        internal static string Output4 { get; set; } = "Output4.txt";
    }
}
