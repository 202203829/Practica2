namespace Practica1
{
    class VehicleWithPlate: Vehicle
    {
        private string plate;

        public VehicleWithPlate(string typeOfVehicle, string plate); base(typeOfVehicle)
        {
            this.plate = plate;
        }
        public string GetPlate()
        {
            return plate;
        }
    }
}