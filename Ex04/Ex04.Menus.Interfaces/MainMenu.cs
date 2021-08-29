using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private const int k_OptionPreviousMenu = 0;
        private const string k_OptionLabelExit = "Exit";
        private const string k_OptionLabelBack = "Back";

        private readonly int r_rootHash;
        private MenuItem m_CurrentItem;
        private bool m_ExitProgram = false;
        private Dictionary<int, MenuItem> m_MenuItems;

        public MainMenu(string i_Header)
        {
            m_MenuItems = new Dictionary<int, MenuItem>();
            m_CurrentItem = new InnerNodeItem(i_Header, null);
            r_rootHash = m_CurrentItem.GetHashCode();
            m_MenuItems[r_rootHash] = m_CurrentItem;
        }

        public int RootHashCode
        {
            get { return r_rootHash; }
        }

        // the following 2 methods return a unique key for the added item.
        // that key is for the user to know that the current item was chosen at a given time.
        public int AddNewMenuItemUnder(int i_ParentHashCode, string i_TitleOfNewNode)
        {
            return addItem(i_ParentHashCode, i_TitleOfNewNode);
        }

        public int AddNewOperationItemUnder(int i_ParentHashCode, string i_TitleOfNewNode, IMenuItemClickListener i_ClickListener)
        {
            return addItem(i_ParentHashCode, i_TitleOfNewNode, i_ClickListener);
        }

        private int addItem(int i_ParentHashCode, string i_TitleOfNewNode, IMenuItemClickListener i_ClickListener = null)
        {
            int newNodeHash = -1;

            if (m_MenuItems.ContainsKey(i_ParentHashCode))
            {
                try
                {
                    MenuItem newNode = null;
                    if (i_ClickListener == null)
                    {
                        newNode = new InnerNodeItem(i_TitleOfNewNode, m_MenuItems[i_ParentHashCode]);
                    }
                    else
                    {
                        newNode = new LeafNodeItem(i_TitleOfNewNode, m_MenuItems[i_ParentHashCode], i_ClickListener);
                    }

                    (m_MenuItems[i_ParentHashCode] as InnerNodeItem).Add(newNode);
                    newNodeHash = newNode.GetHashCode();
                    m_MenuItems[newNodeHash] = newNode;
                }
                catch
                {
                    throw new ArgumentException(string.Format("Error:Could not add new menu under {0} ", i_ParentHashCode));
                }
            }
            else
            {
                throw new ArgumentException(string.Format("Error:Could not found {0} ", i_ParentHashCode));
            }

            return newNodeHash;
        }

        public void Show()
        {
            while (!m_ExitProgram)
            {
                printCurrentMenu();
                int choice = getKeyInRangeFromUser((m_CurrentItem as InnerNodeItem).Submenus.Count);
                handleChoice(choice);
            }
        }

        private void printCurrentMenu()
        {
            Console.Clear();
            string currentMenu = String.Format("{0} {1}\n\n" +
                                               "{2}. {3}\n" +
                                               "{4}",
                                               m_CurrentItem.Level,
                                               m_CurrentItem.Title,
                                               k_OptionPreviousMenu,
                                               m_CurrentItem.Level == 0 ? k_OptionLabelExit : k_OptionLabelBack,
                                               m_CurrentItem.ToString());
            Console.WriteLine(currentMenu);
        }

        private int getKeyInRangeFromUser(int i_Range)
        {
            int choosenNumber;
            Console.WriteLine("Please select an option:");
            string choice = Console.ReadLine();

            while (!int.TryParse(choice, out choosenNumber) || !isInRange(choosenNumber, i_Range))
            {
                Console.WriteLine("please enter a number in range {0} to {1}:", 0, i_Range);
                choice = Console.ReadLine();
            }

            return choosenNumber;
        }

        private bool isInRange(int i_Choice, int i_Max)
        {
            return i_Choice >= k_OptionPreviousMenu && i_Choice <= i_Max;
        }

        private void handleChoice(int i_Choice)
        {
            Console.Clear();
            InnerNodeItem currInnerItem = m_CurrentItem as InnerNodeItem;
            if (i_Choice == k_OptionPreviousMenu)
            {
                if (m_CurrentItem.Level == 0)
                {
                    m_ExitProgram = true;
                }
                else
                {
                    m_CurrentItem = m_CurrentItem.Parent;
                }
            }
            else
            {
                if (currInnerItem.Submenus[i_Choice] is InnerNodeItem)
                {
                    m_CurrentItem = currInnerItem.Submenus[i_Choice];
                }
                else
                {
                    (currInnerItem.Submenus[i_Choice] as LeafNodeItem).Listener.OnMenuItemClick();
                }
            }
        }
    }
}
