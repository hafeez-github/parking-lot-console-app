using System;
using System.Net.Sockets;
using ParkingLotSimulator;
using ParkingLotSimulator.Models;

namespace ParkingLotSimulator
{
    class Operation
    {
        private readonly Data Data;

        public Operation() { }

        public Operation(Data data)
        {
            this.Data = data;
        }

        public void InitialiseParking(int[] slots)
        {
            //make inputs generalised
            this.Data.Total2WheelerSlots = slots[(int)VehicleType.TW];
            this.Data.Total4WheelerSlots = slots[(int)VehicleType.FW];
            this.Data.TotalHeavyVehicleSlots = slots[(int)VehicleType.HV];


            List<Slot> l1,l2,l3;
            l1 = new List<Slot>();
            l2 = new List<Slot>();
            l3 = new List<Slot>();

            for (int i=0; i< this.Data.Total2WheelerSlots; i++) {
                l1.Add(new Slot(VehicleType.TW, i + 1));
            }

            for (int i = 0; i < this.Data.Total4WheelerSlots; i++)
            {
                l2.Add(new Slot(VehicleType.FW, i + 1));
            }

            for (int i = 0; i < this.Data.TotalHeavyVehicleSlots; i++)
            {
                l3.Add(new Slot(VehicleType.HV, i + 1));
            }

            this.Data.ParkingLot.Add(VehicleType.TW, l1);
            this.Data.ParkingLot.Add(VehicleType.FW, l2);
            this.Data.ParkingLot.Add(VehicleType.HV, l3);
        }

        public void Park()
        {
            {
                OperationHelper Helper = new OperationHelper(this.Data);
                int vehicleType = Helper.GetVehicleType();
                Slot slot;
                // use dictionary user input -> vehicle
                switch (vehicleType)
                {
                    case 1:
                        slot=this.Data.ParkingLot[VehicleType.TW].Find(slot=>slot.IsAvailable==true);

                        if ( slot==null)
                        {
                            Console.WriteLine("Sorry! There are no 2 wheeler parking slots available at the moment.");
                        }
                        else
                        {
                            slot.IsAvailable = false;
                            this.Data.Occupied2WheelerSlots++;
                            Helper.GenerateTicket(slot);
                        }

                        break;

                    case 2:
                        slot = this.Data.ParkingLot[VehicleType.FW].Find(slot => slot.IsAvailable == true);

                        if (slot == null)
                        {
                            Console.WriteLine("Sorry! There are no 4 wheeler parking slots available at the moment.");
                        }
                        else
                        {
                            slot.IsAvailable = false;
                            this.Data.Occupied4WheelerSlots++;
                            Helper.GenerateTicket(slot);
                        }

                        break;

                    case 3:
                        slot = this.Data.ParkingLot[VehicleType.HV].Find(slot => slot.IsAvailable == true);

                        if (this.Data.OccupiedHeavyVehicleSlots == this.Data.TotalHeavyVehicleSlots)
                        {
                            Console.WriteLine("Sorry! There are no heavy vehicle parking slots available at the moment.");
                        }
                        else
                        {
                            slot.IsAvailable = false;
                            this.Data.OccupiedHeavyVehicleSlots++;
                            Helper.GenerateTicket(slot);
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
                OperationHelper Helper = new OperationHelper(this.Data);

                Console.WriteLine("Enter the allotted Ticket Number:");
                string ticketNumber = Console.ReadLine();
                Ticket ticket = Helper.FetchVehicle(ticketNumber);
                
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