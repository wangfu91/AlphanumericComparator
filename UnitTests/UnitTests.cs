using System;
using Xunit;
using Comparator = AlphaNumericComparator;

namespace UnitTests
{
    public class NaturalSortTests
    {
        private readonly Random _random = new Random();

        private readonly string[] _source1 = {
            "string",
            "string0",
            "string00",
            "string1",
            "string01",
            "string001",
            "string2",
            "string02",
            "string002",
            "string002.a",
            "string002.a0",
            "string002.a1",
            "string002.a01",
            "string002.a010",
            "string002.a011",
            "string0002",
            "string0002"
        };

        private readonly string[] _source2 = {
            "z1.doc",
            "z2.doc",
            "z3.doc",
            "z4.doc",
            "z5.doc",
            "z6.doc",
            "z7.doc",
            "z8.doc",
            "z9.doc",
            "z10.doc",
            "z11.doc",
            "z12.doc",
            "z13.doc",
            "z14.doc",
            "z15.doc",
            "z16.doc",
            "z17.doc",
            "z18.doc",
            "z19.doc",
            "z20.doc",
            "z100.doc",
            "z101.doc",
            "z102.doc"
        };

        private readonly string[] _source3 = {
            "10X Radonius",
            "20X Radonius",
            "20X Radonius Prime",
            "30X Radonius",
            "40X Radonius",
            "200X Radonius",
            "1000X Radonius Maximus",
            "Allegia 6R Clasteron",
            "Allegia 50 Clasteron",
            "Allegia 50B Clasteron",
            "Allegia 51 Clasteron",
            "Allegia 500 Clasteron",
            "Alpha 2",
            "Alpha 2A",
            "Alpha 2A-900 ",
            "Alpha 2A-8000",
            "Alpha 100",
            "Alpha 200",
            "Callisto Morphamax",
            "Callisto Morphamax 500",
            "Callisto Morphamax 600",
            "Callisto Morphamax 700",
            "Callisto Morphamax 5000",
            "Callisto Morphamax 6000 SE",
            "Callisto Morphamax 6000 SE2",
            "Callisto Morphamax 7000",
            "Xiph Xlater 5",
            "Xiph Xlater 40",
            "Xiph Xlater 50",
            "Xiph Xlater 58",
            "Xiph Xlater 300",
            "Xiph Xlater 500",
            "Xiph Xlater 2000",
            "Xiph Xlater 5000",
            "Xiph Xlater 10000",
        };


        private readonly string[] _source4 = {
            "≤‚",
            "≈≈",
            "∆¥",
            " ‘",
            "Œƒ",
            "–Ú",
            "“Ù",
            "÷–"
        };

        private readonly string[] _source5 = {
            "02841027019385211055596446229489549303819644288109756",
            "08651328230664709384460955058223172535940812848111745",
            "09749445923078164062862089986280348253421170679821489",
            "14159265358979323846264338327950288419716939937510582",
            "17488152092096282925409171536436789259036001133053054",
            "48610454326648213393607260249141273724587006606315588",
            "65933446128475648233786783165271201909145648566923460",
            "88204665213841469519415116094330572703657595919530921"
        };


        private string[] Shuffle(string[] strings)
        {
            var shuffledStrings = (string[])strings.Clone();
            for (var i = 0; i < shuffledStrings.Length - 1; ++i)
            {
                var j = i + _random.Next(shuffledStrings.Length - i);
                var tmp = shuffledStrings[i];
                shuffledStrings[i] = shuffledStrings[j];
                shuffledStrings[j] = tmp;
            }

            return shuffledStrings;
        }

        [Fact]
        public void TestSource1()
        {
            TestCore(_source1);
        }

        [Fact]
        public void TestSource2()
        {
            TestCore(_source2);
        }

        [Fact]
        public void TestSource3()
        {
            TestCore(_source3);
        }

        [Fact]
        public void TestSource4()
        {
            TestCore(_source4);
        }

        [Fact]
        public void TestSource5()
        {
            TestCore(_source5);
        }

        private void TestCore(string[] source)
        {
            var shuffledStrings = Shuffle(source);
            Array.Sort(shuffledStrings, new Comparator.AlphaNumericComparator());
            for (var i = 0; i < source.Length - 1; ++i)
            {
                if (!source[i].Equals(shuffledStrings[i]))
                {
                    throw new Exception("Wrong sorting order!");
                }
            }
        }
    }
}
