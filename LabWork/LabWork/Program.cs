using System;

namespace LabWork
{
    class Program
    {
        static void Main(string[] args)
        {
            double varX;
            double varY;
            double varZ;

            Console.Write("Use the default parameters?\ny=2; z=4; t=5/(1+y^2) [y|<other>]: ");

            string decision = Console.ReadLine();

            switch (decision) {
                case "y":
                    varY = 2;
                    varZ = 4;

                    break;

                default:
                    Console.Write("Enter the \"y\" parameter: ");
                    varY = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter the \"z\" parameter: ");
                    varZ = Convert.ToDouble(Console.ReadLine());
                    break;
            }

            double varT = 5 / (1 + Math.Pow(varY, 2));
            varX = (2 * y + 3 * t) / z;

            Console.WriteLine("x = " + varX);

            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
