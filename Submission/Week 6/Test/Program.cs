using System;
namespace Test
{
    class Garden
    {
        string _water;
        private static Garden GARDEN = new Garden();

        private Garden()
        {
            _water = "Water the plant";
        }

        public static Garden GoToGarden()
        {
            return GARDEN;
        }

        public void Water()
        {
            Console.WriteLine(_water);
        }
        public string WaterVar
        {
            get { return _water; }
            set { _water = value; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Garden G = Garden.GoToGarden();
            G.Water();
            //We changed the WaterVar to "Water the tree"
            G.WaterVar = "Water the tree";
            G.Water();
            // We created a new Garden B, but the WaterVar is still "Water the tree"
            Garden B = Garden.GoToGarden();
            B.Water();
        }

    }
}