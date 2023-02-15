using System;
namespace ParkingLotSimulator
{
	public class IOService
	{
        public Data Data;

        public int[] ReadSlotData()
        {
            int[] slots = new int[3];
            
            try
            {
                Console.WriteLine("\nEnter no. of 2 wheeler slots: ");
                slots[(int)VehicleType.TwoWheeler] = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter no. of 4 wheeler slots: ");
                slots[(int)VehicleType.FourWheeler] = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter no. of heavy vehicle slots: ");
                slots[(int)VehicleType.HeavyVehicle] = Convert.ToInt32(Console.ReadLine());
            }

            catch
            {
                Console.WriteLine("Check and Re-enter your Input");
                ReadSlotData();
            }

            return slots;
        }

        public int CollectMenuInput()
        {
            Console.WriteLine("\nPlease opt for a functionality: ");
            Console.WriteLine("1. Park");
            Console.WriteLine("2. Unpark");
            Console.WriteLine("3. Parking lot status");
            Console.WriteLine("4. Get current ticket list");
            Console.WriteLine("5. Get ticket list history");
            Console.WriteLine("6. Exit");

            int userResponse;
            try
            {
                userResponse = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Check and Re-Enter your Input");
                userResponse = Convert.ToInt32(Console.ReadLine());
            }

            return userResponse;
        }

        public VehicleType ReadUserVehicleType()
        {
            Console.WriteLine("\nChoose your vehicle type:");
            Console.WriteLine("1. 2 Wheeler");
            Console.WriteLine("2. 4 Wheeler");
            Console.WriteLine("3. Heavy Vehicle");

            int userResponse;
            try
            {
                userResponse = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Check and Re-Enter your Input");
                userResponse = Convert.ToInt32(Console.ReadLine());
            }

            switch (userResponse) {
                case 1:
                    return VehicleType.TwoWheeler;
                case 2:
                    return VehicleType.FourWheeler;
                case 3:
                    return VehicleType.HeavyVehicle;
                default:
                    return VehicleType.TwoWheeler;
            }

        }

        public string ReadTicketNumber()
        {
            Console.WriteLine("\nEnter the allotted Ticket Number:");
            string ticketNumber = Console.ReadLine();
            return ticketNumber;
        }

        public void PrintTicket(Ticket ticket)
        {
            Console.WriteLine("\n------------Parking-Ticket-----------------\n");
            Console.WriteLine("Vehicle Number: " + ticket.VehicleNumber);
            Console.WriteLine("Your Ticket Number: " + ticket.TicketNumber);
            Console.WriteLine("InTime: " + ticket.InTime);
            Console.WriteLine("Note: Ticket is required to unpark\n      your vehicle. Keep it safe.\n");
            Console.WriteLine("------------Thankyou-------------------------\n");
        }
    }
}

