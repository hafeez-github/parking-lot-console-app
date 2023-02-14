using System;
using ParkingLotSimulator;

namespace UserConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Operation operation = new Operation(new Data());
            Console.WriteLine("Welcome to your beloved Parking Lot");
            operation.InitialiseParking(OperationHelper.CollectSlotInputs());

            while (true) {

                int userResponse = OperationHelper.CollectMenuInput();

                switch (userResponse) {
                    case 1:
                        
                        operation.Park();
                        break;

                    case 2:
                        operation.Unpark();
                        break;

                    case 3:
                        operation.GetParkingLotStatus();
                        break;

                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
 
        }
    }
}

