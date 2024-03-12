using FluentAssertions;

namespace GreedTests;

public class GreedTests
{
    private readonly Greed.Greed _sut = new Greed.Greed();
    
    [Theory] 
    [InlineData(100, new int[]{ 1 })]   
    [InlineData(200, new int[]{ 1, 1 })]
    [InlineData(50, new int[]{ 5 })]
    [InlineData(200, new int[]{ 2, 3, 2, 2})]
    [InlineData(300, new int[]{ 2, 1, 2, 2})]
    [InlineData(1000, new int[]{ 1, 3, 1, 1})]
    [InlineData(1100, new int[]{ 1, 5, 5, 1, 1})]
    [InlineData(1500, new int[]{ 1, 5, 5, 5, 1, 1})]
    //3,3,3
    //4,4,4
    //6,6,6

    public void ADieList_ShouldHaveExpectedScore(int expectedResult, int[] dieList)
    {
        var result = Greed.Greed.Score(dieList.ToList());
        result.Should().Be(expectedResult);
    }

    [Fact]
    public void TooManyDies_ExceptionWithMessageYouCheater()
    {
        var dieList = Enumerable.Range(1, 7).Select(x => x % 6).ToList();
        var act = () => Greed.Greed.Score(dieList);
        act.Should().Throw<Exception>().WithMessage("YOU CHEATER!!!");
    }

    [Fact]
    public void InvalidDiceNumber_ExceptionWithMessageInvalidDiceNumber()
    {
        var dieList = new List<int>{1, 2, 3, 4, 5, 7};
        var act = () => Greed.Greed.Score(dieList);
        act.Should().Throw<Exception>().WithMessage("invalid number 7");
    }
}
