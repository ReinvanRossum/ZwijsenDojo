namespace CodingDojo.RomanNumerals.Kata;


public enum Scores
{
    Love,
    Fifteen,
    Thirty,
    Forty
}

public class Tennis
{
    private Scores _servingPlayerPoints = Scores.Love;
    private Scores _otherPlayerPoints = Scores.Love;

    public string GetScore()
    {
        var diff = _servingPlayerPoints - _otherPlayerPoints;
        if ((int)_servingPlayerPoints >= 4 && diff == 1)
        {
            return "Ad In";
        }
        if ((int)_servingPlayerPoints >= 4 && diff >= 2)
        {
            return "Game Serving Player";
        } 
        if ((int)_otherPlayerPoints == 4)
        {
            return "Game Other Player";
        }

        if (_servingPlayerPoints == Scores.Forty && _otherPlayerPoints == Scores.Forty)
        {
            return "Deuce";
        }
        
        return $"{_servingPlayerPoints} - {_otherPlayerPoints}";
    }

    public void ServingPlayerScores()
    {
        _servingPlayerPoints++;
    }

    public void OtherPlayerScores()
    {
        _otherPlayerPoints++;
    }
}