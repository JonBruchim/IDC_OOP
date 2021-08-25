using System;
namespace Ex03
{
    public class Truck : Vehicle
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

        public Truck(Color color, int doors)
        {
            Color = color;
            Doors = doors;
        }
    }

    public enum Color
    {
        Yellow,
        White,
        Black,
        Blue,
    }


}
