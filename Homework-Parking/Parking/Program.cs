using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Parking<Car> poc = new Parking<Car>(100);
            Car astra = new Car
            {
                Make = "Opel",
                Model = "Astra"
            };
            
            poc.ParkVehicle(astra);
            poc.LeaveVehicle(astra);

            Parking<Boat> marina = new Parking<Boat>(50);
            Boat jenny = new Boat() { Name = "Jenny", BesPlatno = true };
            Boat jenny1 = new Boat() { Name = "Jenny1", BesPlatno = true };
            Boat jenny2 = new Boat() { Name = "Jenny2", BesPlatno = true };
            Boat jenny3 = new Boat() { Name = "Jenny3", BesPlatno = true };

            marina.ParkVehicle(jenny);
            marina.ParkVehicle(jenny1);
            marina.ParkVehicle(jenny2);
            marina.ParkVehicle(jenny3);
            marina.LeaveVehicle(jenny2);

            Console.WriteLine(marina.FreeCapacity);
            Console.WriteLine(marina.Occupancy);
            Console.WriteLine(poc.FreeCapacity);
        }
    }
}
