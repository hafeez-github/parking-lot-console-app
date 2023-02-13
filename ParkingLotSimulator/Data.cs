using System;
using System.Collections;

namespace ParkingLotSimulator
{
    public class Data
    {
        //public int Total2WheelerSlots { get; set; }
        //public int Total4WheelerSlots { get; set; }
        //public int TotalHeavyVehicleSlots { get; set; }
        
        //public int Occupied2WheelerSlots { get; set; }
        //public int Occupied4WheelerSlots { get; set; }
        //public int OccupiedHeavyVehicleSlots { get; set; }

        //public List<Ticket>[] ParkingLot = new List<Ticket>[3];
        public List<Ticket>[] History = new List<Ticket>[3];

        public List<Ticket> CurrentTicketList = new List<Ticket>();
        public List<Ticket> HistoricalTicketList = new List<Ticket>();
        public Dictionary<string, int> ParkingLot = new Dictionary<string, int>();

        public Data()
		{
            History[0] = new List<Ticket>();
            History[1] = new List<Ticket>();
            History[2] = new List<Ticket>();
        }
	}
}

