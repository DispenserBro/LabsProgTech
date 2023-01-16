using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork
{
    class Program
    {
        static void Main(string[] args)
        {
            double varX;
            double varY;
            double varZ;

            Console.Write("Use the default parameters?\ny=2; t=5/(1+y2); z=4; [y|<other>]: ");

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
            varX = calculateFunc(varY, varT, varZ);

            Console.WriteLine("x = " + varX);
            Console.ReadLine();
        }

        static double calculateFunc(double y, double t, double z)
        {
            // x = (2y + 3*t)/ z 
            return (2 * y + 3 * t) / z;
        }
    }
}
