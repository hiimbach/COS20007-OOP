using System;
using System.Collections.Generic;
using System.Text;

namespace Garden_Game.Container
{
    internal class BuyingState
    {
        private static BuyingState Buying = new BuyingState();
        List<Seed> _seed_collection;
        List<FlowerPot> _pot_collection;
        private BuyingState()
        {
            Seed sunflower = new Seed("Sun Flower", Type.Flower, 0.5, 1, 200, 4);
            Seed watermelon = new Seed("Watermelon", Type.Fruit, 2, 5, 500, 10);
            Seed rose = new Seed("Rose", Type.Flower, 0.2, 2, 100, 3);
            Seed melon = new Seed("Melon", Type.Fruit, 1, 3, 400, 7);
            Seed dragonfruit = new Seed("Dragonfruit", Type.Fruit, 2, 4, 400, 5);
            Seed apple = new Seed("Apple", Type.Fruit, 1, 2, 200, 3);
            Seed blossom = new Seed("Blossom", Type.Flower, 4, 10, 200, 10);

            FlowerPot porcelain = new FlowerPot("Porcelain flower pot", 3);
            FlowerPot plastic = new FlowerPot("Plastic flower pot", 1);
            FlowerPot wood = new FlowerPot("Wooden flower pot", 2);


            _seed_collection = new List<Seed>();
            _pot_collection = new List<FlowerPot>();

            _seed_collection.Add(sunflower);
            _seed_collection.Add(watermelon);
            _seed_collection.Add(rose);
            _seed_collection.Add(melon);
            _seed_collection.Add(dragonfruit);
            _seed_collection.Add(blossom);
            _seed_collection.Add(apple);

            _pot_collection.Add(plastic);
            _pot_collection.Add(porcelain);
            _pot_collection.Add(wood);



        }
        public static BuyingState GoToBuyingState()
        {
            return Buying;
        }

        public string SeedShopDescription
        {
            get
            {
                string statement = "";
                int index = 1;
                foreach (Seed seed in _seed_collection)
                {
                    statement += $"{index}. {seed.Name}: price {seed.BuyPrice}$\n";
                    index++;
                }

                return statement;
            }
        }
        public string FlowerPotShopDescription
        {
            get
            {
                string statement = "";
                int index = 1;
                foreach (FlowerPot pot in _pot_collection)
                {
                    statement += $"{index}. {pot.Name}: price {pot.HolderPrice}$\n";
                    index++;
                }

                return statement;
            }
        }

        public List<Seed> SeedCollection
        {
            get { return _seed_collection; }
        }
        public List<FlowerPot> PotCollection
        {
            get { return _pot_collection; }
        }


    }
}
