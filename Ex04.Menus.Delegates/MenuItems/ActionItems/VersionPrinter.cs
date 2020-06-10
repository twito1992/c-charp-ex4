﻿using System;

namespace EX04.Menus.Delegates.MenuItems
{
    public class VersionPrinter : ActionItem
    {
        public VersionPrinter(string i_Title) : base(i_Title)
        {
        }

        public override void DoAction()
        {
            Console.WriteLine("Version: 20.2.4.30620");
        }
    }
}
