using BankOCRKata;
using FluentAssertions;

namespace BankOCRTests;

public class OCRTests
{
    [Theory]
    [InlineData(" _ | ||_|", 0)]
    [InlineData("     |  |", 1)]
    [InlineData(" _  _||_ ", 2)]
    [InlineData(" _  _| _|", 3)]
    [InlineData("   |_|  |", 4)]
    [InlineData(" _ |_  _|", 5)]
    [InlineData(" _ |_ |_|", 6)]
    [InlineData(" _   |  |", 7)]
    [InlineData(" _ |_||_|", 8)]
    [InlineData(" _ |_| _|", 9)]
    public void ShouldRecognizeAlarmClockNumbersAsNumber(string alarmNumber, int expected)
    {
        BankOCR ocr = new BankOCR();
        int result = ocr.ReadAlarmNumber(alarmNumber);
        result.Should().Be(expected);
    }

    [Fact]
    public void ShouldSplitMultipleNumbersOnARowToNumbers()
    {
        var input = " _  _  _  _  _  _  _  _  _ \n" +
                    "| || || || || || || || || |\n" +
                    "|_||_||_||_||_||_||_||_||_|\n";
        BankOCR ocr = new BankOCR();
        string result = ocr.ReadNumberLine(input);
        result.Should().Be("000000000");
    }

    [Fact]
    public void ShouldSplitAllOtherNumbersCorrectlyToNumbers()
    {
        var input = "    _  _     _  _  _  _  _ \n" +
                    "  | _| _||_||_ |_   ||_||_|\n" +
                    "  ||_  _|  | _||_|  ||_| _|\n";
        BankOCR ocr = new BankOCR();
        string result = ocr.ReadNumberLine(input);
        result.Should().Be("123456789");
    }

    [Fact]
    public void ShouldValidateAccountNumberWithElfProef()
    {
        var accountNumber = "123456789";
        BankOCR ocr = new BankOCR();
        bool result = ocr.IsValidAccountNumber(accountNumber);
        result.Should().Be(true);
    }
    [Fact]
    public void ShouldFailElfProefWithInvalidAccountNumber()
    {
        var accountNumber = "664371495";
        BankOCR ocr = new BankOCR();
        bool result = ocr.IsValidAccountNumber(accountNumber);
        result.Should().Be(false);
    }
}
