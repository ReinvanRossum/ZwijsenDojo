using FluentAssertions;

namespace CodingDojo.RomanNumerals.UnitTests;

public class RomanNumeralsTests
{
    [Theory]
    [InlineData(1, "I")]
    [InlineData(2, "II")]
    [InlineData(4, "IV")]
    [InlineData(5, "V")]
    [InlineData(6, "VI")]
    [InlineData(9, "IX")]
    [InlineData(10, "X")]
    [InlineData(14, "XIV")]
    [InlineData(50, "L")]
    [InlineData(100, "C")]
    [InlineData(149, "CXLIX")]
    [InlineData(190, "CXC")]
    public void Given_One_Should_Return_I(int number, string expected)
    {
        // Arrange
        var roman = new Kata.RomanNumerals();
        
        // Act
        var result = roman.Converter(number);
        
        // Assert
        result.Should().Be(expected);

    }
}