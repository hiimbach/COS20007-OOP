using System;
using System.Collections.Generic;
using System.Text;

namespace Garden_Game
{
    class Bag
    {
        double _money;
        double _fertilizer;
        double _water;
        Dictionary<Seed, int> _all_seeds; 

        private static Bag BAG = new Bag();
        private Bag()
        {
            _money = 10;
            _all_seeds = new Dictionary<Seed, int>();
            _fertilizer = 2;
            _water = 1000;
        }
        public static Bag GoToBag()
        {
            return BAG;
        }

        public void AddSeed(Seed seed, int amount)
        {
            foreach (KeyValuePair <Seed, int> seed_in_bag in _all_seeds)
            {
                if (seed_in_bag.Key.Name == seed.Name)
                {
                    _all_seeds[seed_in_bag.Key] += amount;
                    return;
                }
            }
            _all_seeds.Add(seed, amount);
        }
        // If the plant holder is Flower Pot, the seed type need to be Flower. Otherwise, we use Fruit type.
        public void UseSeed(int i, PlantHolder plant_holder)
        {
            Type suitable_type;
            if (plant_holder.HolderType == HolderType.FlowerPot)
            {
                suitable_type = Type.Flower;
            }
            else
            {
                suitable_type = Type.Fruit;
            }

            int index = 1;
            foreach (KeyValuePair <Seed, int> seed_in_bag in _all_seeds)
            {
                if (seed_in_bag.Key.Type == suitable_type)
                {
                    if (index == i)
                    {
                        if (seed_in_bag.Value == 1)
                        {
                            _all_seeds.Remove(seed_in_bag.Key);
                        }
                        else
                        {
                            _all_seeds[seed_in_bag.Key] -= 1;
                        }
                        plant_holder.AddSeed(seed_in_bag.Key);
                        Console.WriteLine($"Add {seed_in_bag.Key.Name} successfully!");
                        return;
                    }
                    index++;
                }
                
            }
            Console.WriteLine("No seed found");
        }
        public void UseWater (double amount)
        {
            _water -= amount;
        }
        public void UseFertilizer(double amount)
        {
            _fertilizer -= amount;
        }

        public bool AllSeedsTypeOf(Type type)
        {
            string statement = "";
            int i = 1;
            foreach (KeyValuePair<Seed, int> seed_in_bag in _all_seeds)
            {
                if (seed_in_bag.Key.Type == type)
                {
                    statement += $"{i}. {seed_in_bag.Key.Name}: {seed_in_bag.Value} seeds\n";
                    i++;
                }
            }
            if (i == 1)
            {
                if (type == Type.Fruit)
                {
                    statement = "You have no Fruit seed";
                }
                else
                {
                    statement = "You have no Flower seed";
                }
            }
            Console.WriteLine(statement);
            return (i > 1);
        }

        public double Money
        {
            get { return _money; }
            set { _money = value; }
        }
     
        public int NumberOfSeed { get { return _all_seeds.Count; } }
        public double Fertilizer { get { return _fertilizer; } set { _fertilizer = value; } }
        public double Water { get { return _water; } set { _water = value; } }
        public Dictionary<Seed, int> All_Seed
        {
            get { return _all_seeds; }
        }


    }
}
