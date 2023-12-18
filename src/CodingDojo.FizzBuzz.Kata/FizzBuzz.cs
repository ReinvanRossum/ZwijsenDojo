using System.Runtime.InteropServices;

namespace CodingDojo.FizzBuzz.Kata;

public class FizzBuzz
{
    public string ConvertNumber(int number)
    {
        var answer = "";
        if (number % 3 == 0)
        {
            answer+= "Fizz";
        }

        if (number % 5 == 0)
        {
            answer += "Buzz";
        }
        return answer != "" ? answer : number.ToString();
    }

    public void Printer()
    {
        for (var i = 1; i <= 100; i++)
        {
            Console.WriteLine(ConvertNumber(i));
        }
    }
}