using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject
{
    public class Parking<T> where T : IVehicle
    {
        public int Capacity { get; private set; }
        public int Occupancy { get; private set; }
        public int FreeCapacity
        {
            get
            {
                return Capacity - Occupancy;
            }
        }

        private List<T> parkedVehicles = new List<T>();
        public Parking()
        {

        }
        public Parking(int capacity)
        {
            Capacity = capacity;
            Occupancy = 0;
        }

        public void ParkVehicle(T vehicle)
        {
            if (FreeCapacity > 0)
            {
                Occupancy += 1;
                parkedVehicles.Add(vehicle);
                vehicle.Parking = this as Parking<IVehicle>;

            }
        }

        public void LeaveVehicle(T vehicle)
        {
            if (parkedVehicles.Contains(vehicle))
            {
                Occupancy -= 1;
                parkedVehicles.Remove(vehicle);
                vehicle.Parking = null; // *

            }
        }

    }
}
