namespace ParkingProject
{
    public class Car : IVehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public bool IsDiesel { get; set; }
        public bool IsElectric { get; set; }

        public bool IsParked
        {
            get
            {
                return Parking != null;
            }
        }
        public Parking<IVehicle> Parking { get; set; }
    }
}