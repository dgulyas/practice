//This solves Euler #17
//If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
//If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?

using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace words
{
	class Program
	{
		readonly static List<string> onesNumbers = new List<string> { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "" };
		readonly static List<string> tensNumbers = new List<string> { "", "one", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
		readonly static List<string> teensNumbers = new List<string> { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
		private static int letterCount;

		private static StreamWriter file;

		static void Main()
		{
			file = new StreamWriter("C:\\whereEverYouWantIt\\num.txt");

			for (int i = 1; i < 1000; i++)
			{
				var tens = (i % 100) / 10;
				var ones = i % 10;
				var hundreds = i / 100;

				if (hundreds > 0)
				{
					p(onesNumbers[hundreds]);
					p(" hundred ");

					if (i % 100 != 0)
					{
						p("and");
					}
				}

				if (tens == 1)
				{
					if (hundreds > 0)
					{
						p(" ");
					}
					p(teensNumbers[ones], true);
				}
				else
				{
					if (hundreds > 0)
					{
						p(" ");
					}
					p(tensNumbers[tens]);
					if (tens > 0)
					{
						p(" ");
					}
					p(onesNumbers[ones], true);
				}
			}
			p("one thousand", true);
			file.WriteLine(letterCount.ToString()); //don't want to count this.
			file.Close();
		}

		private static void p(string s, bool newLine = false)
		{
			letterCount += s.Count(char.IsLetter);
			if (newLine)
			{
				file.WriteLine(s);
			}
			else
			{
				file.Write(s);
			}
		}
	}
}

