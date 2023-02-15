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


        public Ticket GenerateTicket(Slot slot)
        {
            string ticketNumber = GetTicketNumber(slot.SlotType, slot.SlotNumber);

            Console.WriteLine("\nEnter vehicle number:");
            string vehicleNumber = Console.ReadLine();

            Ticket ticket = new Ticket(vehicleNumber, ticketNumber, slot.SlotNumber, slot.SlotType);
            this.Data.CurrentTickets.Add(ticket);
            return ticket;

            //Console.WriteLine("Your Ticket Number: " + Ticket.TicketNumber);
            //IOService.PrintTicket(ticket);
            
        }

        public string GetTicketNumber(VehicleType vehicleType, int slotNumber)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            string ticketNumber = vehicleType + "-" + slotNumber + "-" + timestamp;
            return ticketNumber;
        }

        public Ticket FetchTicket(string TicketNumber)
        {
            Ticket ticket=this.Data.CurrentTickets.Find(ticket=>ticket.TicketNumber==TicketNumber);
            return ticket;
        }

        public void InstantiateSlots(VehicleType vehicleType, int slotCount) {

            List<Slot> l = new List<Slot>();

            for (int i = 0; i < slotCount; i++)
            {
                l.Add(new Slot(vehicleType, i + 1));
            }

            this.Data.ParkingLot.Add(vehicleType, l);

        }

        public Slot IsSlotAvailable(VehicleType vehicleType) {

            Slot slot;

            switch (vehicleType)
            {
                case VehicleType.TwoWheeler:

                    slot = this.Data.ParkingLot[vehicleType].Find(slot => slot.IsAvailable == true);

                    if (slot == null)
                    {
                        return null;
                    }

                    else
                    {
                        return slot;
                        //    //slot.IsAvailable = false;
                        //    //this.Data.Occupied2WheelerSlots++;
                        //    //Helper.GenerateTicket(slot);
                    }

                    break;

                case VehicleType.FourWheeler:
                    slot = this.Data.ParkingLot[VehicleType.FourWheeler].Find(slot => slot.IsAvailable == true);
                    break;

                case VehicleType.HeavyVehicle:
                    slot = this.Data.ParkingLot[VehicleType.HeavyVehicle].Find(slot => slot.IsAvailable == true);
                    break;

                default:
                    slot = new Slot(VehicleType.TwoWheeler, 0);
                    break;
            }

            return slot;
        }



    }


        
}
