using System;
namespace Ex04.Menus.Interfaces
{
    public class LeafNodeItem : MenuItem
    {
        private readonly IMenuItemClickListener r_ClickListener;

        public LeafNodeItem(string i_Title, MenuItem i_Parent, IMenuItemClickListener i_ClickListener)
            : base(i_Title, i_Parent)
        {
            r_ClickListener = i_ClickListener;
        }

        public IMenuItemClickListener Listener
        {
            get { return r_ClickListener; }
        }
    }
}
