namespace Greed;

public class Greed
{
    public static int Score(List<int> dieList)
    {
        if (dieList.Count > 6)
        {
            throw new Exception(("YOU CHEATER!!!"));
        }

        if (dieList.Any(x => x > 6))
        {
            throw new Exception("invalid number 7");
        }

        var score = 0;

        foreach (var die in dieList)
        {
            switch (die)
            {
                case 1:
                    score += 100;
                    break;
                case 5:
                    score += 50;
                    break;
            }
        }

        return score + dieList
                    .GroupBy(d => d)
                    .Where(group => group.Count() == 3)
                    .Sum(group => group.Key switch
                    {
                        1 => 700,
                        5 => 350,
                        _ => group.Key * 100
                    });
    }
    
}