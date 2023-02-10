using System;
using ParkingLotSimulator;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to your beloved Parking Lot");
            Operation Operation = new Operation();
            Operation.InitialiseParking();

            while (true) {
                Console.WriteLine("Please opt for a functionality: ");
                Console.WriteLine("1. Park");
                Console.WriteLine("2. Unpark");
                Console.WriteLine("3. Parking Lot Status");
                Console.WriteLine("4. Exit");

                int UserResponse;
                try {
                    UserResponse = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e) {
                    Console.WriteLine("Check and Re-Enter your Input");
                    UserResponse = Convert.ToInt32(Console.ReadLine());
                }
                
                switch (UserResponse) {
                    case 1:
                        Operation.Park();
                        break;

                    case 2:
                        Operation.Unpark();
                        break;

                    case 3:
                        Operation.GetParkingLotStatus();
                        break;

                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
            
            

            
        }
    }
}

