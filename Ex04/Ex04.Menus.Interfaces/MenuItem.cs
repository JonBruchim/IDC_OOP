using System;
namespace Ex04.Menus.Interfaces
{
    public abstract class MenuItem
    {
        private readonly int r_Level;
        private readonly string r_Title;
        private readonly MenuItem r_Parent;

        public MenuItem(string i_Title, MenuItem i_Parent)
        {
            r_Title = i_Title;
            r_Parent = i_Parent;

            if (i_Parent != null)
            {
                r_Level = i_Parent.Level + 1;
            }
            else
            {
                r_Level = 0;
            }
        }

        public string Title
        {
            get { return r_Title; }
        }

        public int Level
        {
            get { return r_Level; }
        }

        public MenuItem Parent
        {
            get { return r_Parent; }
        }
    }
}
