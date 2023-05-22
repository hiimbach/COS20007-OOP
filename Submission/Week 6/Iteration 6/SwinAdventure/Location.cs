using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class Location:GameObject, IHaveInventory
    {
        private Inventory _inventory;
        public Location(string name, string desc): base( new string[] {"location"}, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            else if (_inventory.HasItem(id))
            {
                return _inventory.Fetch(id);
            }
            return null;
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }
    }
}
