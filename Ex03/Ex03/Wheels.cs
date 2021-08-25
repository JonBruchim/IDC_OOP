namespace Ex03
{
    public class Wheels
    {
        public string Manufacture { get; set; }
        public float AirPressure { get; set; }
        public readonly float MaxAirPressure;

        public Wheels(string manufacture, float airPressure, float maxAirPressure)
        {
            this.Manufacture = manufacture;
            this.AirPressure = airPressure;
            MaxAirPressure = maxAirPressure;
        }

        public void FillAir(float airToAdd)
        {
            if (AirPressure + airToAdd > MaxAirPressure)
            {
                throw new ValueOutOfRangeException("air pressure to fill out of range", 0, MaxAirPressure);
            }

            AirPressure += airToAdd;
        }
    }
}