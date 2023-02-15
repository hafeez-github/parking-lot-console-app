using System;
using ParkingLotSimulator;
using ParkingLotSimulator.Models;

namespace UserConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Data data = new Data();
            Operation operation = new Operation(data);
            OperationHelper helper = new OperationHelper(data);
            IOService io = new IOService();

            Console.WriteLine("Welcome to your beloved Parking Lot");
            int[] slotData = io.ReadSlotData();
            operation.InitialiseParking(slotData);

            while (true)
            {
                int userResponse = io.CollectMenuInput();
                Ticket ticket;

                switch (userResponse)
                {
                    case 1:
                        VehicleType vehicleType = io.ReadUserVehicleType();
                        Slot slot = helper.IsSlotAvailable(vehicleType);

                        if ( slot== null)
                        {
                            Console.WriteLine("\n***No available slots.");
                        }
                        else
                        {
                            operation.Park(slot);
                            ticket=helper.GenerateTicket(slot);
                            io.PrintTicket(ticket);
                        }

                        break;

                    case 2:
                        string ticketNumber = io.ReadTicketNumber();
                        ticket = helper.FetchTicket(ticketNumber);
                        operation.Unpark(ticket);
                        Console.WriteLine("Successfully unparked");
                        break;

                    case 3:
                        operation.GetParkingLotStatus();
                        break;

                    case 4:
                        operation.FetchCurrentTicketList();
                        break;

                    case 5:
                        operation.FetchTicketHistory();
                        break;

                    case 6:
                        Environment.Exit(0);
                        break;

                }
            }

        }
    }
}

