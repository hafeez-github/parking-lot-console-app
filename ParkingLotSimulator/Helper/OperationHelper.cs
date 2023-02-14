using System;
using System.Net.Sockets;
using ParkingLotSimulator;
using ParkingLotSimulator.Models;

//using System.Transactions;

namespace ParkingLotSimulator
{
    public class OperationHelper
    {
        Data Data;

        public OperationHelper(Data data)
        {
            this.Data = data;
        }

        public static int[] CollectSlotInputs() {
            int[] slots = new int[3];
            try
            {
                Console.WriteLine("\nEnter no. of 2 wheeler slots: ");
                slots[(int)VehicleType.TW] = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter no. of 4 wheeler slots: ");
                slots[(int)VehicleType.FW] = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter no. of heavy vehicle slots: ");
                slots[(int)VehicleType.HV] = Convert.ToInt32(Console.ReadLine());
            }

            catch
            {
                Console.WriteLine("Check and Re-enter your Input");
                CollectSlotInputs();
            }

            return slots;
        }

        public static int CollectMenuInput()
        {
            Console.WriteLine("\nPlease opt for a functionality: ");
            Console.WriteLine("1. Park");
            Console.WriteLine("2. Unpark");
            Console.WriteLine("3. Parking Lot Status");
            Console.WriteLine("4. Exit");

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

        public int GetVehicleType()
        {
            Console.WriteLine("\nChoose your vehicle type:");
            Console.WriteLine("1. 2 Wheeler");
            Console.WriteLine("2. 4 Wheeler");
            Console.WriteLine("3. Heavy Vehicle");
            Console.WriteLine("4. Exit");

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

        public void GenerateTicket(Slot slot)
        {
            string ticketNumber = GetTicketNumber(slot.SlotType, slot.SlotNumber);

            Console.WriteLine("\nEnter vehicle number:");
            string vehicleNumber = Console.ReadLine();

            Ticket ticket = new Ticket(vehicleNumber, ticketNumber, slot.SlotNumber);
            this.Data.CurrentTickets.Add(ticket);

            //Console.WriteLine("Your Ticket Number: " + Ticket.TicketNumber);
            PrintTicket(ticket);
            
        }

        public string GetTicketNumber(VehicleType vehicleType, int slotNumber)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            string ticketNumber = vehicleType + "-" + slotNumber + "-" + timestamp;
            return ticketNumber;
        }

        public Ticket FetchVehicle(string TicketNumber)
        {

            Ticket ticket=this.Data.CurrentTickets.Find(ticket=>ticket.TicketNumber==TicketNumber);
            ticket.OutTime = DateTime.Now.ToString("hh:mm:ss tt");
            this.Data.HistoricalTickets.Add(ticket);
            this.Data.CurrentTickets.Remove(ticket);
            int slotNumber = ticket.SlotNumber;
            string vehicleType = TicketNumber.Substring(0, 2);

            switch (vehicleType)
            {
                case "TW":
                    Slot TWSlot=this.Data.ParkingLot[VehicleType.TW].Find(slot=>slot.SlotNumber==slotNumber);
                    TWSlot.IsAvailable = false;
                    Data.Occupied2WheelerSlots--;
                    return ticket;
                    
                case "FW":
                    Slot FWSlot = this.Data.ParkingLot[VehicleType.TW].Find(slot => slot.SlotNumber == slotNumber);
                    FWSlot.IsAvailable = false;
                    Data.Occupied4WheelerSlots--;
                    return ticket;

                case "HV":
                    Slot HVSlot = this.Data.ParkingLot[VehicleType.TW].Find(slot => slot.SlotNumber == slotNumber);
                    HVSlot.IsAvailable = false;
                    Data.OccupiedHeavyVehicleSlots--;
                    return ticket;

                default:
                    Console.WriteLine("No case matched.");
                    break;
            }
            
            return ticket;
        }

        public void PrintTicket(Ticket ticket)
        {
            Console.WriteLine("\n------------Parking-Ticket-----------------");
            Console.WriteLine("Vehicle Number: " + ticket.VehicleNumber);
            Console.WriteLine("Your Ticket Number: " + ticket.TicketNumber);
            Console.WriteLine("InTime: " + ticket.InTime);
            Console.WriteLine("OutTime: " + ticket.OutTime);
            Console.WriteLine("Note: Ticket is required to unpark\n      your vehicle. Keep it safe.\n");
            Console.WriteLine("------------Thankyou-------------------------\n");
        }
        
    }
}
