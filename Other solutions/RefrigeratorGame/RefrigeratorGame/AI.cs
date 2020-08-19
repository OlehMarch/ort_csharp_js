using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorGame
{
    public partial class GameEngine
    {
        internal partial class AI
        {
            public static EventHandler OnSetOfRotationsEnd;
            public static string Path { get; private set; }


            internal static void PerformSetOfRotations()
            {
                bool[,] stateMatrix;
                do
                {
                    stateMatrix = new bool[size, size];
                    int iterationQuantity = FillStateMatrix(stateMatrix);

                    for (int i = 0; i < iterationQuantity; i++)
                    {
                        int[] coords = GetCoordsFromStateMatrix(stateMatrix);
                        RotateNode(coords[0], coords[1]);
                        stateMatrix[coords[0], coords[1]] = false;

                        Path += "{" + coords[0] + "; " + coords[1] + "}, ";
                        OnSetOfRotationsEnd(null, null);
                    }
                    Path += "\n";
                }
                while (!CheckState());

                Path = Path.Remove(Path.LastIndexOf(","));
            }

            private static int FillStateMatrix(bool[,] stateMatrix)
            {
                int iterationQuantity = 0;

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        bool value;
                        if (field[i, j] == 1)
                        {
                            value = true;
                            iterationQuantity++;
                        }
                        else
                        {
                            value = false;
                        }

                        stateMatrix[i, j] = value;
                    }
                }

                return iterationQuantity;
            }

            private static int[] GetCoordsFromStateMatrix(bool[,] stateMatrix)
            {
                int[] coords = new int[2];

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (stateMatrix[i, j] == true)
                        {
                            coords[0] = i;
                            coords[1] = j;
                            break;
                        }
                    }
                }

                return coords;
            }

            private static bool CheckState()
            {
                bool result = true;

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (field[i, j] == 1)
                        {
                            result = false;
                            break;
                        }
                    }
                    if (result == false)
                    {
                        break;
                    }
                }

                return result;
            }

        }
    }
    
}
