using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorGame
{
    public partial class GameEngine
    {
        internal partial class AI { }

        public GameEngine()
        {
            Turns = 0;
            Log = "";
            size = 4;
            field = new int[size, size];
            
            AI.OnSetOfRotationsEnd += new EventHandler(OnSetOfRotationsEnd_Handler);

            RandomGenerator();
        }


        public string Log { get; private set; }
        public int Turns { get; private set; }
        protected static int[,] field;
        protected static int size;
        

        public void StartAI()
        {
            AI.PerformSetOfRotations();
        }

        public string GetPathOfCalculation()
        {
            return AI.Path;
        }

        public void RandomGenerator()
        {
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    field[i, j] = random.Next(0, 2);
                }
            }
        }

        public static void RotateNode(int x, int y)
        {
            if (x >= 0 && x < size && y >= 0 && y < size)
            {
                for (int i = 0; i < size; i++)
                {
                    field[i, y] = Math.Abs(field[i, y] - 1);
                }
                for (int j = 0; j < size; j++)
                {
                    field[x, j] = Math.Abs(field[x, j] - 1);
                }
                field[x, y] = Math.Abs(field[x, y] - 1);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public override string ToString()
        {
            string res = "";

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    res += field[i, j] + " ";
                }
                res += "\n";
            }

            return res;
        }

        public int[,] ToArray()
        {
            int[,] newField = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    newField[i, j] = field[i, j];
                }
            }

            return newField;
        }

        private void OnSetOfRotationsEnd_Handler(object sender, EventArgs e)
        {
            Turns++;
            Log += ToString() + "\n";
        }

    }
}
