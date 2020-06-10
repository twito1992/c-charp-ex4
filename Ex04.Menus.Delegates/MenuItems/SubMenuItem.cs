﻿using System;
using System.Collections.Generic;

namespace EX04.Menus.Delegates.MenuItems
{
    public class SubMenuItem : MenuItem
    {
        private List<MenuItem> m_MenuItems;
        protected string m_BackItemUniqueTitle = "Back";
       
        public SubMenuItem(string i_Title) : base(i_Title) 
        {
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            if(m_MenuItems == null)
            {
                m_MenuItems = new List<MenuItem>();
            }

            m_MenuItems.Add(i_MenuItem);
            i_MenuItem.BackItem = this;
            i_MenuItem.ItemWasChosen += new ItemWasChosenDelegate(MenuItem_ItemWasChosen);
        }

        public void MenuItem_ItemWasChosen(MenuItem menuItem) //execute a sub Menu in the list
        {
            menuItem.HandleMenuItem();
        }

        private void setBackItem(SubMenuItem i_subMenuItem)
        {
            m_BackItem = i_subMenuItem;
        }

        private MenuItem getUserChoice()
        {
            bool isChoiceValid = false;
            int choiceIndex;
            MenuItem chosenItem;
        
            do
            {
                Console.WriteLine("Please enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out choiceIndex))
                {
                    if (choiceIndex >= 0 && choiceIndex <= m_MenuItems.Count)
                    {
                        isChoiceValid = true;
                    }
                }

                if (!isChoiceValid)
                {
                    Console.WriteLine("Invalid choice. Try again!");
                }
            }
            while (!isChoiceValid);

            chosenItem = getMenuItemByIndex(choiceIndex);
            return chosenItem;
        }

        private MenuItem getMenuItemByIndex(int i_ChoiceIndex)
        {
            MenuItem chosenItem;

            if (i_ChoiceIndex == 0)
            { 
                chosenItem = m_BackItem;
            }
            else
            {
                chosenItem = m_MenuItems[i_ChoiceIndex - 1];
            }

            return chosenItem;
        }

        public override void HandleMenuItem()
        {
            MenuItem userChoice;

            showSubMenu();
            userChoice = getUserChoice();

            Console.Clear();

            //user chose exit
            if (userChoice == null)  
            {
                Console.WriteLine("...........Bye Bye...........");
                Console.WriteLine("By Mor Twito && Ortal Chifrut");
            }
            else
            {
                if(userChoice.BackItem == null)
                {
                    userChoice.HandleMenuItem();
                }
                else
                {
                    userChoice.OnItemWasChosen();
                }
            }
        }

        private void showSubMenu()
        {
            int choiceIndex = 1;

            Console.WriteLine(string.Format("===== {0} =====", m_Title));
            foreach (MenuItem menuItem in m_MenuItems)
            {
                Console.WriteLine("{0}. {1}", choiceIndex, menuItem.Title);
                choiceIndex++;
            }

            Console.WriteLine("{0}. {1}", 0, m_BackItemUniqueTitle);
        }
    }
}
