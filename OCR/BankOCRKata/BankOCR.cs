using System.Runtime.InteropServices.JavaScript;

namespace BankOCRKata;

public class BankOCR
{
    int charCount = "I am Bob".Count(c => !Char.IsWhiteSpace(c));
    
    /*
     * 0 1 2 /n=3
     * 4 5 6 /n=7
     * 8 9 10 /n=11
     */
    private readonly Dictionary<string,int> _alarmNumbers = new()
    {
        { " _ | ||_|", 0 },
        { "     |  |", 1 },
        { " _  _||_ ", 2 },
        { " _  _| _|", 3 },
        { "   |_|  |", 4 },
        { " _ |_  _|", 5 },
        { " _ |_ |_|", 6 },
        { " _   |  |", 7 },
        { " _ |_||_|", 8 },
        { " _ |_| _|", 9 },
    };
    
    public int ReadAlarmNumber(string alarmNumber)
    {
        return _alarmNumbers[alarmNumber];
    }

    public string ReadNumberLine(string input)
    {
        var numList = "";
        for(int i = 0; i < 9; i++)
        {
            var number = input.Substring(i * 3, 3);
            number += input.Substring(i * 3 + 28, 3);
            number += input.Substring(i * 3 + 56, 3);
            Console.WriteLine(numList);
            numList += ReadAlarmNumber(number);
        }

        return numList;
    }

    public bool IsValidAccountNumber(string accountNumber)
    {
        int checksum = 0;
        for (int i = 0; i < 9; i++)
        {
            checksum += Int32.Parse(accountNumber.Substring(i,1)) * (9-i);
        }
        return checksum % 11 == 0;
    }
}