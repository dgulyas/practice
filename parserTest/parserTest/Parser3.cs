namespace parserTest
{
	/// <summary>
	/// We're going to try and make a tree where each
	/// node has either a value or an operation to perform
	/// on two other nodes.
	/// </summary>
	public static class Parser3
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

	//This represents a non-terminal value
	public class Operation : IValue
	{
		public Function Function;
		public IValue ValueR { get; set; }
		public IValue ValueL { get; set; }

		public Operation(Function function, IValue valueR, IValue valueL)
		{
			Function = function;
			ValueR = valueR;
			ValueL = valueL;
		}

		public string Compute()
		{
			return "";
		}
	}

	//This represents a terminal value
	public class Number : IValue
	{
		public string Value { get; set; }

		public Number(string value)
		{
			Value = value;
		}

		public string Compute()
		{
			return Value;
		}
	}

	public enum Function
	{
		add,
		sub,
		mult,
		div
	}

	public interface IValue
	{
		public string Compute();
	}
}