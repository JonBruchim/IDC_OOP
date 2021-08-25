using System;
using System.Linq;

namespace Ex03
{

    public abstract class Vehicle
    {
        public string Model { get; set; }
        public string PlateNumber { get; set; }
        public float EnergySourcePrecentage { get; set; }
        public Wheels[] Wheels { get; set; }

        public Vehicle(string model, string plateNumber, Wheels[] wheels)
        {
            Model = model;
            PlateNumber = plateNumber;
            Wheels = wheels;
        }

        // Overriding Object.ToString
        public override string ToString()
        {
            string wheelStrings = string.Join(",",
                          Wheels.Select(x => x.ToString()).ToArray());

            return string.Format("Model: {0}\n" +
                "PlateNumber: {1}, Wheels: {2}",
                Model, PlateNumber, wheelStrings);
        }

    }

    public interface IElectricObject
    {
        float BatteryHours { get; set; }
        float MaxBatteryHours { get; set; }
        void ChargeBattery(float batteryToAdd);

        // Overriding Object.ToString
        /*public string ToString()
        {
            return string.Format("BatteryHours: {0}\n" +
                "MaxBatteryHours: {1}",
                BatteryHours, MaxBatteryHours);
        }*/
    }

    public interface IGasolineObject
    {
        GasType GasType { get; set; }
        float GasLiterAmount { get; set; }
        float MaxGasLiterAmount { get; set; }
        void FillGas(GasType type, float gasToAdd);

        // Overriding Object.ToString
        /*public string ToString()
        {
            return string.Format("GasLiterAmount: {0}\n" +
                "MaxGasLiterAmount: {1}",
                GasLiterAmount, MaxGasLiterAmount);
        }*/
    }

    public enum GasType
    {
        Soler,
        Octan95,
        Octan96,
        Octan98,
    }
}