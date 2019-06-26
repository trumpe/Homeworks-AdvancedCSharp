using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject
{
    public class Boat : IVehicle
    {
        public string Name { get; set; }
        public bool BesPlatno { get; set; }
        public Parking<IVehicle> Parking { get; set; }
    }
}
