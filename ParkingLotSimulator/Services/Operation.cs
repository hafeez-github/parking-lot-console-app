using System;
using System.Net.Sockets;
using ParkingLotSimulator;
using ParkingLotSimulator.Models;

namespace ParkingLotSimulator
{
    class Operation
    {
        private readonly Data Data;

        public Operation()
        {

        }

        public Operation(Data data)
        {
            this.Data = data;
        }

        public void InitialiseParking(int[] slots)
        {
            OperationHelper Helper = new OperationHelper(this.Data);

            foreach (VehicleType vehicleType in Enum.GetValues(typeof(VehicleType)))
                this.Data.SlotData.Add(vehicleType, slots[(int)vehicleType]);

            foreach (KeyValuePair<VehicleType,int> entry in Data.SlotData)
                Helper.InstantiateSlots(entry.Key, entry.Value);
        }

        public void Park(Slot slot)
        {
            slot.IsAvailable = false;
            switch (slot.SlotType)
            {
                case VehicleType.TwoWheeler:
                    Data.Occupied2WheelerSlots++;
                    break;

                case VehicleType.FourWheeler:
                    Data.Occupied4WheelerSlots++;
                    break;

                case VehicleType.HeavyVehicle:
                    Data.OccupiedHeavyVehicleSlots++;
                    break;

                default:
                    Console.WriteLine("Incorrect Vehicle Type");
                    break;
            }
        }

        public void Unpark(Ticket ticket)
        {
            int slotNumber = ticket.SlotNumber;
            Slot slot = this.Data.ParkingLot[ticket.VehicleType].Find(slot => slot.SlotNumber == slotNumber);
            slot.IsAvailable = false;

            ticket.OutTime = DateTime.Now.ToString("hh:mm:ss tt");
            this.Data.HistoricalTickets.Add(ticket);
            this.Data.CurrentTickets.Remove(ticket);

            switch (ticket.VehicleType)
            {
                case VehicleType.TwoWheeler:
                    Data.Occupied2WheelerSlots--;
                    break;

                case VehicleType.FourWheeler:
                    Data.Occupied4WheelerSlots--;
                    break;

                case VehicleType.HeavyVehicle:
                    Data.OccupiedHeavyVehicleSlots--;
                    break;

                default:
                    Console.WriteLine("Incorrect Ticket");
                    break;
            }
            
        }

        public void GetParkingLotStatus()
        {
            Console.WriteLine("\t\t Availabale Slots\t Occupied Slots\t\t Total Slots");
            Console.WriteLine("2 Wheelers:   \t\t" + (this.Data.SlotData[VehicleType.TwoWheeler] - this.Data.Occupied2WheelerSlots) + "\t\t\t" + this.Data.Occupied2WheelerSlots + "\t\t\t" + this.Data.SlotData[VehicleType.TwoWheeler]);
            Console.WriteLine("4 Wheelers:   \t\t" + (this.Data.SlotData[VehicleType.FourWheeler] - this.Data.Occupied4WheelerSlots) + "\t\t\t" + this.Data.Occupied4WheelerSlots + "\t\t\t" + this.Data.SlotData[VehicleType.FourWheeler]);
            Console.WriteLine("Heavy Vehicle:\t\t" + (this.Data.SlotData[VehicleType.HeavyVehicle] - this.Data.OccupiedHeavyVehicleSlots) + "\t\t\t" + this.Data.OccupiedHeavyVehicleSlots + "\t\t\t" + this.Data.SlotData[VehicleType.HeavyVehicle] + "\n");
        }

        public void FetchCurrentTicketList()
        {
            if (this.Data.CurrentTickets.Count == 0)
                Console.WriteLine("\nThere are no current tickets");
            else
            {
                Console.WriteLine("\nCurrent Tickets' Count: " + this.Data.CurrentTickets.Count);
                foreach (Ticket ticket in this.Data.CurrentTickets)
                {
                    Console.WriteLine($"{ticket.TicketNumber}  \t{ticket.VehicleType}\t{ticket.VehicleNumber}\t{ticket.SlotNumber}\t{ticket.InTime}\t{ticket.OutTime}");
                }
            }
                
        }

        public void FetchTicketHistory()
        {
            if (this.Data.HistoricalTickets.Count == 0)
                Console.WriteLine("\nHistory is empty");
            else
            {
                Console.WriteLine("\nTicket History Count: " + this.Data.HistoricalTickets.Count);
                foreach (Ticket ticket in this.Data.HistoricalTickets)
                {
                    Console.WriteLine($"{ticket.TicketNumber}  \t{ticket.VehicleType}\t{ticket.VehicleNumber}\t{ticket.SlotNumber}\t{ticket.InTime}\t{ticket.OutTime}");
                }
            }

        }
    }
}