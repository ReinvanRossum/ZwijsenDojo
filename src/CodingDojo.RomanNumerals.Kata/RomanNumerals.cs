namespace CodingDojo.RomanNumerals.Kata;

public class RomanNumerals
{
    public object Converter(int i)
    {
        var romanNum = string.Concat(Enumerable.Repeat("I", i));
        
        romanNum = romanNum.Replace("IIIII", "V");
        romanNum = romanNum.Replace("IIII", "IV");
        
        romanNum = romanNum.Replace("VV", "X");
        romanNum = romanNum.Replace("VIV", "IX");

        romanNum = romanNum.Replace("XXXXX", "L");
        romanNum = romanNum.Replace("XXXX", "XL");
        
        romanNum = romanNum.Replace("LL", "C");
        romanNum = romanNum.Replace("LXL", "XC");
        
        return romanNum;
    }
}