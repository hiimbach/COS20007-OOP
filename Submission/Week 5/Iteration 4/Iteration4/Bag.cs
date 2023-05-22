using System;

namespace Iteration4
{
	public class Bag:Item, IHaveInventory
	{
		private Inventory _inventory;
		public Bag(string[] ids, string name, string desc): base(ids, name, desc)
		{
			_inventory = new Inventory();
		}

		public GameObject Locate(string id)
        {
			if (AreYou(id))
            {
				return this;
            }
			return _inventory.Fetch(id);
        }

		public Inventory Inventory
        {
			get { return _inventory; }
        }

		public override string FullDescription
		{
			get
			{
				return $"In the {Name} you can see: \n{Inventory.ItemList}";
			}
		}
	}
}

