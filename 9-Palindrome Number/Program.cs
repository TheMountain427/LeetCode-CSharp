

public class Solution {
    public bool IsPalindrome(int x) {

        if (x < 0)
        {
            return false;
        }

        var splitter = 10;

        if ( x < splitter)
        { 
            return true;
        }

        else
        {
            var xsplit = new List<int>();
            var remainder = x % splitter;
            xsplit.Add(remainder);
            
            var lead = x / splitter;

            if (lead < 10)
            {
                xsplit.Add(remainder);
            }

            while (lead > 9)
            {
                remainder = lead % splitter;
                xsplit.Add(remainder);

                lead = lead / splitter;
            }

            xsplit.Add(lead);
            
            for (int i = 0, c = xsplit.Count - 1; i < c; i++, c--)
            {
                if (xsplit[i] != xsplit[c])
                {
                    return false;
                }
            }
            return true;
        }
    }
        static void Main(string[] args)
    {
        var output = new Solution();
        var h = output.IsPalindrome(1001);
        Console.WriteLine($"{h}");
    }
}

