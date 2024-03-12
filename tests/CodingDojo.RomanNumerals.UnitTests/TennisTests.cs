using CodingDojo.RomanNumerals.Kata;
using FluentAssertions;

namespace CodingDojo.RomanNumerals.UnitTests;

public class TennisTests
{
    private readonly Tennis _game = new();

    private void TestGame(int serving, int other, Scores expected1, Scores expected2)
    {
        TestGame(serving, other, $"{expected1} - {expected2}");
    }
    
    private void TestGame(int serving, int other, string expectedResult)
    {
        for (int i = 0; i < serving; ++i) _game.ServingPlayerScores();
        for (int i = 0; i < other; ++i) _game.OtherPlayerScores();
        _game.GetScore().Should().Be(expectedResult);
    }


    [Fact]
    public void WhenGameStartsTheScoreIsLoveLove() =>
        TestGame(0, 0, Scores.Love, Scores.Love);

    [Fact]
    public void WhenServingPlayersScoresFirstPointTheScoreIs15Love() =>
        TestGame(1, 0, Scores.Fifteen, Scores.Love);

    [Fact]
    public void WhenOtherPlayerScoresFirstPointTheScoreIsLove15() =>
        TestGame(0, 1, Scores.Love, Scores.Fifteen);

    [Fact]
    public void WhenBothPlayersScoreFirstPointsTheScoreIs15_15() =>
        TestGame(1, 1, Scores.Fifteen, Scores.Fifteen);

    [Fact]
    public void WhenServingPlayerScoresTwoPointsTheScoreIs30_Love() =>
        TestGame(2, 0, Scores.Thirty, Scores.Love);

    [Fact]
    public void WhenServingPlayerSCoresThreePointsTheScoreIs40_Love() =>
        TestGame(3, 0, Scores.Forty, Scores.Love);

    [Fact]
    public void WhenServingPlayerScoresFourPoints_ServingPlayerWins() 
    {
        TestGame(4, 0, "Game Serving Player");
    }
    
    [Fact]
    public void WhenOtherPlayerScoresFourPoints_OtherPlayerWins()
    {
        TestGame(0,4,"Game Other Player");
    }

    [Fact]
    public void WhenBothPlayersScoreThreePoints_TheScoreIsDeuce()
    {
        TestGame(3, 3, "Deuce");
    }

    [Fact]
    public void WhenServingPlayerScoresAfterDeuce_TheScoreBecomesAdIn()
    {
        TestGame(3, 3, "Deuce");
        _game.ServingPlayerScores();
        _game.GetScore().Should().Be("Ad In");
    }
}