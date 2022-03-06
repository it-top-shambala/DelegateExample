using System;
using System.Collections.Generic;

namespace DelegateExample.App
{
    public class Menu
    {
        public readonly Dictionary<int, Action> menu;
        public readonly Dictionary<int, string> menuS;

        public Menu(Action exportAction, Action importAction, Action editAction, Action showAction, Action exitAction)
        {
            menu = new Dictionary<int, Action>
            {
                { 1,  exportAction},
                { 2,  importAction},
                { 3, editAction},
                { 4, showAction},
                { 0, exitAction}
            };
            menuS = new Dictionary<int, string>
            {
                { 1,  "Экспорт"},
                { 2,  "Импорт"},
                { 3, "Редактирование"},
                { 4, "Показ"},
                { 0, "Выход"}
            };
        }
    }
}