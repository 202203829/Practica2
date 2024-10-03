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
            return $"Police Station in {city.GetName()}";
        }
        public void RegisterPlate(PoliceCar policeCar)
        {
            policeCars.Add(policeCar);
            Console.WriteLine(WriteMessage($"Police Car with plate {policeCar.GetPlate()} added to {city.GetName()}'s Police Station"));
        }

        public void AlertPoliceCars(string plate)
        {
            Console.WriteLine(WriteMessage($"Alerting all police cars"));
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