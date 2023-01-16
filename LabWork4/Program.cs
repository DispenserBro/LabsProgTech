using System;

namespace LabWork4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number of elements: ");
            int arraySize = Convert.ToInt32(Console.ReadLine());

            double[] mySuperDuperArray = ReturnEnteredArray(arraySize);
            ShowArray(mySuperDuperArray);

            Console.WriteLine("Summ of array elements: " + ReturnArrSum(mySuperDuperArray));

            Console.ReadKey();
        }

        static double ReturnArrSum(double[] array)
        {
            double sum = 0;

            foreach (double el in array) sum += el;

            return sum;
        }

        static double[] ReturnEnteredArray(int size)
        {
            double[] array = new double[size];
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Enter the {i + 1} element of the array: ");
                array[i] = Convert.ToDouble(Console.ReadLine());
            }
            return array;
        }

        static void ShowArray(double[] array, string msg = "\nGenerated array:")
        {
            Console.WriteLine(msg);

            foreach (double el in array) Console.Write(el + " ");

            Console.WriteLine("\n");
        }
    }
}
