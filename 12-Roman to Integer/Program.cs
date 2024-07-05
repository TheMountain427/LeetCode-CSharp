// oops
using System.Text.RegularExpressions;

// I = 1 -> IV = 4/ IX = 9
// V = 5
// X = 10 -> XL = 40/ XC = 90
// L = 50
// C = 100 -> CD = 400/ CM = 900
// D = 500
// M = 1000

// I    ->  X    ->  C
// II   ->  XX   ->  CC
// III  ->  XXX  ->  CCC  
// IV   ->  XL   ->  CD
// V    ->  L    ->  D
// VI   ->  LX   ->  DC
// VII  ->  LXX  ->  DCC
// VIII ->  LXXX ->  DCCC
// IX   ->  XC   ->  CM
// X    ->  C    ->  M

//XXXVIII
public class Solution 
{

    private static int _output = 0;

    public static int Output 
    {
        get
        {
            return _output;
        }
        set
        {
            _output = value;
            _isChanged = true;
        }
    }

    private static bool _isChanged = false;
    
    public static bool isChanged
    {
        get
        {
            return _isChanged;
        }
        set
        { 
            _isChanged = value;
        }
    }

    public enum RomanNumeral
    {
        None = 0,
        I = 1,
        IV = 4,
        V = 5,
        IX = 9,
        X = 10,
        XL = 40,
        L = 50,
        XC = 90,
        C = 100,
        CD = 400,
        D = 500,
        CM = 900,
        M = 1000
    } 

    public static string MatchPattern(RomanNumeral RomanNum) => RomanNum switch
    {
        RomanNumeral.I => @"^(I{0,3})(?=[^VX]|$)(IV|IX)?",
        RomanNumeral.V => @"^V{1}",
        RomanNumeral.X => @"^(X{0,3})(?=[^LC]|$)(XL|XC)?",
        RomanNumeral.L => @"^L{1}",
        RomanNumeral.C => @"^(C{0,3})(?=[^DM]|$)(CD|CM)?",
        RomanNumeral.D => @"^D{1}",
        RomanNumeral.M => @"^M+",
        _ => null
    };

    public static RomanNumeral FindRomanEnumerator(string str)
    {
        var RomEnum = RomanNumeral.TryParse(str, out RomanNumeral result) ? result : RomanNumeral.None;
        return RomEnum;
    }
    public static int ConvertSection(string input, ref string RomNumStr)
    {
        Output = 0;
        isChanged = false;
        string EnumStr = "";

        if (input.Length == 2 && Regex.IsMatch(input, @"IV|IX|XL|XC|CD|CM"))
        {
            EnumStr = input;
            var RomEnum = FindRomanEnumerator(EnumStr);
            Output += (int)RomEnum;

            if ( isChanged == true)
            {
            RomNumStr = Regex.Replace(input, RomEnum.ToString(), "");
            isChanged = false;
            }
        }
        else
        {
            EnumStr = input[0].ToString();
        

            var RomEnum = FindRomanEnumerator(EnumStr);

            var match = Regex.Match(input, MatchPattern(RomEnum));
            
            if (RomEnum is RomanNumeral.I or RomanNumeral.X or RomanNumeral.C)
            {
                Output += !String.IsNullOrEmpty(match.Groups[1].Success == true ? match.Value : "") ? match.Groups[1].Length * (int)RomEnum : 0 ;
                Output += match.Groups[2].Success == true ? (int)FindRomanEnumerator(match.Groups[2].Value) : 0 ;

                if ( isChanged == true)
                {
                RomNumStr = Regex.Replace(input, MatchPattern(RomEnum), "");
                isChanged = false;
                }       
            }

            else if (RomEnum is RomanNumeral.M)
            {
                Output += !String.IsNullOrEmpty(match.Groups[0].Success == true ? match.Value : "") ? match.Groups[0].Length * (int)RomEnum : 0 ;
                if ( isChanged == true)
                {
                RomNumStr = Regex.Replace(input, MatchPattern(RomEnum), "");
                isChanged = false;
                }  
            }

            else
            {
                Output += !String.IsNullOrEmpty(match.Groups[0].Success == true ? match.Value : "") ? match.Groups[0].Length * (int)RomEnum : 0 ;
                if ( isChanged == true)
                {
                RomNumStr = Regex.Replace(input, MatchPattern(RomEnum), "");
                isChanged = false;
                }
            }
        }
        return Output;
    }

    private static string _romnum { get; set; }

    public static string RomNum
    {
        get
        {
            return _romnum;
        }
        set
        {
            _romnum = value;
        }
    }

    public static int RomanToInt(string romnum) 
    {

        var RomNum = romnum;
        var Conversion = 0;

        while (RomNum.Length > 0)
        {
            Conversion += ConvertSection(RomNum, ref RomNum);
        }
        return Conversion;
    }
    static void Main()
    {
        // var tests = Test.TestingNums();

        // foreach (var test in tests)
        // {
        //     // Console.WriteLine($"Testing {test.Key}...");
        //     var a = RomanToInt(test.Key);
        //     if (test.Value != a)
        //     {
        //         Console.WriteLine($"{test.Key} failed. Expected {test.Value}. Received {a}.");
        //     }
        //     else
        //     {
        //         // System.Console.WriteLine("Success!");
        //     }
        // }

        // var test = "MMMXCVII";
        // var a = RomanToInt(test);
        // Console.WriteLine($"{a}");
    }


}

