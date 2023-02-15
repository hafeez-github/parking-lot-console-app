using System;
using System.Collections;
using ParkingLotSimulator.Models;

namespace ParkingLotSimulator
{
    public class Data
    {
        public int Occupied2WheelerSlots { get; set; }
        public int Occupied4WheelerSlots { get; set; }
        public int OccupiedHeavyVehicleSlots { get; set; }

        public List<Ticket> CurrentTickets = new List<Ticket>();
        public List<Ticket> HistoricalTickets = new List<Ticket>();

        public Dictionary<VehicleType, int> SlotData = new Dictionary<VehicleType, int>();
        public Dictionary<VehicleType, List<Slot>> ParkingLot = new Dictionary<VehicleType, List<Slot>>();

        public Data()
		{
           
        }
	}
}

