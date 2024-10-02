namespace Practica1
{
    class PoliceCar : VehicleWithPlate
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car"; 
        private bool isPatrolling;
        private SpeedRadar speedRadar;
        private bool isChasing;
        private string chasedCar;
        private PoliceStation policeStation;

        public PoliceCar(string plate, PoliceStation policeStation, bool hasSpeedRadar) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            isChasing = false;
            if (hasSpeedRadar)
            {
                speedRadar = new SpeedRadar();
            }
            else
            {
                speedRadar = null;
            }
            chasedCar = null;
            this.policeStation = policeStation;
            policeStation.RegisterPlate(this);
        }

        public void UseRadar(VehicleWithPlate vehicle)
        {
            if (speedRadar != null) {
                if (isPatrolling)
                {
                    speedRadar.TriggerRadar(vehicle);
                    bool meassurement = speedRadar.GetLastReading();
                    if (meassurement)
                    {
                        Console.WriteLine(WriteMessage($"Triggered radar. Result: Catched above legal speed."));
                        NotifyInfractor(vehicle.GetPlate());
                    }
                    else
                    {
                        Console.WriteLine(WriteMessage($"Triggered radar. Result: Driving Legally."));
                    }
                }
                else
                {
                    Console.WriteLine(WriteMessage($"has no active radar."));
                }
            }
            else
            {
                Console.WriteLine(WriteMessage($"has no radar"));
            }
        }

        public bool IsPatrolling()
        {
            return isPatrolling;
        }
        
        public bool IsChasing()
        { 
            return isChasing; 
        }
        public void StartPatrolling()
        {
            if (!isPatrolling)
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage("started patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already patrolling."));
            }
        }
        public void EndPatrolling()
        {
            if (isPatrolling)
            {
                isPatrolling = false;
                Console.WriteLine(WriteMessage("stopped patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("was not patrolling."));
            }
        }

        public void NotifyInfractor(string plate) 
        {
            policeStation.AlertPoliceCars(plate);
        }

        public void GetNotified(string plate)
        {
            if (isPatrolling)
            {
                isChasing = true;
                chasedCar = plate;
                Console.WriteLine(WriteMessage($"chasing car with plate {plate}"));
            }
        }


        public void PrintRadarHistory()
        {
            if (speedRadar != null)
            {
                Console.WriteLine(WriteMessage("Report radar speed history:"));
                foreach (float speed in speedRadar.SpeedHistory)
                {
                    Console.WriteLine(speed);
                }
            }
            else
            {
                Console.WriteLine(WriteMessage("had no radar"));
            }
        }
    }
}