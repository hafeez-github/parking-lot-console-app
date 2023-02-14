using System;
using System.Collections;
using ParkingLotSimulator.Models;

namespace ParkingLotSimulator
{
    public class Data
    {
        public int Total2WheelerSlots { get; set; }
        public int Total4WheelerSlots { get; set; }
        public int TotalHeavyVehicleSlots { get; set; }

        public int Occupied2WheelerSlots { get; set; }
        public int Occupied4WheelerSlots { get; set; }
        public int OccupiedHeavyVehicleSlots { get; set; }

        public List<Ticket> CurrentTickets = new List<Ticket>();
        public List<Ticket> HistoricalTickets = new List<Ticket>();

        public Dictionary<VehicleType, List<Slot>> ParkingLot = new Dictionary<VehicleType, List<Slot>>();

        public Data()
		{
           
        }
	}
}

