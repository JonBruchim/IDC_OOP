using System;
namespace Ex03
{
    public class Truck : Vehicle
    {
        #region Members and Props
        #region Members
        private bool m_takingDangerousMaterial;
        private float m_TrunkVolume;
        #endregion Members

        #region Props
        public bool TakingDangerousMaterial
        {
            get { return m_takingDangerousMaterial; }
            set { m_takingDangerousMaterial = value; }
        }

        public float TrunkVolume
        {
            get { return m_TrunkVolume; }
            set { m_TrunkVolume = value; }
        }
        #endregion Props
        #endregion Members and Props

        public Truck(string model, string plateNumber, Wheels[] wheels, bool takingDangerousMaterial, float trunkVolume)
            : base(model, plateNumber, wheels)
        {
            TrunkVolume = trunkVolume;
            TakingDangerousMaterial = takingDangerousMaterial;
        }
    }
}
