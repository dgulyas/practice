namespace parserTest
{

	public class Program
	{
		static void Main(string[] args)
		{
			//(var e, var r) = BreakString("890(1234)56()78");
			//var z = Calc("2*3+2*3+3+5*6+5"); //50
			//var x = Split(" a+(b+c)*(d*(e+f)*(g+h)+i)", '(' );

            // (var a, var b, var c) = Parser2.TriSplit("0123456789", 2,6);
            // (var aa, var ab, var ac) = Parser2.TriSplit("0123456789", 0,6);
            // (var ba, var bb, var bc) = Parser2.TriSplit("0123456789", 2,9);
            // (var baa, var bab, var abc) = Parser2.TriSplit("0123456789", 0,9);

			var u = Parser1.Parse("2+(4+1)*(3*(5+2)*(2+6)+10)");
			var v =                2+(4+1)*(3*(5+2)*(2+6)+10);
			Console.WriteLine("Parser 1");
			Console.WriteLine(u + " == " + v);

			Console.WriteLine();
			Console.WriteLine("Parser 2");
            u = Parser2.Parse("2+(4+1)*(3*(5+2)*(2+6)+10)");
            v =                2+(4+1)*(3*(5+2)*(2+6)+10);
            Console.WriteLine(u + " == " + v);
            //Console.ReadLine();
        }

	}
}