using System;
using System.IO;
using EKRLib;

namespace Peeeeeeeeer
{
    class Program
    {
        /// <summary>
        /// В методе Main создаётся массив транспортных средств. Начиная с 17 строки происходит его заполнение. 
        /// Если при создании транспортного средства возникает исключение, оно обрабатывается и транспортное средство
        /// создаётся заново. В конце метода вызываются два метода для записи информации о транспорте в соответствующие файлы.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            Random rnd = new Random();
            Transport[] transports = new Transport[rnd.Next(6, 10)];
            for (int i = 0; i < transports.Length; i++)
            {
                Random rand = new Random();
                int id = rand.Next(2);
                bool GoodVehicle = false;
                while (!GoodVehicle)
                {
                    try
                    {
                        switch (id)
                        {
                            case 0:
                                transports[i] = CarGenerator();
                                GoodVehicle = true;
                                break;
                            case 1:
                                transports[i] = BoatGenerator();
                                GoodVehicle = true;
                                break;
                        }
                    }
                    catch (TransportException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            PrintCarsToFile(transports);
            PrintBoatsToFile(transports);
        }

        /// <summary>
        /// Метод для генерации автомобиля.
        /// </summary>
        /// <returns></returns>
        private static Car CarGenerator()
        {
            Random random = new Random();
            uint powerCar = (uint)random.Next(10, 100);
            string carModel = Transport.GetRandomModel();
            Car car = new Car(carModel, powerCar);
            Console.WriteLine(car);
            return car;
        }

        /// <summary>
        /// Метод для генерации скоростной лодки.
        /// </summary>
        /// <returns></returns>
        private static MotorBoat BoatGenerator()
        {
            Random random2 = new Random();
            uint powerMb = (uint)random2.Next(10, 100);
            string boatModel = Transport.GetRandomModel();
            MotorBoat mb = new MotorBoat(boatModel, powerMb);
            Console.WriteLine(mb);
            return mb;
        }

        /// <summary>
        /// Метод для вывода информации обо всех машинах в файл.
        /// </summary>
        /// <param name="transports"></param>
        private static void PrintCarsToFile(Transport[] transports)
        {
            try
            {
                using (StreamWriter swCars = new StreamWriter(@"..\..\..\..\Cars.txt", false, encoding: System.Text.Encoding.Unicode))
                {
                    foreach (var transport in transports)
                    {
                        if (transport.GetType().Name is "Car")
                            swCars.WriteLine(transport);
                    }
                }
            }
            catch (Exception)
            {
                PrintCarsToFile(transports);
            }
        }

        /// <summary>
        /// Метод для записи информации обо всех скоростных лодках в файл.
        /// </summary>
        /// <param name="transports"></param>
        private static void PrintBoatsToFile(Transport[] transports)
        {
            try
            {
                using (StreamWriter swBoats = new StreamWriter(@"..\..\..\..\MotorBoats.txt", false, encoding: System.Text.Encoding.Unicode))
                {
                    foreach (var transport in transports)
                    {
                        if (transport.GetType().Name is "MotorBoat")
                            swBoats.WriteLine(transport);
                    }
                }
            }
            catch (Exception)
            {
                PrintBoatsToFile(transports);
            }
        }
    }
}
