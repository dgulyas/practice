using System;
using System.Collections.Generic;
using System.Linq;


namespace thing
{
	class Program
	{
		static void Main()
		{
			List<int> numbers = new List<int>();

			for (int i = 0; i < 10000; i++)
			{
				numbers.Add(i);
			}

			var sum = 0;

			while (numbers.Count > 0)
			{
				Console.WriteLine(numbers.Count);
				var candidate = numbers.ElementAt(0);
				numbers.RemoveAt(0);

				var partner = getSumOfDivisors(candidate);

				if (!numbers.Contains(partner))
				{
					continue;
				}

				var partnersSod = getSumOfDivisors(partner);

				if (partnersSod == candidate)
				{
					numbers.Remove(partner);
					sum += candidate + partner;
				}

			}

			Console.WriteLine(sum); //31626
		}

		static int getSumOfDivisors(int num)
		{
			var sum = 0;
			for (int i = 1; i < (num / 2) + 1; i++)
			{
				if (num % i == 0)
				{
					sum += i;
				}
			}
			return sum;
		}
	}
}
