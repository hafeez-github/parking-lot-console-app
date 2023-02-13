using System;
using ParkingLotSimulator;

//using System.Transactions;

namespace ParkingLotSimulator
{
    public class Helper
    {
        Data Data;

        public Helper(Data data)
        {
            this.Data = data;
        }

        public static int DisplayMenu() {
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

        public void GenerateTicket(int vehicleType)
        {
            string ticketNumber = "";
            int slotNumber=0;
            switch (vehicleType)
            {
                case 0:
                   slotNumber = this.Data.ParkingLot[(int)VehicleType.TW].Count + 1;
                    ticketNumber=GetTicketNumber("TW", slotNumber);
                    Data.Occupied2WheelerSlots++;
                    break;
                case 1:
                    slotNumber = Data.ParkingLot[(int)VehicleType.FW].Count + 1;
                    ticketNumber = GetTicketNumber("FW", slotNumber);
                    this.Data.Occupied4WheelerSlots++;
                    break;
                case 2:
                    slotNumber = Data.ParkingLot[(int)VehicleType.HV].Count + 1;
                   ticketNumber = GetTicketNumber("HV", slotNumber);
                    this.Data.OccupiedHeavyVehicleSlots++;
                    break;
            }

            Console.WriteLine("\nEnter your vehicle number:");
            string VehicleNumber = Console.ReadLine();
            Ticket Ticket = new Ticket(VehicleNumber, ticketNumber, slotNumber);
            this.Data.ParkingLot[vehicleType].Add(Ticket);
            Console.WriteLine("Your Ticket Number: " + Ticket.TicketNumber);
            Console.WriteLine("Note: Ticket is required to unpark\n      your vehicle. Keep it safe.\n");
        }

        public Ticket FetchVehicle(string TicketNumber)
        {
            string vehicleType = TicketNumber.Substring(0, 2);
            Ticket ticket = new Ticket("VehicleNumber-NA", "TicketNumber-NA", 0);
            switch (vehicleType)
            {
                case "TW":

                    if (this.Data.Total2WheelerSlots == 0) {
                        Console.WriteLine("There are no 2 wheeler vehicles to unpark");
                        return ticket;
                    }

                    foreach (Ticket ticketItem in this.Data.ParkingLot[0])
                    {
                        if (ticketItem.TicketNumber.Equals(TicketNumber))
                        {
                            ticketItem.OutTime = DateTime.Now.ToString("hh:mm:ss tt");
                            ticket = ticketItem;
                            Data.Occupied2WheelerSlots--;
                            Data.ParkingLot[0].Remove(ticketItem);
                            Data.History[0].Add(ticketItem);
                            return ticket;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid Slot Number!");
                        }
                    }

                    break;

                case "FW":
                    if (this.Data.Total2WheelerSlots == 0)
                    {
                        Console.WriteLine("There are no 2 wheeler vehicles to unpark");
                        return ticket;
                    }

                    foreach (Ticket ticketItem in this.Data.ParkingLot[1])
                    {
                        if (ticketItem.TicketNumber.Equals(TicketNumber))
                        {
                            ticket.OutTime = DateTime.Now.ToString("hh:mm:ss tt");
                            ticket = ticketItem;
                            this.Data.Occupied4WheelerSlots--;
                            this.Data.History[1].Add(ticket);
                            this.Data.ParkingLot[1].Remove(ticket);
                            return ticket;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Slot Number!");
                            break;
                        }
                    }

                    break;

                case "HV":
                    if (this.Data.Total2WheelerSlots == 0)
                    {
                        Console.WriteLine("There are no 2 wheeler vehicles to unpark");
                        return ticket;
                    }

                    foreach (Ticket ticketItem in this.Data.ParkingLot[2])
                    {
                        if (ticket.TicketNumber.Equals(TicketNumber))
                        {
                            ticket.OutTime = DateTime.Now.ToString("hh:mm:ss tt");
                            ticket = ticketItem;
                            this.Data.Occupied4WheelerSlots--;
                            this.Data.History[2].Add(ticket);
                            this.Data.ParkingLot[2].Remove(ticket);
                            return ticket;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Slot Number!");
                            break;
                        }
                    }

                    break;

                default:
                    Console.WriteLine("No case matched.");
                    break;
            }

            return ticket;
        }

        public void PrintTicket(Ticket ticket)
        {
            Console.WriteLine("\n------------Parking Ticket------------");
            Console.WriteLine("Vehicle Number: " + ticket.VehicleNumber);
            Console.WriteLine("Your Ticket Number: " + ticket.TicketNumber);
            Console.WriteLine("InTime: " + ticket.InTime);
            Console.WriteLine("OutTime: " + ticket.OutTime);
            Console.WriteLine("------------Thankyou------------------\n");
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

        public string GetTicketNumber(string vehicleType, int slotNumber) {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            string ticketNumber = vehicleType + "-" + slotNumber + "-" + timestamp;
            return ticketNumber;
        }
    }
}
