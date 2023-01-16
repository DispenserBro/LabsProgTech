using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork4_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number of rows: ");
            int numX = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter a number of columns: ");
            int numY = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter power of 10 (n in 10^n): ");
            int beforePoint = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter count digits after decimal point: ");
            int afterPoint = Convert.ToInt32(Console.ReadLine());

            double[,] randMatrix = ReturnRandomMatrix(numX, numY, beforePoint, afterPoint);
            double[,] transposedMartix = MatrixTransposition(randMatrix);
            ShowMatrix(randMatrix);
            ShowMatrix(transposedMartix, "Transposed matrix:\n");

            Console.ReadKey();
        }

        static double[,] MatrixTransposition(double[,] array)
        {
            double[,] transposedMatrix = new double[array.GetLength(1), array.GetLength(0)];

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    transposedMatrix[j, i] = array[i, j];

            return transposedMatrix;
        }

        static double[,] ReturnRandomMatrix(int rows, int cols, int multiplier = 2, int cut = 3)
        {
            double[,] array = new double[rows, cols];
            Random random = new Random();

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    array[i, j] = Math.Round(random.NextDouble() * Math.Pow(10, multiplier), cut);

            return array;
        }

        static void ShowMatrix(double[,] array, string msg = "Generated matrix:\n")
        {
            Console.WriteLine(msg);

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    Console.Write($"{array[i, j]}\t");

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
