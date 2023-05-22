using System;
using System.Collections.Generic;



namespace Iteration3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player Bach = new Player("Bach", "The TBF");
            Item dark_sword = new Item(new string[] { "sword" }, "Dark Sword", "Destroy everything with dark magiccc!");
            Item steel_spoon = new Item(new string[] { "eatting tool" }, "Steel spoon", "Just use to eat, definitely useless in fighting :)");
            Bach.Inventory.Put(dark_sword);
            Bach.Inventory.Put(steel_spoon);
            string item_list = Bach.FullDescription;
            Console.WriteLine(item_list);

        }
    }
}
