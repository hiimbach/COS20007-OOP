using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class Player:GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;

        public Player(string name, string desc): base(new string[] {"me", "inventory"}, name, desc)
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
            else if (_location.FirstID == id)
            {
                return _location;
            }
            else
            {
                return null;
            }
            
        }

        public void ChangeLocationTo(Location location)
        {
            _location = location;
        }

        public override string FullDescription
        {
            get
            {
                return $"Hello mighty {Name}. \nYou are carrying: \n{Inventory.ItemList}";
            }
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public Location Location { get { return _location; } }
    }
}
