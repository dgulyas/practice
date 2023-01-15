namespace parserTest
{

	public class Program
	{
		static void Main(string[] args)
		{
			//(var e, var r) = BreakString("890(1234)56()78");
			//var z = Calc("2*3+2*3+3+5*6+5"); //50
			//var x = Split(" a+(b+c)*(d*(e+f)*(g+h)+i)", '(' );

			var u = Parser1.Parse("2+(4+1)*(3*(5+2)*(2+6)+10)");
			var v =                2+(4+1)*(3*(5+2)*(2+6)+10);

			Console.WriteLine(u + " == " + v);
			Console.ReadLine();
		}

	}
}