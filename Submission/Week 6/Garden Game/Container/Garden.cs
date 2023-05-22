using System;
using System.Collections.Generic;
using System.Text;

namespace Garden_Game
{
    // Singleton Design Pattern
    class Garden
    {
        List<PlantHolder> holder_list;
        Bag Bag;

        private static Garden GARDEN = new Garden();

        private Garden()
        {
            holder_list = new List<PlantHolder>();
            Bag = Bag.GoToBag();
        }

        public static Garden GoToGarden()
        {
            return GARDEN;
        }
    

        public void AddPlantHolder(PlantHolder plant_holder)
        {
            holder_list.Add(plant_holder);
        }
        public void RemovePlantHolder(PlantHolder plant_holder)
        {
            holder_list.Remove(plant_holder);
        }
        public void OneDayPass()
        {
            foreach(PlantHolder plant in holder_list)
            {
                plant.OneDayPass();
            }
        }
        public void Sell(PlantHolder plant_holder)
        {
            Bag.Money += plant_holder.Price;
            if (plant_holder.HolderType == HolderType.Plot)
            {
                ResetPlantHolder(plant_holder);
            }
            else
            {
                RemovePlantHolder(plant_holder);
            }

        }
        public void ResetPlantHolder(PlantHolder plant_holder)
        {
            int index = holder_list.IndexOf(plant_holder);
            if (HolderList[index].HolderType == HolderType.Plot)
            {
                holder_list[index] = new Plot(plant_holder.Name, plant_holder.HolderPrice);
            }
            else
            {
                holder_list[index] = new FlowerPot(plant_holder.Name, plant_holder.HolderPrice);
            }
        }
        public List<PlantHolder> HolderList
        {
            get { return holder_list; }
        }
        public string Description
        {
            get
            {
                string statement = "";
                int i = 1;
                foreach (PlantHolder holder in holder_list)
                {
                    statement += $"{i}. {holder.ShortDescription}\n";
                    i++;
                }

                return statement;
            }
        }


    }
}
