using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Garden_Game.Container;

namespace Garden_Game
{
    public class System
    {
        Garden Garden;
        Bag Bag;
        BuyingState BuyingState;
        Dictionary<string, Seed> seed_dict = new Dictionary<string, Seed>();
        Dictionary<string, FlowerPot> pot_dict = new Dictionary<string, FlowerPot>();

        public System()
        {
            Garden = Garden.GoToGarden();
            Bag = Bag.GoToBag();
            BuyingState = BuyingState.GoToBuyingState();

            foreach (Seed seed in BuyingState.SeedCollection)
            {
                seed_dict.Add(seed.Name, seed);
            }

            foreach (FlowerPot pot in BuyingState.PotCollection)
            {
                pot_dict.Add(pot.Name, pot);
            }
        }
        // Support Process
        internal int GetIntBetween(int start, int end)
        {
            while (true)
            {
                int choice;
                string input;
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    input = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    try
                    {
                        choice = int.Parse(input);
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Please give a number");
                    }
                }

                if (choice < start || choice > end)
                {
                    Console.WriteLine($"Please give an integer number between {start} and {end}");
                }
                else
                {
                    return choice;
                }
            }

        }
        internal double GetDoubleBetween(double start, double end)
        {
            while (true)
            {
                double choice;
                string input;
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    input = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    try
                    {
                        choice = double.Parse(input);
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Please give a number");
                    }
                }

                if (choice < start || choice > end)
                {
                    Console.WriteLine($"Please give a float number between {start} and {end}");
                }
                else
                {
                    return choice;
                }
            }
        }
        internal int AskIntAmount(string thing)
        {
            Console.WriteLine($"How many {thing}s do you want to buy ");
            int amount = GetIntBetween(1, 9999);

            return amount;
        }
        internal double AskDoubleAmount(string thing)
        {
            Console.WriteLine($"How much {thing}s do you want to buy ");
            double amount = GetDoubleBetween(1, 9999);

            return amount;
        }
        internal void PressEnter()
        {
            Console.WriteLine("Press Enter for continue...");
            Console.ReadKey();
            Console.Clear();
        }
        internal bool Checkmoney(double required, string thing)
        {
            if (required > Bag.Money)
            {
                Console.WriteLine("Not enough money.");
                return false;
            }
            else
            {
                Bag.Money -= required;
                Console.WriteLine($"Buy {thing} successfully! Thank you!");
                return true;
            }
        }

        // Restore data
        internal void RestoreData()
        {
            // --- Structure ---
            // money
            // water
            // fertilizer   

            //number of seeds
            // --- For every seed in bag
            // seed name
            // amount

            // number of plantholders
            // --- For every plantholder ---
            // plantholder name
            // T/F -> seeded or not, if not pass all of infor below
            // seed name
            // days remaining
            // days without water
            // water today

            StreamReader data = new StreamReader("Data.txt");

            // Basic resources in bag
            string first_line = data.ReadLine();
            if (first_line == null)
            {
                data.Close();
                return;
            }
            Bag.Money = Double.Parse(first_line);
            Bag.Water = Double.Parse(data.ReadLine());
            Bag.Fertilizer = Double.Parse(data.ReadLine());

            // Load all seed
            int number_of_seed = Int32.Parse(data.ReadLine());
            for (int i = 0; i < number_of_seed; i++)
            {
                Seed seed = LoadSeed(data.ReadLine());
                int amount = Int32.Parse(data.ReadLine());
                Bag.AddSeed(seed, amount);
            }

            // Load all Plant holder
            int number_of_PH = Int32.Parse(data.ReadLine());
            for (int i = 0; i < number_of_PH; i++)
            {
                PlantHolder added_ph;
                // Plant Holder name
                string ph_name = data.ReadLine();
                if (ph_name == "Plot")
                {
                    added_ph = new Plot("Plot", 5);
                }
                else
                {
                    FlowerPot chosen = pot_dict[ph_name];
                    added_ph = new FlowerPot(chosen.Name, chosen.HolderPrice);
                }
                

                // Seeded or not
                if (data.ReadLine() == "T")
                {
                    Seed added_seed = LoadSeed(data.ReadLine());
                    int days_remain = Int32.Parse(data.ReadLine());
                    int days_without_water = Int32.Parse(data.ReadLine());
                    double water_today = Double.Parse(data.ReadLine());
                    added_ph.PHRecover(added_seed, days_remain, days_without_water, water_today);
                }
                Garden.AddPlantHolder(added_ph);
            };
            data.Close();

        }
        internal Seed LoadSeed(string seed_name)
        {
            return seed_dict[seed_name];    
        }

        // Save data
        internal void SaveData()
        {
            StreamWriter pen = new StreamWriter("Data.txt");
            pen.WriteLine(Bag.Money);
            pen.WriteLine(Bag.Water);
            pen.WriteLine(Bag.Fertilizer);
            pen.WriteLine(Bag.NumberOfSeed);

            foreach (KeyValuePair<Seed, int> kvp in Bag.All_Seed)
            {
                pen.WriteLine(kvp.Key.Name);
                pen.WriteLine(kvp.Value);
            }

            int number_of_ph = Garden.HolderList.Count;
            pen.WriteLine(number_of_ph);

            foreach (PlantHolder plantholder in Garden.HolderList)
            {
                pen.WriteLine(plantholder.Name);
                if (plantholder.Seeded)
                {
                    pen.WriteLine("T");
                    pen.WriteLine(plantholder.Seed.Name);
                    pen.WriteLine(plantholder.DaysRemaining);
                    pen.WriteLine(plantholder.DaysWithoutWater);
                    pen.WriteLine(plantholder.WaterToday);
                }
                else
                {
                    pen.WriteLine("F");
                }
            }
            pen.Close();

        }

        // Dashboard
        internal void Dashboard()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("-- Dashboard --");
                Console.WriteLine("Here you can choose:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Bag");
                Console.WriteLine("2. Garden");
                Console.WriteLine("3. Market");
                Console.WriteLine("4. Next day");
                Console.WriteLine("5. Exit");

                int choice = GetIntBetween(1, 5);
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        BagBoard();
                        break;
                    case 2:
                        GardenBoard();
                        break;
                    case 3:
                        MarketBoard();
                        break;
                    case 4:
                        Garden.OneDayPass();
                        Dashboard();
                        break;
                    case 5:
                        SaveData();
                        Environment.Exit(0);
                        break;
                }
            }
        }

        // User Interface of Bag
        internal void BagBoard()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-- Bag --");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Money: {Bag.Money}");
            Console.WriteLine($"Water: {Bag.Water} milliliters");
            Console.WriteLine($"Fertilizer: {Bag.Fertilizer} kg\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Flower Seeds: ");
            Console.ForegroundColor = ConsoleColor.White;
            Bag.AllSeedsTypeOf(Type.Flower);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Fruit Seeds: ");
            Console.ForegroundColor = ConsoleColor.White; 
            Bag.AllSeedsTypeOf(Type.Fruit);
            PressEnter();

        }

        // User Interface of Garden
        internal void GardenBoard()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("-- Garden --");
                Console.WriteLine("Here you can see:");
                Console.ForegroundColor = ConsoleColor.White;
                if (Garden.HolderList.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("As you can see, there is not any plant holder here.");
                    Console.WriteLine("Please buy more plant holder");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("1. Buy plant holder");
                    Console.WriteLine("2. Exit");
                    int choice = GetIntBetween(1, 2);
                    Console.Clear();
                    if (choice == 1)
                    {
                        BuyingPlantHolder();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Please choose a plant holder to see more details");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(Garden.Description);
                    Console.WriteLine($"{Garden.HolderList.Count + 1}. Exit");
                    int choice = GetIntBetween(1, Garden.HolderList.Count + 1);
                    if (choice == Garden.HolderList.Count + 1)
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        PlantHolder visit_plant_holder = Garden.HolderList[choice - 1];
                        Console.WriteLine(visit_plant_holder.LongDescription);
                        if (visit_plant_holder.Fully_Growth)
                        {
                            Console.WriteLine("1. Sell it");
                            Console.WriteLine("2. Exit");

                            choice = GetIntBetween(1, 2);
                            if (choice == 1)
                            {
                                Garden.Sell(visit_plant_holder);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine($"Sell the {visit_plant_holder.Seed.Name} successfully!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            PressEnter();
                        }
                        else
                        {
                            visit_plant_holder = Garden.HolderList[choice - 1];
                            VisitPlantHolder(visit_plant_holder);
                        }

                    }

                }
            }

        }
        internal void VisitPlantHolder(PlantHolder visit_plant_holder)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Please choose:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Add resource");
            Console.WriteLine("2. Exit");

            int choice = GetIntBetween(1, 2);
            if (choice == 1)
            {
                Console.WriteLine("1. Seed   2. Water   3. Fertilizer   4. Back");
                choice = GetIntBetween(1, 4);
                switch (choice)
                {
                    case 1:
                        if (visit_plant_holder.Seeded)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("This plant holder has been seeded, it is growingg");
                            Console.ForegroundColor = ConsoleColor.White;
                            PressEnter();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Choose seed:");
                            Console.ForegroundColor = ConsoleColor.White;
                            bool have_seed;
                            if (visit_plant_holder.HolderType == HolderType.Plot)
                            {
                                have_seed = Bag.AllSeedsTypeOf(Type.Fruit);
                            }
                            else
                            {
                                have_seed = Bag.AllSeedsTypeOf(Type.Flower);
                            }

                            if (have_seed)
                            {
                                int seed_index = GetIntBetween(1, Bag.NumberOfSeed);
                                Bag.UseSeed(seed_index, visit_plant_holder);
                            }
                            else
                            {
                                PressEnter();
                            }

                        }
                        break;

                    case 2:
                        if (Bag.Water == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("You have no water");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("1. Go to market");
                            Console.WriteLine("2. Exit");
                            choice = GetIntBetween(1, 2);
                            if (choice == 1)
                            {
                                MarketBoard();
                            }
                        }
                        else
                        {
                            if (visit_plant_holder.Seeded)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine($"You are having {Bag.Water} milliliters");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("You want to use: ");
                                double amount = GetDoubleBetween(0, Bag.Water);
                                Bag.UseWater(amount);
                                visit_plant_holder.WaterToday += amount;
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Use water successfully");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.WriteLine("Please plant something here first.");
                                PressEnter();
                            }

                        }
                        break;


                    case 3:
                        if (Bag.Fertilizer == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("You have no fertilizer");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("1. Go to market");
                            Console.WriteLine("2. Exit");
                            choice = GetIntBetween(1, 2);
                            if (choice == 1)
                            {
                                MarketBoard();
                            }
                        }
                        else
                        {
                            if (visit_plant_holder.Seeded)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine($"You are having {Bag.Fertilizer} kg");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("You want to use: ");
                                double amount = GetDoubleBetween(0, Bag.Fertilizer);
                                Bag.UseFertilizer(amount);
                                int days_reduced = (int)Math.Floor(amount);
                                if (days_reduced >= visit_plant_holder.DaysRemaining)
                                {
                                    visit_plant_holder.DaysRemaining = 0;
                                }
                                else
                                {
                                    visit_plant_holder.DaysRemaining -= days_reduced;
                                }
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Use fertilizer successfully");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("You need to plant something first.");
                                Console.ForegroundColor = ConsoleColor.White;
                                PressEnter();
                            }

                        }

                        break;
                    case 4:
                        Console.Clear();
                        break;
                }

            }
            Console.Clear();

        }

        // User Interface of Market, accessing the Buying and Selling state
        internal void MarketBoard()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("-- Market --");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please choose:");
                Console.WriteLine("1. Look at your bag");
                Console.WriteLine("2. Buying State");
                Console.WriteLine("3. Selling State");
                Console.WriteLine("4. Exit");

                int choice = GetIntBetween(1, 4);
                Console.Clear();
                if (choice == 1)
                {
                    BagBoard();
                }
                else if (choice == 2)
                {
                    VisitBuyingState();
                }
                else if (choice == 3)
                {
                    VisitSellingState();
                }
                else
                {
                    return;
                }
            }

        }

        // Buying State
        internal void VisitBuyingState()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-- Buying State --");
            Console.WriteLine("This is the place where you can buy EVERYTHING! (except a girl friend, unfortunately 😥)");
            Console.WriteLine($"You have {Bag.Money}$, you want to buy:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Plant holders");
            Console.WriteLine("2. Resources");
            Console.WriteLine("3. Exit");

            int choice = GetIntBetween(1, 3);
            if (choice == 1)
            {
                BuyingPlantHolder();
            }
            else if (choice == 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Which kind of resource do you want to buy?");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Seeds");
                Console.WriteLine("2. Water");
                Console.WriteLine("3. Fertilizer");
                Console.WriteLine("4. Exit");

                int option = GetIntBetween(1, 4);
                switch (option)
                {
                    case 1:
                        BuyingSeed();
                        break;
                    case 2:
                        BuyingWater();
                        break;
                    case 3:
                        BuyingFertilizer();
                        break;
                    case 4:
                        Console.Clear();
                        break;
                }
            }
            else
            {
                Console.Clear();
            }

        }
        // Buying Plant Holder
        internal void BuyingPlantHolder()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-- Buying Plant Holder State --");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Buy Plots");
            Console.WriteLine("2. Buy Flower Pots");
            Console.WriteLine("3. Exit");

            int choice = GetIntBetween(1, 3);
            if (choice == 1)
            {
                Console.WriteLine("The price of a plot is 5$");
                int amount = AskIntAmount("plot");
                if (Checkmoney(amount * 5, "plots"))
                {
                    for (int i = 0; i < amount; i++)
                    {
                        Garden.AddPlantHolder(new Plot("Plot", 5));
                    }
                }
                PressEnter();
            }
            else if (choice == 2)
            {
                Console.WriteLine(BuyingState.FlowerPotShopDescription);
                int exit_choice = BuyingState.PotCollection.Count + 1;
                Console.WriteLine($"{exit_choice}. Exit");

                int option = GetIntBetween(1, exit_choice);
                if (option == exit_choice)
                {
                    Console.Clear();
                    return;
                }
                else
                {
                    FlowerPot chosen_pot = BuyingState.PotCollection[choice - 1];
                    Console.WriteLine("How many pots do you want to buy?");
                    int amount = GetIntBetween(1, 9999);
                    if (Checkmoney(amount * chosen_pot.HolderPrice, "pots"))
                    {
                        for (int i = 1; i <= amount; i++)
                        {
                            Garden.AddPlantHolder(new FlowerPot(chosen_pot.Name, chosen_pot.HolderPrice));
                        }
                        PressEnter();
                    }
                }
            }
            else
            {
                Console.Clear();
            }
        }
        // Buying Resources
        internal void BuyingSeed()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Which kind of seed do you want to buy?");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(BuyingState.SeedShopDescription);
            int exit_index = BuyingState.SeedCollection.Count + 1;
            Console.WriteLine($"{exit_index}. Exit");
            int choice = GetIntBetween(1, exit_index);
            if (choice == exit_index)
            {
                Console.Clear();
                return;
            }
            else
            {
                Seed chosen_seed = BuyingState.SeedCollection[choice - 1];
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(chosen_seed.Description);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Buy");
                Console.WriteLine("2. Exit");

                int buy_or_not = GetIntBetween(1, 2);
                if (buy_or_not == 1)
                {
                    int amount = AskIntAmount(chosen_seed.Name + "seeds");
                    if (Checkmoney(chosen_seed.BuyPrice * amount, chosen_seed.Name + "seeds"))
                    {
                        Bag.AddSeed(chosen_seed, amount); 
                    }
                    PressEnter();
                }
                else
                {
                    Console.Clear();
                }


            }
        }
        internal void BuyingWater()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("The price of 1 liter water is 1$");
            Console.ForegroundColor = ConsoleColor.White;
            double amount = AskDoubleAmount("water (ml)");
            if (Checkmoney(amount / 1000, "water"))
            {
                Bag.Water += amount;
            }
            PressEnter();
        }
        internal void BuyingFertilizer()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("The price of 1 kg fertilizer is 0.5$");
            Console.ForegroundColor = ConsoleColor.White;
            double amount = AskDoubleAmount("fertilizer (kg)");
            if (Checkmoney(amount * 0.5, "fertilizer"))
            {
                Bag.Fertilizer += amount;
            }
            PressEnter();
        }

        // Selling State
        internal void VisitSellingState()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-- Selling State --");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (Garden.HolderList.Count == 0)
            {
                Console.WriteLine("You have no plant holder to sell");
                PressEnter();
            }
            else
            {
                Console.WriteLine("1. Choose a plant holder to sell");
                Console.WriteLine("2. Exit");

                int choice = GetIntBetween(1, 2);
                if (choice == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("You will gain the money equal half of the holder's price");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(Garden.Description);
                    int exit_choice = Garden.HolderList.Count + 1;
                    Console.WriteLine($"{exit_choice}. Exit");
                    int option = GetIntBetween(1, exit_choice);
                    if (option == exit_choice)
                    {
                        return;
                    }
                    else
                    {
                        PlantHolder holder = Garden.HolderList[option - 1];
                        if (holder.Seeded)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("This plant holder has been seeded.\n If you sell it, you will lose the seed.");
                            Console.WriteLine("Are you sure you want to sell this plant holder?");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("1. Yes\n2. No");

                            int sell = GetIntBetween(1, 2);
                            if (sell == 2)
                            {
                                Console.Clear();
                                VisitSellingState();
                                return;
                            }
                        }
                        Bag.Money += holder.HolderPrice / 2;
                        Garden.RemovePlantHolder(holder);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Sell plant holder successfully");
                        Console.ForegroundColor = ConsoleColor.White;
                        PressEnter();
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            
        }
        public void Start()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Welcome to the Garden Game");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Playing new game");
            Console.WriteLine("2. Keep playing");
            int choice = GetIntBetween(1, 2);
            if (choice == 2)
            {
                RestoreData();
            }
            Console.Clear();
            Dashboard();
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            System Game = new System();
            Game.Start();
        }
    }
}
