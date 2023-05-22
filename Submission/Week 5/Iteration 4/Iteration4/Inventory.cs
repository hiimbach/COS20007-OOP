using System;
using System.Collections.Generic;
using System.Text;

namespace Iteration4
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item> ();
        }

        public bool HasItem(string id)
        {
            foreach (Item itm in _items)
            {
                if (itm.FirstID == id)
                {
                    return true;
                }
            }
            return false;
        }

        public void Put (Item itm)
        {
            _items.Add(itm);
        }

        public Item Take(string id)
        {
            foreach (Item itm in _items)
            {
                if (id == itm.FirstID)
                {
                    _items.Remove(itm);
                    return itm;
                }
            }
            return null;
        }

        public Item Fetch (string id)
        {
            foreach (Item itm in _items)
            {
                if (id == itm.FirstID)
                {
                    return itm;
                }
            }
            return null;
        }

        public string ItemList
        {
            get
            {
                string description = ""; 
                foreach (Item item in _items)
                {
                    description += $"- {item.ShortDescription}\n";
                }
                return description;
            }
        }
    }
}
