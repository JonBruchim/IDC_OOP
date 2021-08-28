using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class InnerNodeItem : MenuItem
    {
        private Dictionary<int, MenuItem> m_Submenus;

        public InnerNodeItem(string i_Title, MenuItem i_Parent)
            : base(i_Title, i_Parent)
        {
            m_Submenus = new Dictionary<int, MenuItem>();
        }

        public Dictionary<int, MenuItem> Submenus
        {
            get { return m_Submenus; }
        }

        public void Add(MenuItem i_NewChild)
        {
            m_Submenus[m_Submenus.Count + 1] = i_NewChild;
        }

        public override string ToString()
        {
            StringBuilder menuLines = new StringBuilder();

            foreach (KeyValuePair<int, MenuItem> menuLine in m_Submenus)
            {
                menuLines.Append(menuLine.Key.ToString() + ". " + menuLine.Value.Title + Environment.NewLine);
            }

            return menuLines.ToString();
        }
    }
}
