namespace parserTest
{
	/// <summary>
	/// This code is garbage, but it does parse and solve math
	/// where allowed symbols are [0-9, +, *, (, )]
	/// The functions are heavily dependant on the guarantees
	/// given by the other functions and there are probably a
	/// bunch of edge cases that break it.
	/// </summary>
	public static class Parser1
	{
		public static int Parse(string s)
		{
			var stack = Split(s);
			var cur = "";
			do
			{
				cur = stack[stack.Count -1] + cur;
				stack.RemoveAt(stack.Count-1);

				(var start, var end) = BreakString(cur);

				cur = Calc(start).ToString() + end;
			}while (stack.Count > 0);

			return int.Parse(cur);
		}

		/// <summary>
		/// If the string starts with (, break out the math inside
		/// the first set of () and return that as start. Return
		/// the rest of the math after the first () as end.
		/// </summary>
		/// <param name="cur"></param>
		/// <returns></returns>
		private static (string, string) BreakString(string cur)
		{
			var start = cur;
			var end = "";

			if (cur[0] == '(')
			{
				var breakIndex = cur.IndexOf(')');
				start = cur.Substring(1, breakIndex-1);
				end = cur.Substring(breakIndex+1, cur.Length - breakIndex-1);
			}

			return (start, end);
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


		/// <summary>
		/// Equivalent to s.split( '(' ) but the ( is included in the token
		/// </summary>
		/// <param name="s">The string to split</param>
		/// <returns></returns>
		public static List<string> Split(string s, char c = '(')
		{
			var list = new List<string>();
			var cur = "" + s[0];
			for(int i = 1; i < s.Length; i++)
			{
				if(s[i] == c){
					list.Add(cur);
					cur = "";
				}
				cur += s[i];
			}
			list.Add(cur);

			return list;
		}
	}
}