using System;
namespace Ex03
{
    public abstract class Car : Vehicle
    {
        const int MaxDoors = 5;
        const int MinDoors = 2;

        #region Members and Props
        #region Members
        private Color m_Color;
        private int m_Doors;
        #endregion Members

        #region Props
        public Color Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        public int Doors
        {
            get { return m_Doors; }
            set
            {
                if (value < MinDoors || value > MaxDoors)
                {
                    throw new ValueOutOfRangeException("Truck door count isn't valid", MinDoors, MaxDoors);
                }

                m_Doors = value;
            }
        }
        #endregion Props
        #endregion Members and Props

        public Car(string model, string plateNumber, Wheels[] wheels, Color color, int doors)
            : base(model, plateNumber, wheels)
        {
            Color = color;
            Doors = doors;
        }

        // Overriding Object.ToString
        public override string ToString()
        {
            return string.Format("Color: {0}\n" +
                "Doors: {1}",
                Color, Doors);
        }
    }

    public enum Color
    {
        Yellow,
        White,
        Black,
        Blue,
    }


    public class GasolineCar : Car, IGasolineObject
    {
        public void FillGas(GasType type, float gasToAdd)
        {
            if (type != GasType)
            {
                throw new ArgumentException("Incorrect gas type");
            }

            if (GasLiterAmount + gasToAdd > MaxGasLiterAmount)
            {
                throw new ValueOutOfRangeException("gas to fill out of range", 0, MaxGasLiterAmount);
            }

            GasLiterAmount += gasToAdd;
        }

        #region IGasolineObject Members and Props
        #region Members
        private GasType m_GasType;
        private float m_GasLiterAmount;
        private float m_MaxGasLiterAmount;
        #endregion Members

        #region Props
        public GasType GasType
        {
            get { return m_GasType; }
            set { m_GasType = value; }
        }

        public float GasLiterAmount
        {
            get { return m_GasLiterAmount; }
            set { m_GasLiterAmount = value; }
        }

        public float MaxGasLiterAmount
        {
            get { return m_MaxGasLiterAmount; }
            set { m_MaxGasLiterAmount = value; }
        }
        #endregion Props


        #endregion IGasolineObject Members and Props


        GasolineCar(string model, string plateNumber, Wheels[] wheels, Color color, int doors, GasType gasType, float maxGasLiterAmount)
            : base(model, plateNumber, wheels, color, doors)
        {
            GasType = gasType;
            MaxGasLiterAmount = maxGasLiterAmount;
        }
    }

    public class ElectricCar : Car, IElectricObject
    {
        public void ChargeBattery(float batteryToAdd)
        {
            if (BatteryHours + batteryToAdd > MaxBatteryHours)
            {
                throw new ValueOutOfRangeException("battery charge to fill out of range", 0, MaxBatteryHours);
            }

            BatteryHours += batteryToAdd;
        }

        #region IElectricObject Members and Props
        #region Members
        private float m_BatteryHours;
        private float m_MaxBatteryHours;
        #endregion Members

        #region Props
        public float BatteryHours
        {
            get { return m_BatteryHours; }
            set { m_BatteryHours = value; }
        }

        public float MaxBatteryHours
        {
            get { return m_MaxBatteryHours; }
            set { m_MaxBatteryHours = value; }
        }
        #endregion Props


        #endregion IElectricObject Members and Props

        ElectricCar(string model, string plateNumber, Wheels[] wheels, Color color, int doors, float maxBatteryHours)
            : base(model, plateNumber, wheels, color, doors)
        {
            MaxBatteryHours = maxBatteryHours;
        }
    }
}
