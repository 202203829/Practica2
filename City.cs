namespace Practica1
{
    class City: IMessageWritter
    {
        private string name;
        public List<Taxi> taxiLicenses { get; private set; }

        public City (string name)
        {
            this.name = name;
            this.taxiLicenses = new List<Taxi> ();
        }
        public override string ToString()
        {
            return $"City with name {GetName()}";
        }

        public string GetName()
        {
            return name;
        }

        public void RegisterTaxi(Taxi taxi)
        {
            taxiLicenses.Add(taxi);
            Console.WriteLine(WriteMessage($"Taxi with plate {taxi.GetPlate()} added license"));
        }
        
        public void RemoveTaxi(Taxi taxi)
        {
            if (taxiLicenses.Remove(taxi))
            {
                Console.WriteLine(WriteMessage($"Taxi with plate {taxi.GetPlate()} remove license"));
            }
            else
            {
                Console.WriteLine(WriteMessage($"Taxi with plate {taxi.GetPlate()} did not have a license"));
            }
        }
        public string WriteMessage(string message)
        {
            return $"{this}: {message}";
        }
    }
}