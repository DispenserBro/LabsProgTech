using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork3
{
    class Flight
    {
        public string flightNumber;
        public string departurePoint;
        public string destinationPoint;
        public string flightPilot;

        public int departureTime;
        public int flightTime;
        public int arrivalTime;

        public void ShowInfo()
        {
            int hour = 60;

            int depHours = departureTime / hour;
            int depMinutes = departureTime % hour;

            int flightHours = flightTime / hour;
            int flightMinutes = flightTime % hour;

            int arrivalHours = arrivalTime / hour;
            int arrivalMinutes = arrivalTime % hour;

            Console.WriteLine($"Рейс № {flightNumber}:\n\t{departurePoint} ---> {destinationPoint}\n\tПилот: {flightPilot}\n\tОтправление - прибытие: {depHours}:{depMinutes} - {arrivalHours}:{arrivalMinutes}\n\tВремя в полете: {flightHours}ч. {flightMinutes}мин.\n");
        }

        public void DelayFlight()
        {

        }

        public Flight()
        {
            flightNumber = "NULL";
            departurePoint = "NULL";
            destinationPoint = "NULL";
            flightPilot = "NULL";

            departureTime = 0;
            flightTime = 0;
            arrivalTime = departureTime + flightTime;
        }

        public Flight(string number, string departure, string destination)
        {
            flightNumber = number;
            departurePoint = departure;
            destinationPoint = destination;
            flightPilot = "NULL";

            departureTime = 0;
            flightTime = 0;
            arrivalTime = departureTime + flightTime;
        }

        public Flight(string number, string departure, string destination, string pilot)
        {
            flightNumber = number;
            departurePoint = departure;
            destinationPoint = destination;
            flightPilot = pilot;

            departureTime = 0;
            flightTime = 0;
            arrivalTime = departureTime + flightTime;
        }

        public Flight(string number, string departure, string destination, string pilot, int depTime, int flightDur)
        {
            flightNumber = number;
            departurePoint = departure;
            destinationPoint = destination;
            flightPilot = pilot;

            departureTime = depTime;
            flightTime = flightDur;
            arrivalTime = departureTime + flightTime;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Flight flight = new Flight("F-201B", "New York", "LA");
            flight.ShowInfo();

            Console.ReadKey();
        }
    }
}
