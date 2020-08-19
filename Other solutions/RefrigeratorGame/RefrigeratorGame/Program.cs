using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEngine engine = new GameEngine();

            Console.WriteLine(engine.ToString().Replace("0", "-").Replace("1", "|"));
            engine.StartAI();
            Console.WriteLine(engine.Log.Replace("0", "-").Replace("1", "|"));

            Console.WriteLine(engine.Turns);
            Console.WriteLine(engine.GetPathOfCalculation());

            Console.ReadKey();
        }
    }
}
