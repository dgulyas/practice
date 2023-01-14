namespace parserTest
{
    /// <summary>
    /// This code is garbage, but it does parse and solve math
    /// where allowed symbols are ints, +, *, and ()
    /// The functions are heavily dependant on the gaurentees
    /// given by the other functions and there are probably a
    /// bunch of edge cases that break it.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            //(var e, var r) = BreakString("890(1234)56()78");
            //var z = Calc("2*3+2*3+3+5*6+5"); //50
            //var x = Split(" a+(b+c)*(d*(e+f)*(g+h)+i)", '(' );

            var u = Parse("2+(4+1)*(3*(5+2)*(2+6)+10)");
            var v =        2+(4+1)*(3*(5+2)*(2+6)+10);

            Console.WriteLine(u + " == " + v);
            Console.ReadLine();
        }

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