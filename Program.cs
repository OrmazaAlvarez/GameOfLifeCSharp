using System.Collections.Generic;
using System.Linq;
using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the initial state and the number of iterations");
            Console.WriteLine("Example: [0,1,0], [0,1,1], [1,0,1]:5");
            string dataInput = Console.ReadLine();
            int iterations = int.Parse( dataInput.Split(":").Last());
            string initialState = dataInput.Split(":").First();
            Console.WriteLine("In iteration #{0} the state is:{1}", iterations, Simulate(iterations, initialState));
        }

        static string Simulate(int iterations, string initialState){
            int countRows = 0, countColumns = 0;
            int[,] matriz = ConvertToArrayInt(initialState,ref countRows,ref countColumns);
            for(int countStado = 0; countStado < iterations; countStado++ )
                NextState(matriz, countRows, countColumns);
            
            return initialState;
        }

        private static int[,] ConvertToArrayInt(string arrayString, ref int countRows, ref int countColumns)
        {
            int x = 0, y; 
            arrayString = arrayString.Replace("],", "].");
            string[] filas = arrayString.Split(".");
            countRows = filas.Length;
            countColumns = filas.Max(c => c.Trim().Replace("[","").Replace("]", "").Replace(",","").Length);
            int[,] arrayInt = new int[filas.Length,countColumns];
            foreach(string fila in filas){
                y = 0;
                foreach(string valor in fila.Trim().Replace("[","").Replace("]", "").Split(",")){
                    arrayInt[x,y] = Int32.Parse(valor);
                    y++;
                }
                x++;
            }
            return arrayInt;
        }

        private static void NextState( int[,] matriz, int countRows, int countColumns){
            int[,] copyMatriz = (int[,])matriz.Clone();
            
        }
    }
}
