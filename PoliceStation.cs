namespace Practica1
{
    class PoliceStation : IMessageWritter
    {
        public List<PoliceCar> policeCars { get; private set; };
        private bool detectedInfractor;
    }
}