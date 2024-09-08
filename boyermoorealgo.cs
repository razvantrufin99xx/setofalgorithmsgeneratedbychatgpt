using System;
using System.Collections.Generic;

class BoyerMoore
{
    static int NO_OF_CHARS = 256;

    // The preprocessing function for Boyer Moore's bad character heuristic
    static void BadCharHeuristic(string str, int size, int[] badChar)
    {
        for (int i = 0; i < NO_OF_CHARS; i++)
            badChar[i] = -1;

        for (int i = 0; i < size; i++)
            badChar[(int)str[i]] = i;
    }

    static void Search(string txt, string pat)
    {
        int m = pat.Length;
        int n = txt.Length;

        int[] badChar = new int[NO_OF_CHARS];

        // Fill the bad character array by calling the preprocessing function
        // BadCharHeuristic() for given pattern
        BadCharHeuristic(pat, m, badChar);

        int s = 0; // s is the shift of the pattern with respect to text
        while (s <= (n - m))
        {
            int j = m - 1;

            // Keep reducing index j of pattern while characters of pattern and text are matching at this shift s
            while (j >= 0 && pat[j] == txt[s + j])
                j--;

            // If the pattern is present at current shift, then index j will become -1 after the above loop
            if (j < 0)
            {
                Console.WriteLine("Pattern occurs at shift = " + s);

                // Shift the pattern so that the next character in text aligns with the last occurrence of it in pattern.
                // The condition s+m < n is necessary for the case when pattern occurs at the end of text
                s += (s + m < n) ? m - badChar[txt[s + m]] : 1;
            }
            else
            {
                // Shift the pattern so that the bad character in text aligns with the last occurrence of it in pattern.
                // The max function is used to make sure that we get a positive shift.
                s += Math.Max(1, j - badChar[txt[s + j]]);
            }
        }
    }

    public static void Main()
    {
        string txt = "ABAAABCD";
        string pat = "ABC";
        Search(txt, pat);
    }
}
