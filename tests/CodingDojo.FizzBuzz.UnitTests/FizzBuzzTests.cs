using FluentAssertions;
using CodingDojo.FizzBuzz.Kata;

namespace CodingDojo.FizzBuzz.UnitTests;

public class FizzBuzzTests
{
    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    public void GivenANumber_ShouldReturnThatNumber(int input, string expectedValue)
    {
        var result = new Kata.FizzBuzz().ConvertNumber(input);
        result.Should().Be(expectedValue);
    }

    [Fact]
    public void GivenANumberDivisibleByThree_ShouldReturnFizz()
    {
        var result = new Kata.FizzBuzz().ConvertNumber(3);
        result.Should().Be("Fizz");
    }

    [Fact]
    public void GivenANumberDivisibleByFive_ShouldReturnBuzz()
    {
        var result = new Kata.FizzBuzz().ConvertNumber(5);
        result.Should().Be("Buzz");
    }

    [Fact]
    public void GivenANumberDivisibleByThreeAndFive_ShouldReturnFizzBuzz()
    {
        var result = new Kata.FizzBuzz().ConvertNumber(15);
        Assert.Equal("FizzBuzz", result);
    }

    [Fact]
    public void FizzBuzzPrinter_ShouldPrint100Lines()
    {
        
        var fizzBuzz = new Kata.FizzBuzz();
        using (StringWriter sw = new StringWriter())
        {
            
            Console.SetOut(sw);
            fizzBuzz.Printer();
            sw.ToString().Should().MatchRegex("\n", Exactly.Times(100));
        }
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
    [Fact]
    public void FizzBuzzPrinter_ShouldPrintFizzBuzzSixTimes()
    {
        
        var fizzBuzz = new Kata.FizzBuzz();
        using (StringWriter sw = new StringWriter())
        {
            
            Console.SetOut(sw);
            fizzBuzz.Printer();
            sw.ToString().Should().MatchRegex("FizzBuzz", Exactly.Times(6));
        }
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
}
