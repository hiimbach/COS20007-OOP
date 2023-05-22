using System;
using System.Collections.Generic;



namespace Iteration4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player Bach = new Player("Bach", "The TBF");
            Item dark_sword = new Item(new string[] { "sword" }, "Dark Sword", "Destroys everything with dark magiccc!");
            Item steel_spoon = new Item(new string[] { "eating tool" }, "Steel spoon", "Just use to eat, definitely useless in fighting :)");
            Bach.Inventory.Put(dark_sword);
            Bach.Inventory.Put(steel_spoon);

            Bag simple_bag = new Bag(new string[] { "bag" }, "level 1 bag", "Just a simple bag");
            Item legend_knife = new Item(new string[] { "knife" }, "Legend knife", "Brings the power of Godsss");
            simple_bag.Inventory.Put(legend_knife);
            Bach.Inventory.Put(simple_bag);
            
            LookCommand command1 = new LookCommand();
            Console.WriteLine(command1.Execute(Bach, new string[] { "look", "at", "inventory" }));
        }
    }
}
