using System;

namespace CodeFragments.MoneyAndCurrency.TextConverters
{
    public class NumberToWords
    {
        public static string Wordify(decimal value)
        {
            if (value == 0)
                return "zero";

            string[] units = "|one|two|three|four|five|six|seven|eight|nine".Split('|');
            string[] teens = "|eleven|twelve|thir#|four#|fif#|six#|seven#|eigh#|nine#".Replace("#", "teen").Split('|');
            string[] tens = "|ten|twenty|thirty|forty|fifty|sixty|seventy|eighty|ninety".Split('|');
            string[] thou = "|thousand|m#|b#|tr#|quadr#|quint#|sext#|sept#|oct#".Replace("#", "illion").Split('|');
            string g = (value < 0) ? "minus " : "";
            string w = "";
            int p = 0;

            value = Math.Abs(value);
            while (value > 0)
            {
                int b = (int)(value % 1000);
                if (b > 0)
                {
                    int h = (b / 100);
                    int t = (b - h * 100) / 10;
                    int u = (b - h * 100 - t * 10);
                    string s = ((h > 0) ? units[h] + " hundred" + ((t > 0 | u > 0) ? " and " : "") : "")
                               + ((t > 0) ? (t == 1 && u > 0) ? teens[u] : tens[t] + ((u > 0) ? "-" : "") : "")
                               + ((t != 1) ? units[u] : "");
                    s = (((value > 1000) && (h == 0) && (p == 0)) ? " and " : (value > 1000) ? ", " : "") + s;
                    w = s + " " + thou[p] + w;
                }
                value = value / 1000;
                p++;
            }
            return g + w;
        }
    }
}
