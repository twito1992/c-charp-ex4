﻿namespace EX04.Menus.Delegates.MenuItems
{
    public delegate void ItemWasChosenDelegate(MenuItem i_MenuItem);

    public abstract class MenuItem
    {
        protected string m_Title;
        protected MenuItem m_BackItem;

        public event ItemWasChosenDelegate ItemWasChosen; //event when this MenuItem is chosen

        public MenuItem BackItem
        {
            get
            {
                return m_BackItem;
            }
            set
            {
                m_BackItem = value;
            }
        }

        public string Title
        {
            get
            {
                return m_Title;
            }
            set
            {
                m_Title = value;
            }
        }

        public MenuItem(string i_Title)
        {
            m_Title = i_Title;
        }

        public void OnItemWasChosen()
        { 
            if (ItemWasChosen != null)
            {
                ItemWasChosen(this);
            }
        }

        public abstract void HandleMenuItem();
    }
}
