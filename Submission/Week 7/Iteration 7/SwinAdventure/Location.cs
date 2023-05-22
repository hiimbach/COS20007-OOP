using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class Location:GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private List<Path> _all_path;
        public Location(string name, string desc): base( new string[] {"location"}, name, desc)
        {
            _inventory = new Inventory();
            _all_path = new List<Path>();
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
        public void AddPath(Path path)
        {
            _all_path.Add(path);
        }

        public Inventory Inventory
        {
         
            get { return _inventory; }
        }
        public string Description
        {
            get
            {
                string s = $"You are in {Name}\n{FullDescription}\n";
                if (_all_path.Count == 0)
                {
                    s += "There is no exit from here";
                }
                else
                {
                    s += $"There are exits to {_all_path[0].FirstID}";
                    if (AllPath.Count > 1)
                    {
                        foreach (Path path in _all_path.GetRange(1, _all_path.Count - 1))
                        {
                            s += $", {path.FirstID}";
                        }
                    }
                    
                }
                if (_inventory.ItemList != "")
                {
                    s += $"\nHere you can see:\n";
                    s += _inventory.ItemList;
                }
                return s + ".";
            }
        }
        public List<Path> AllPath { get { return _all_path; } }
    }

    public class Path : GameObject
    {
        Location _destination;

        public Path(string[] direction, Location location, string description) : base(direction, location.Name, description)
        {
            _destination = location;
        }
        public void MovePlayer(Player p)
        {
            p.Location = _destination;
        }
        public string Description
        {
            get { return FullDescription; }
        }
        public Location Destination
        {
            get { return _destination; } 
        }

        

        


    }
}
