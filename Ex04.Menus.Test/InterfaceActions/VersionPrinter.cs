﻿using System;
using EX04.Menus.Interfaces.MenuItems;

namespace EX04.Menus.Test.InterfaceActions
{
    public class VersionPrinter : IActionObserver
    {
        public void DoAction()
        {
            Console.WriteLine("Version: 20.2.4.30620");
        }
    }
}
