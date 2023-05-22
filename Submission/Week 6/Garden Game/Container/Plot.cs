using System;
using System.Collections.Generic;
using System.Text;

namespace Garden_Game
{
    // The plot is used to plant fruit, not the flower
    class Plot : PlantHolder
    {
        public Plot(string name, double holder_price): base(name, holder_price)
        {
            /*HolderType = HolderType.Plot;*/
        }

        public override HolderType HolderType
        {
            get { return HolderType.Plot; }
        }

    }
}
