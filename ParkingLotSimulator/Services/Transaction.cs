using System;
using ParkingLotSimulator;

namespace ParkingLotSimulator
{
    class Transaction
    {
        private readonly Data Data;

        public Transaction() { }

        public Transaction(Data data)
        {
            this.Data = data;
        }

        public void InitialiseParking()
        {
            try
            {
                Console.WriteLine("\nEnter no. of 2 wheeler slots: ");
                this.Data.Total2WheelerSlots = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter no. of 4 wheeler slots: ");
                this.Data.Total4WheelerSlots = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter no. of heavy vehicle slots: ");
                this.Data.TotalHeavyVehicleSlots = Convert.ToInt32(Console.ReadLine());
            }

            catch
            {
                Console.WriteLine("Check and Re-enter your Input");
                InitialiseParking();
            }

            this.Data.ParkingLot[(int)VehicleType.TW] = new List<Ticket>(this.Data.Total2WheelerSlots);
            this.Data.ParkingLot[(int)VehicleType.FW] = new List<Ticket>(this.Data.Total4WheelerSlots);
            this.Data.ParkingLot[(int)VehicleType.HV] = new List<Ticket>(this.Data.TotalHeavyVehicleSlots);
        }

        public void Park()
        {
            {
                Helper Helper = new Helper(this.Data);
                int UserResponse = Helper.GetVehicleType();
                switch (UserResponse)
                {
                    case 1:
                        if (this.Data.Occupied2WheelerSlots == this.Data.Total2WheelerSlots)
                        {
                            Console.WriteLine("Sorry! There are no 2 wheeler parking slots available at the moment.");
                        }
                        else
                        {
                            Helper.GenerateTicket((int)VehicleType.TW);
                        }

                        break;

                    case 2:
                        if (this.Data.Occupied4WheelerSlots == this.Data.Total4WheelerSlots)
                        {
                            Console.WriteLine("Sorry! There are no 4 wheeler parking slots available at the moment.");
                        }
                        else
                        {
                            Helper.GenerateTicket((int)VehicleType.FW);
                        }

                        break;

                    case 3:
                        if (this.Data.OccupiedHeavyVehicleSlots == this.Data.TotalHeavyVehicleSlots)
                        {
                            Console.WriteLine("Sorry! There are no heavy vehicle parking slots available at the moment.");
                        }
                        else
                        {
                            Helper.GenerateTicket((int)VehicleType.HV);
                        }

                        break;

                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public void Unpark()
        {
            {
                Helper Helper = new Helper(this.Data);

                Console.WriteLine("\nUnparking Initialised");
                Console.WriteLine("Enter the allotted Ticket Number:");
                string ticketNumber = Console.ReadLine();
                Ticket ticket = Helper.FetchVehicle(ticketNumber);
                Helper.PrintTicket(ticket);
            }
        }

        public void GetParkingLotStatus()
        {
            Console.WriteLine("\t\t Availabale Slots\t Occupied Slots\t\t Total Slots");
            Console.WriteLine("2 Wheelers:   \t\t" + (this.Data.Total2WheelerSlots - this.Data.Occupied2WheelerSlots) + "\t\t\t" + this.Data.Occupied2WheelerSlots + "\t\t\t" + this.Data.Total2WheelerSlots);
            Console.WriteLine("4 Wheelers:   \t\t" + (this.Data.Total4WheelerSlots - this.Data.Occupied4WheelerSlots) + "\t\t\t" + this.Data.Occupied4WheelerSlots + "\t\t\t" + this.Data.Total4WheelerSlots);
            Console.WriteLine("Heavy Vehicle:\t\t" + (this.Data.TotalHeavyVehicleSlots - this.Data.OccupiedHeavyVehicleSlots) + "\t\t\t" + this.Data.OccupiedHeavyVehicleSlots + "\t\t\t" + this.Data.TotalHeavyVehicleSlots + "\n");
        }
    }
}