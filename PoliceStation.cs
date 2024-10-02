namespace Practica1
{
    class PoliceStation : IMessageWritter
    {
        public List<PoliceCar> policeCars { get; private set; }
        private City city;
       
        public PoliceStation(City city)
        {
            this.policeCars = new List<PoliceCar>();
            this.city = city;
        }
        public override string ToString()
        {
            return $"Police Station in {city.GetName}";
        }
        public void RegisterPlate(PoliceCar policeCar)
        {
            policeCars.Add(policeCar);
        }

        public void AlertPoliceCars(string plate)
        {
            foreach (PoliceCar policeCar in policeCars) 
            {
                policeCar.GetNotified(plate);
            } 
        }
        public string WriteMessage(string message)
        {
            return $"{this}: {message}";
        }
    }
}