using FluentAssertions;
using NUnit.Framework;
using System;

namespace CurrencyToTextConverter.Tests
{
    [TestFixture]
    public class NumberToTextTranslatorTests
    {
        [TestCase(0, "zero")]
        [TestCase(1, "one")]
        [TestCase(2, "two")]
        [TestCase(3, "three")]
        [TestCase(4, "four")]
        [TestCase(5, "five")]
        [TestCase(6, "six")]
        [TestCase(7, "seven")]
        [TestCase(8, "eight")]
        [TestCase(9, "nine")]
        [TestCase(10, "ten")]
        [TestCase(11, "eleven")]
        [TestCase(12, "twelve")]
        [TestCase(13, "thirteen")]
        [TestCase(14, "fourteen")]
        [TestCase(15, "fifteen")]
        [TestCase(16, "sixteen")]
        [TestCase(17, "seventeen")]
        [TestCase(18, "eighteen")]
        [TestCase(19, "nineteen")]
        [TestCase(20, "twenty")]
        [TestCase(30, "thirty")]
        [TestCase(40, "forty")]
        [TestCase(50, "fifty")]
        [TestCase(60, "sixty")]
        [TestCase(70, "seventy")]
        [TestCase(80, "eighty")]
        [TestCase(90, "ninety")]
        public void Convert_CalledForSingleWordNumbers_Will_ReturnProperStrings(int number, string expected)
        {
            var converter = new NumberToTextTranslator();

            var output = converter.Convert(number);

            output.Should().Be(expected);
        }

        [TestCase(21, "twenty-one")]
        [TestCase(32, "thirty-two")]
        [TestCase(43, "forty-three")]
        [TestCase(54, "fifty-four")]
        [TestCase(65, "sixty-five")]
        [TestCase(76, "seventy-six")]
        [TestCase(87, "eighty-seven")]
        [TestCase(98, "ninety-eight")]
        public void Convert_CalledForMultiwordTensNumbers_Will_ReturnProperStrings(int number, string expected)
        {
            var converter = new NumberToTextTranslator();

            var output = converter.Convert(number);

            output.Should().Be(expected);
        }

        [TestCase(100, "one hundred")]
        [TestCase(200, "two hundred")]
        [TestCase(300, "three hundred")]
        [TestCase(1000, "one thousand")]
        [TestCase(4000, "four thousand")]
        [TestCase(5000, "five thousand")]
        [TestCase(6000, "six thousand")]
        [TestCase(1000000, "one million")]
        [TestCase(7000000, "seven million")]
        [TestCase(8000000, "eight million")]
        [TestCase(9000000, "nine million")]
        public void Convert_CalledHundredsOrThousendOrMillionsValue_WithoutOtherPart_Will_ReturnProperStrings(int number, string expected)
        {
            var converter = new NumberToTextTranslator();

            var output = converter.Convert(number);

            output.Should().Be(expected);
        }

        [TestCase(12000, "twelve thousand")]
        [TestCase(47000, "forty-seven thousand")]
        [TestCase(59000, "fifty-nine thousand")]
        [TestCase(111000, "one hundred eleven thousand")]
        [TestCase(426000, "four hundred twenty-six thousand")]
        [TestCase(773000, "seven hundred seventy-three thousand")]
        [TestCase(11000000, "eleven million")]
        [TestCase(72000000, "seventy-two million")]
        [TestCase(118000000, "one hundred eighteen million")]
        [TestCase(999000000, "nine hundred ninety-nine million")]
        public void Convert_CalledForHundredThousandsOrHundredMillion_Will_ReturnProperStrings(int number, string expected)
        {
            var converter = new NumberToTextTranslator();

            var output = converter.Convert(number);

            output.Should().Be(expected);
        }

        [TestCase(12117, "twelve thousand one hundred seventeen")]
        [TestCase(47023, "forty-seven thousand twenty-three")]
        [TestCase(59008, "fifty-nine thousand eight")]
        [TestCase(111040, "one hundred eleven thousand forty")]
        [TestCase(426468, "four hundred twenty-six thousand four hundred sixty-eight")]
        [TestCase(773080, "seven hundred seventy-three thousand eighty")]
        [TestCase(11001002, "eleven million one thousand two")]
        [TestCase(72078099, "seventy-two million seventy-eight thousand ninety-nine")]
        [TestCase(118030060, "one hundred eighteen million thirty thousand sixty")]
        [TestCase(999999999, "nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine")]
        public void Convert_CalledForFullIntegerNumbers_Will_ReturnProperStrings(int number, string expected)
        {
            var converter = new NumberToTextTranslator();

            var output = converter.Convert(number);

            output.Should().Be(expected);
        }
    }
}
