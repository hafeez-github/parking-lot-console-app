using System;
namespace ParkingLotSimulator
{
    class Operation
    {
        static int VehicleCount = 0;

        public void InitialiseParking()
        {

            try
            {
                Console.WriteLine("\nEnter no. of 2 wheeler slots: ");
                Data.Total2WheelerSlots = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter no. of 4 wheeler slots: ");
                Data.Total4WheelerSlots = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter no. of heavy vehicle slots: ");
                Data.TotalHeavyVehicleSlots = Convert.ToInt32(Console.ReadLine());

                Data.TotalSlots = Data.Total2WheelerSlots + Data.Total4WheelerSlots + Data.TotalHeavyVehicleSlots;
            }
            catch
            {
                Console.WriteLine("Check and Re-enter your Input");
                InitialiseParking();
            }

            Data.ParkingLot[(int)VehicleType.TW] = new List<Ticket>(Data.Total2WheelerSlots);
            Data.ParkingLot[(int)VehicleType.FW] = new List<Ticket>(Data.Total4WheelerSlots);
            Data.ParkingLot[(int)VehicleType.HV] = new List<Ticket>(Data.TotalHeavyVehicleSlots);

        }
        public void Park()
        {

            if (Data.TotalOccupiedSlots == Data.TotalSlots)
            {
                Console.WriteLine("\nSorry! Parking lot is full. Come again later.");
            }
            else
            {
                Console.WriteLine("\nChoose your vehicle type:");
                Console.WriteLine("1. 2 Wheeler");
                Console.WriteLine("2. 4 Wheeler");
                Console.WriteLine("3. Heavy Vehicle");
                //Console.WriteLine("4. Back");
                Console.WriteLine("4. Exit");

                int UserResponse;
                try
                {
                    UserResponse = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Check and Re-Enter your Input");
                    UserResponse = Convert.ToInt32(Console.ReadLine());
                }

                switch (UserResponse)
                {
                    case 1:
                        if (Data.Occupied2WheelerSlots == Data.Total2WheelerSlots)
                        {
                            Console.WriteLine("Sorry! There are no 2 wheeler parking slots available at the moment.");
                        }
                        else
                        {
                            GenerateTicket((int)VehicleType.TW);
                        }
                        break;

                    case 2:
                        if (Data.Occupied4WheelerSlots == Data.Total4WheelerSlots)
                        {
                            Console.WriteLine("Sorry! There are no 4 wheeler parking slots available at the moment.");
                        }
                        else
                        {
                            GenerateTicket((int)VehicleType.FW);
                        }
                        break;

                    case 3:
                        if (Data.OccupiedHeavyVehicleSlots == Data.TotalHeavyVehicleSlots)
                        {
                            Console.WriteLine("Sorry! There are no heavy vehicle parking slots available at the moment.");
                        }
                        else
                        {
                            GenerateTicket((int)VehicleType.HV);
                        }
                        break;

                    //case 4:

                    //    break;

                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public void Unpark()
        {
            if (Data.TotalOccupiedSlots == 0)
            {
                Console.WriteLine("There are no vehicles to unpark");
            }
            else {
                Console.WriteLine("Unparking Initialised");
                Console.WriteLine("Enter the allotted Slot Number:");
                string SlotNumber = Console.ReadLine();
                Ticket Ticket = FetchVehicle(SlotNumber);

                Console.WriteLine("------------Welcome------------");
                Console.WriteLine("Vehicle Number: " + Ticket.VehicleNumber);
                Console.WriteLine("Your Slot Number: " + Ticket.SlotNumber);
                Console.WriteLine("InTime: " + Ticket.InTime);
                Console.WriteLine("OutTime: " + Ticket.OutTime);
                Console.WriteLine("------------Thankyou------------\n");
            }
        }

        public void GetParkingLotStatus()
        {
            Console.WriteLine("\t\t Availabale Slots\t Occupied Slots\t\t Total Slots");
            Console.WriteLine("2 Wheelers:   \t\t" + (Data.Total2WheelerSlots - Data.Occupied2WheelerSlots) + "\t\t\t" + Data.Occupied2WheelerSlots + "\t\t\t" + Data.Total2WheelerSlots);
            Console.WriteLine("4 Wheelers:   \t\t" + (Data.Total4WheelerSlots - Data.Occupied4WheelerSlots) + "\t\t\t" + Data.Occupied4WheelerSlots + "\t\t\t" + Data.Total4WheelerSlots);
            Console.WriteLine("Heavy Vehicle:\t\t" + (Data.TotalHeavyVehicleSlots - Data.OccupiedHeavyVehicleSlots) + "\t\t\t" + Data.OccupiedHeavyVehicleSlots + "\t\t\t" + Data.TotalHeavyVehicleSlots + "\n");
        }





        public void GenerateTicket(int vehicleType)
        {
            VehicleCount++;
            Data.TotalOccupiedSlots++;
            string SlotNumber = "NA";
            switch (vehicleType)
            {
                case 0:
                    SlotNumber = "TW-" + (Data.ParkingLot[0].Count+1) + "-" + VehicleCount;
                    Data.Occupied2WheelerSlots++;
                    break;
                case 1:
                    SlotNumber = "FW-" + (Data.ParkingLot[1].Count + 1) + "-" + VehicleCount;
                    Data.Occupied4WheelerSlots++;
                    break;
                case 2:
                    SlotNumber = "HV-" + (Data.ParkingLot[2].Count + 1) + "-" + VehicleCount;
                    Data.OccupiedHeavyVehicleSlots++;
                    break;
            }
            Console.WriteLine("\nEnter your vehicle number:");
            string VehicleNumber = Console.ReadLine();
            Ticket Ticket = new Ticket(VehicleNumber, SlotNumber);
            Data.ParkingLot[vehicleType].Add(Ticket);
            Console.WriteLine("Your Slot Number: " + Ticket.SlotNumber);
            Console.WriteLine("Note: Ticket is required to unpark\n      your vehicle. Keep it safe.\n");
        }

        public Ticket FetchVehicle(string SlotNumber)
        {
            string VehicleType = SlotNumber.Substring(0, 2);
            Ticket Ticket=new Ticket("VehicleNumber-NA", "SlotNumber-NA");
            switch (VehicleType)
            {
                case "TW":
                    Console.WriteLine("First Case");
                    foreach (Ticket ticket in Data.ParkingLot[0]) {
                        if (ticket.SlotNumber.Equals(SlotNumber))
                        {
                            ticket.OutTime=DateTime.Now.ToString("hh:mm:ss tt");
                            Ticket = ticket;
                            Data.Occupied2WheelerSlots--;
                            Data.TotalOccupiedSlots--;
                            Data.AuditData[0].Add(ticket);
                            Data.ParkingLot[0].Remove(ticket);
                            return Ticket;

                        }
                        else {
                            Console.WriteLine("Invalid Slot Number!");
                        }
                    }
                    break;

                case "FW":
                    Console.WriteLine("Second Case");
                    foreach (Ticket ticket in Data.ParkingLot[1])
                    {
                        if (ticket.SlotNumber.Equals(SlotNumber))
                        {
                            ticket.OutTime = DateTime.Now.ToString("hh:mm:ss tt");
                            Ticket = ticket;
                            Data.Occupied4WheelerSlots--;
                            Data.TotalOccupiedSlots--;
                            Data.AuditData[1].Add(ticket);
                            Data.ParkingLot[1].Remove(ticket);
                            return Ticket;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Slot Number!");
                            break;
                        }
                    }
                    break;

                case "HV":
                    Console.WriteLine("Third Case");
                    foreach (Ticket ticket in Data.ParkingLot[2])
                    {
                        if (ticket.SlotNumber.Equals(SlotNumber))
                        {
                            ticket.OutTime = DateTime.Now.ToString("hh:mm:ss tt");
                            Ticket = ticket;
                            Data.Occupied4WheelerSlots--;
                            Data.TotalOccupiedSlots--;
                            Data.AuditData[2].Add(ticket);
                            Data.ParkingLot[2].Remove(ticket);
                            return Ticket;
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

            return Ticket;
            
        }
    }
}