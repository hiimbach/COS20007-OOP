using SwinAdventure;
using System;
using System.Collections.Generic;



namespace SwinAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ask name and description and create player
            Console.Write("The player name: ");
            string name = Console.ReadLine();
            Console.Write("Can you describe yourself: ");
            string description = Console.ReadLine();
            Player player = new Player(name, description);

            
            

            // Create a bag and add it to the inventory
            Bag magic_bag = new Bag(new string[] { "bag" }, "Magic bag", "Can bring magic items");
            player.Inventory.Put(magic_bag);

            // Create 1 more item and add it to the bag
            Item knowledge_book = new Item(new string[] { "spellbook" }, "Spellbook of Knowledge", "More power!");
            magic_bag.Inventory.Put(knowledge_book);

            // Create Location
            Location hallway = new Location("Hallway", "Beautiful land");
            Location hogwarts = new Location("Hogwarts", "Wizard School");
            Location double_tower = new Location("Double Tower", "The Eye of Sauron");
            Location godric_valley = new Location("Godric Valley", "The hometown of mighty Godric Gryffindor");
            hogwarts.AddPath(new Path(new string[] { "up", "u" }, godric_valley, "You used a Portkey and flyyy ~"));
            hallway.AddPath(new Path(new string[] { "west", "w" }, hogwarts, "You went on a train"));
            hogwarts.AddPath(new Path(new string[] { "north east", "ne" }, double_tower, "You went over the hill and far away"));
            player.Location = hallway;

            
        }
    }
}
