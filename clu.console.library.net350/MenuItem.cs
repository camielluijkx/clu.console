﻿namespace clu.console.library.net350
{
    public delegate void MenuItemEvent();

    public class MenuItem
    {
        public int Index { get; set; }

        public string Text { get; set; }

        public MenuItemEvent Event { get; set; }

        public MenuItem(int itemIndex, string itemText, MenuItemEvent itemEvent)
        {
            Index = itemIndex;
            Text = itemText;
            Event = itemEvent;
        }
    }
}
