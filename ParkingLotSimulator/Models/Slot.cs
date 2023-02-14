using System;
namespace ParkingLotSimulator.Models
{
	public class Slot
	{
        public VehicleType SlotType { get; set; }
        public int SlotNumber { get; set; }
		public bool IsAvailable = true;

        public Slot(VehicleType slotType, int slotNumber)
        {
			this.SlotNumber = slotNumber;
            this.SlotType = slotType;
        }

    }
}

