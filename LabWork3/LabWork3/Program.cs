using System;

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

        public static void ShowNotification(string msg, int level = 0, char delimiter = '-')
        {
            string[] notificationLevels = new string[] {"INFO", "WARNING", "CRITICAL" };
            string msgPrefix = notificationLevels[level % notificationLevels.Length];

            string delimiterString = new string(delimiter, 40);
            Console.WriteLine($"\n{delimiterString}\n{msgPrefix}: {msg}\n{delimiterString}\n");
        }

        public static string getTimeString(int timeMinutes)
        {
            int hour = 60;

            timeMinutes %= hour*24;

            return $"{timeMinutes / hour:d2}:{timeMinutes % hour:d2}";
        }

        public void ShowInfo()
        {
            int flightHours = flightTime / 60;
            int flightMinutes = flightTime % 60;

            // Старая версия
            //Console.WriteLine($"Рейс № {flightNumber}:\n\t{departurePoint} ---> {destinationPoint}\n\tПилот: {flightPilot}\n\tОтправление - прибытие: {depHours}:{depMinutes:d2} - {arrivalHours}:{arrivalMinutes:d2}\n\tВремя в полете: {flightHours}ч. {flightMinutes}мин.\n");
            Console.WriteLine($"Рейс № {flightNumber}:");
            Console.WriteLine($"\t{departurePoint} ---> {destinationPoint}");
            Console.WriteLine($"\tПилот: {flightPilot}");
            Console.WriteLine($"\tОтправление - прибытие: {getTimeString(departureTime)} - {getTimeString(arrivalTime)}");
            Console.WriteLine($"\tВремя в полете: {flightHours} ч. {flightMinutes} мин.\n");
        }

        public void DelayFlight(int delayTime = 60)
        {
            if (flightNumber != "NULL" & delayTime > 0)
            {
                departureTime += delayTime;
                arrivalTime = departureTime + flightTime;
                ShowNotification($"Рейс № {flightNumber} задержан до {getTimeString(departureTime)}");
            }
            else
            {
                if (flightNumber == "NULL") ShowNotification("Сначала задайте номер рейса!", 1);
                else if (delayTime <= 0) ShowNotification("Рейс можно только задержать!", 2);
            }
        }

        public Flight() : this("NULL", "NULL", "NULL")
        {
        }

        public Flight(string number, string departure, string destination) : this(number, departure, destination, "NULL")
        {
        }

        public Flight(string number, string departure, string destination, string pilot) : this(number, departure, destination, pilot, 0, 0)
        {
        }

        public Flight(string number, string departure, string destination, string pilot, int depTime, int flightDuration)
        {
            flightNumber = number;
            departurePoint = departure;
            destinationPoint = destination;
            flightPilot = pilot;

            departureTime = depTime;
            flightTime = flightDuration;
            arrivalTime = departureTime + flightTime;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Пустой рейс для примера
            Flight.ShowNotification("Первый рейс", delimiter: '*');

            Flight testFlight = new Flight();
            // Везде покажет 0 или NULL
            testFlight.ShowInfo();

            testFlight.DelayFlight();
            // После того, как покажется оповещение, меняем номер рейса
            testFlight.flightNumber = "F-200B";
            // Пытаемся отложить на отрицательное время, видим оповещение
            testFlight.DelayFlight(-100);
            // Меняем время полета с 0 минут на 120 минут
            testFlight.flightTime = 120;
            // Правильно откладываем рейс
            testFlight.DelayFlight(600);
            // Вуаля!
            testFlight.ShowInfo();

            // Пример правильного рейса
            Flight.ShowNotification("Второй рейс", delimiter: '*');

            Flight flight = new Flight(number: "F-201B",
                                       departure: "London",
                                       destination: "Moscow",
                                       pilot: "Till Lindemann",
                                       depTime: 600,
                                       flightDuration: 245);
            flight.ShowInfo();

            // Пример с инициализатором объектов, приходится вносить время прибытия вручную
            Flight.ShowNotification("Третий рейс", delimiter: '*');

            Flight flight2 = new Flight {
                flightNumber = "F-201B",
                departurePoint = "NYC",
                destinationPoint = "Singapore",
                flightPilot = "Dan Reynolds",
                departureTime = 720,
                flightTime = 720,
                arrivalTime = 1440
            };

            flight2.ShowInfo();
            // Отложим рейс и посмотрим, что будет
            flight2.DelayFlight();
            // Все сработало)
            flight2.ShowInfo();

            Console.Write("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
