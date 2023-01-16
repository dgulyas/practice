namespace parserTest
{
	/// <summary>
	/// This code is less garbage than parser 1.
	/// It iterates through the string, extracting the
	/// parts of the string contained inside the innermost
	/// ()'s. It then solves that chunk and concatenates
	/// the solution back into the string where the ()'s
	/// were until there are no ()'s left.
	/// </summary>
	public static class Parser2
	{
		public static int Parse(string s)
		{
			var openParenStack = new Stack<int>();

			for(int i = 0; i < s.Length; i++)
			{
				if (s[i] == '(')
				{
					openParenStack.Push(i);
				}
				else if (s[i] == ')')
				{
					var matchingOpenindex = openParenStack.Pop();
					(var first, var second, var third) = TriSplit(s, matchingOpenindex, i);
					s = first + Calc(second) + third;
					i = matchingOpenindex - 1;
                }
			}

			return Calc(s); //s has no () left. We can calc the whole thing.
		}

		public static (string, string, string) TriSplit(string s, int start, int end){
			var first = "";
			var second = "";
			var third = "";

			if(start > 0)
			{
				first = s.Substring(0, start);
			}

			second = s.Substring(start + 1, end - start - 1);

			if(end < s.Length)
			{
				third = s.Substring(end + 1, s.Length - end - 1);
			}

			return (first, second, third);
		}

		/// <summary>
		/// Calculates the answer for a string of additions and multiplications
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static int Calc(string s)
		{
			var sum = 0;
			foreach (var element in s.Split('+'))
			{
				var prod = 1;
				foreach (var number in element.Split('*'))
				{
					prod *= int.Parse(number);
				}

				sum += prod;
			}
			return sum;
		}

	}
}