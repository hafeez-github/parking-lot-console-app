using System;
using System.Collections;

namespace ParkingLotSimulator
{
    public class Data
    {
        public static int Total2WheelerSlots { get; set; }
        public static int Total4WheelerSlots { get; set; }
        public static int TotalHeavyVehicleSlots { get; set; }
        public static int TotalSlots;


        public static int Occupied2WheelerSlots { get; set; }
        public static int Occupied4WheelerSlots { get; set; }
        public static int OccupiedHeavyVehicleSlots { get; set; }
        public static int TotalOccupiedSlots = Occupied2WheelerSlots + Occupied4WheelerSlots + OccupiedHeavyVehicleSlots;

        public static List<Ticket>[] ParkingLot = new List<Ticket>[3];

        public static List<Ticket>[] AuditData = new List<Ticket>[3];
        

        static Data()
		{
            AuditData[0] = new List<Ticket>();
            AuditData[1] = new List<Ticket>();
            AuditData[2] = new List<Ticket>();
        }
	}
}

