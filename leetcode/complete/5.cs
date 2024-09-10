namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = LongestPalindrome("qwertyuisdffdsop");
        }

        public static string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return "";
            }

            var longestPal = (-1, -1);
            var longestLength = 0;

            //Handle case where pal has single middle letter
            for(var i = 0; i < s.Length; i++)
            {
                var newGuess = findPalAtCenter(s, i, i);
                if(newGuess.Item1 != -1 && newGuess.Item2 - newGuess.Item1 + 1 > longestLength)
                {
                    longestPal = newGuess;
                    longestLength = newGuess.Item2 - newGuess.Item1 + 1;
                }
            }

            //Handle case where pal has pair of central letters
            for (var i = 0; i < s.Length - 1; i++)
            {
                var newGuess = findPalAtCenter(s, i, i + 1);
                if (newGuess.Item1 != -1 && newGuess.Item2 - newGuess.Item1 + 1 > longestLength)
                {
                    longestPal = newGuess;
                    longestLength = newGuess.Item2 - newGuess.Item1 + 1;
                }
            }

            return s.Substring(longestPal.Item1, longestPal.Item2 - longestPal.Item1 + 1);
        }

        public static (int, int) findPalAtCenter(string s, int start, int end)
        {
            if (s[start] != s[end])
            {
                return (-1, -1);
            }

            var lastValidBounds = (start, end);

            for(int i = 0; i < s.Length; i++)
            {
                var newStart = lastValidBounds.start - 1;
                var newEnd = lastValidBounds.end + 1;
                if(newStart < 0 || newEnd >= s.Length || s[newStart] != s[newEnd])
                {
                    break;
                }
                lastValidBounds = (newStart, newEnd);
            }

            return lastValidBounds;
        }

    }
}