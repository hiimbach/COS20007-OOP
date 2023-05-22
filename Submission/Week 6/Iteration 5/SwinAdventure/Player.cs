using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class Player:GameObject, IHaveInventory
    {
        private Inventory _inventory;

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
            return null;
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
    }
}
