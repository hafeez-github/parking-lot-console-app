using System;
namespace ParkingLotSimulator
{
	public class Ticket
	{
		public string VehicleNumber { get; set; }
        public string SlotNumber { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public Ticket(string VehicleNumber, string SlotNumber)
		{
            this.VehicleNumber = VehicleNumber;
            this.SlotNumber = SlotNumber;
            InTime = DateTime.Now.ToString("hh:mm:ss tt");
        }

	}
}

