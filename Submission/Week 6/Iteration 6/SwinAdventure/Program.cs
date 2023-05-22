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

            // Create 2 items and add them to the inventory
            Item secret_book = new Item(new string[] { "spellbook" }, "Spellbook of Secret", "Can find other spellbooks");
            Item phoenix_wand = new Item(new string[] { "wand" }, "A might wand which is made by the feather of a phoenix", "Spells! More spells!");
            player.Inventory.Put(secret_book);
            player.Inventory.Put(phoenix_wand);

            // Create a bag and add it to the inventory
            Bag magic_bag = new Bag(new string[] { "bag" }, "Magic bag", "Can bring magic items");
            player.Inventory.Put(magic_bag);    

            // Create 1 more item and add it to the bag
            Item knowledge_book = new Item(new string[] { "spellbook" }, "Spellbook of Knowledge", "More power!");
            magic_bag.Inventory.Put(knowledge_book);

            LookCommand command = new LookCommand();
            

            //Location
            Location hogwarts = new Location("Hogwarts", "Wizard School");
            player.ChangeLocationTo(hogwarts);
            Item judgement_book = new Item(new string[] { "spellbook" }, "Spellbook of Judment", "More books! Moreee!");
            Item dark_orb = new Item(new string[] { "orb" }, "The orb of dark magic", "Shadow is commingg!");
            hogwarts.Inventory.Put(judgement_book);
            hogwarts.Inventory.Put(dark_orb);

            Console.WriteLine(player.Locate("location").FullDescription);
            while (true)
            {
                Console.Write("Look Commmand: ");
                string user_input = Console.ReadLine();
                string[] command_words = user_input.Split(' ');
                Console.WriteLine(command.Execute(player, command_words));
            }
        }
    }
}
