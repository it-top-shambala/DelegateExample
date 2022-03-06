using System;
using System.Collections.Generic;

namespace DelegateExample.App
{
    public enum MenuItem
    {
        Export = 1, Import = 2, Edit = 3, Show = 4, Exit = 0
    }
    public class Menu
    {
        public readonly Dictionary<MenuItem, Action> menu;

        public Menu(Action exportAction, Action importAction, Action editAction, Action showAction, Action exitAction)
        {
            menu = new Dictionary<MenuItem, Action>
            {
                { MenuItem.Export,  exportAction},
                { MenuItem.Import,  importAction},
                { MenuItem.Edit , editAction},
                { MenuItem.Show, showAction},
                { MenuItem.Exit, exitAction}
            };
        }
    }
}