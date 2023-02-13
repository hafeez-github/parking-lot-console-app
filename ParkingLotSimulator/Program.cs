using System;
using ParkingLotSimulator;

namespace UserConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Transaction transaction = new Transaction(new Data());

            Console.WriteLine("Welcome to your beloved Parking Lot");
            transaction.InitialiseParking();

            while (true) {

                int userResponse = Helper.DisplayMenu();

                switch (userResponse) {
                    case 1:
                        transaction.Park();
                        break;

                    case 2:
                        transaction.Unpark();
                        break;

                    case 3:
                        transaction.GetParkingLotStatus();
                        break;

                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
 
        }
    }
}

