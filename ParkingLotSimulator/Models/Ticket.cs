using System;

namespace ParkingLotSimulator
{
    public class Ticket
    {
        public string VehicleNumber { get; set; }
        public VehicleType VehicleType { get; set; }

        public string TicketNumber { get; set; }

        public int SlotNumber { get; set; }

        public string InTime { get; set; }

        public string OutTime { get; set; }

        public Ticket(string vehicleNumber, string ticketNumber, int slotNumber, VehicleType vehicleType)
        {
            this.SlotNumber = slotNumber;
            this.VehicleNumber = vehicleNumber;
            this.TicketNumber = ticketNumber;
            this.VehicleType = vehicleType;
            this.InTime = DateTime.Now.ToString("hh:mm:ss tt");
        }
    }
}
