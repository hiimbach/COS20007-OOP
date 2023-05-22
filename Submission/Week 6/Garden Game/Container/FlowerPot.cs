using System;
using System.Collections.Generic;
using System.Text;

namespace Garden_Game
{
    // The flower pot is only used to grow flower
    class FlowerPot:PlantHolder
    {
        public FlowerPot(string name, double holder_price): base(name, holder_price) 
        {
            /*HolderType = HolderType.FlowerPot;*/
        }

        public override HolderType HolderType
        {
            get { return HolderType.FlowerPot; }
        }
        public override void CheckDone()
        {
            if (DaysRemaining == Seed.DaysToGrow)
            {
                Price = Seed.SellPrice + HolderPrice*1.5;
            }
        }

    }
}
