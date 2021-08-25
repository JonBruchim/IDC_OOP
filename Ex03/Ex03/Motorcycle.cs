using System;
namespace Ex03
{
    public abstract class Motorcycle : Vehicle
    {
        #region Members and Props
        #region Members
        private LicenceType m_LicenceType;
        private int m_EngineVolume;
        #endregion Members

        #region Props
        public LicenceType LicenceType
        {
            get { return m_LicenceType; }
            set { m_LicenceType = value; }
        }

        public int EngineVolume
        {
            get { return m_EngineVolume; }
            set { m_EngineVolume = value; }
        }
        #endregion Props
        #endregion Members and Props

        public Motorcycle(string model, string plateNumber, Wheels[] wheels, LicenceType licenceType, int engineVolume)
            : base(model, plateNumber, wheels)
        {
            LicenceType = licenceType;
            EngineVolume = engineVolume;
        }

        // Overriding Object.ToString
        public override string ToString()
        {
            return base.ToString() + string.Format("LicenceType: {0}\n" +
                "EngineVolume: {1}",
                LicenceType, EngineVolume);
        }

    }

    public enum LicenceType
    {
        A,
        A1,
        A2,
        B,
    }

    public class GasolineMotorcycle : Motorcycle, IGasolineObject
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


        public GasolineMotorcycle(string model, string plateNumber, Wheels[] wheels, LicenceType licenceType, int engineVolume, GasType gasType, float maxGasLiterAmount)
            : base(model, plateNumber, wheels, licenceType, engineVolume)
        {
            GasType = gasType;
            MaxGasLiterAmount = maxGasLiterAmount;
        }
    }

    public class ElectricMotorcycle : Motorcycle, IElectricObject
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

        public ElectricMotorcycle(string model, string plateNumber, Wheels[] wheels, LicenceType licenceType, int engineVolume, float maxBatteryHours)
            : base(model, plateNumber, wheels, licenceType, engineVolume)
        {
            MaxBatteryHours = maxBatteryHours;
        }
    }
}
