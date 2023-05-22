using System;
using System.Collections.Generic;
using System.Text;

namespace Garden_Game
{
    struct Seed
    {
        public string Name;
        public Type Type;
        public double BuyPrice;
        public double SellPrice;
        public double MilliliterWaterPerDay;
        public int DaysToGrow;

        public Seed(string name, Type type, double buyprice, double sellprice, int milliliter, int days)
        {
            Name = name;
            Type = type;
            BuyPrice = buyprice;
            SellPrice = sellprice;
            MilliliterWaterPerDay = milliliter;
            DaysToGrow = days;
        }

        public string Description
        {
            get { return $"Seed: {Name}\nSell Price:{SellPrice}\nFully-Growth after: {DaysToGrow} days\nEach day, you need to provide: {MilliliterWaterPerDay} ml water"; }
        }

    }

    public enum Type
    {
        Flower,
        Fruit,
    }
    public enum WaterDemand
    {
        NeedWater,
        DontNeedWater
    }

    enum HolderType
    {
        Plot,
        FlowerPot
    }



}
