using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace MyGame
{
	public class FruitKarate
	{
        List<Fruit> _fruits = new List<Fruit>();

        public void LaunchFruit()
        {
            Fruit f = new Fruit();
            _fruits.Add(f);
        }

        public void Draw()
        {
            foreach (Fruit f in _fruits)
            {
                f.Draw();
            }
        }

        public void Update()
        {
            foreach (Fruit f in _fruits)
            {
                f.Update();
            }
        }
    }
}

