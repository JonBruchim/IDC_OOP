using System;
namespace Ex03
{

    public abstract class Vehicle
    {
        public string Model { get; set; }
        public string PlateNumber { get; set; }
        public float EnergySourcePrecentage { get; set; }
        public Wheels[] Wheels { get; set; }
    }

    public interface IElectricObject
    {
        public float BatteryHours { get; set; }
        public float MaxBatteryHours { get; set; }
        public void ChargeBattery(float batteryToAdd);
    }

    public interface IGasolineObject
    {
        public GasType GasType { get; set; }
        public float GasLiterAmount { get; set; }
        public float  MaxGasLiterAmount { get; set; }
        public void FillGas(GasType type, float gasToAdd);
    }

    public enum GasType
    {
        Soler,
        Octan95,
        Octan96,
        Octan98,
    }
}