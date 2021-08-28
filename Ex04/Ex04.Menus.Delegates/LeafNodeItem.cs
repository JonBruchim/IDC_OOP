using System;
namespace Ex04.Menus.Delegates
{
    public class LeafNodeItem : MenuItem
    {
        public event Action OnMenuItemClick;

        public LeafNodeItem(string i_Title, MenuItem i_Parent, Action i_ActionToInvoke)
            : base(i_Title, i_Parent)
        {
            OnMenuItemClick += i_ActionToInvoke;
        }

        public void MenuItemClicked()
        {
            if (OnMenuItemClick != null)
            {
                OnMenuItemClick.Invoke();
            }
        }
    }
}
