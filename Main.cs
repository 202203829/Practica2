namespace Practica1
{
    internal class Program
    {

        static void Main()
        {
            City city = new City("Madrid");
            PoliceStation policeStation = new PoliceStation(city);
            Console.WriteLine(city.WriteMessage("Created"));
            Console.WriteLine(policeStation.WriteMessage("Created"));

            Taxi taxi1 = new Taxi("0001 AAA", city);
            Taxi taxi2 = new Taxi("0002 BBB", city);
            Taxi taxi3 = new Taxi("0003 CCC", city);
            PoliceCar policeCar1 = new PoliceCar("0001 CNP", policeStation, true);
            PoliceCar policeCar2 = new PoliceCar("0002 CNP", policeStation, true);
            PoliceCar policeCar3 = new PoliceCar("0003 CNP", policeStation, false);

            policeCar1.StartPatrolling();
            policeCar1.UseRadar(taxi1);
            policeCar3.StartPatrolling();
            policeCar3.UseRadar(taxi1);

            taxi2.StartRide();
            policeCar2.UseRadar(taxi2);
            policeCar2.StartPatrolling();
            policeCar2.UseRadar(taxi2);
            taxi2.StopRide();

            taxi1.StartRide();
            taxi1.StartRide();
            policeCar1.StartPatrolling();
            policeCar1.UseRadar(taxi1);
            taxi1.StopRide();
            taxi1.StopRide();
            policeCar1.EndPatrolling();

            taxi3.StartRide();
            policeCar3.StartPatrolling();
            taxi3.StopRide();

            city.RemoveTaxi(taxi1);
            city.RemoveTaxi(taxi2);

            policeCar1.PrintRadarHistory();
            policeCar2.PrintRadarHistory();
            policeCar3.PrintRadarHistory();

        }
    }
}
    

