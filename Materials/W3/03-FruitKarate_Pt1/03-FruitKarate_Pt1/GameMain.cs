using System;
using SplashKitSDK;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {
            FruitKarate _game = new FruitKarate();

            // open the game window
            new Window("Fruit Karate", 800, 600);
            
            // run the game loop
            while(!SplashKit.WindowCloseRequested("Fruit Karate"))
            {
                // fetch the next batch of UI interaction
                SplashKit.ProcessEvents();

                // check user input - space to launch fruit
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    _game.LaunchFruit();
                }

                // update the position and velocity of fruit
                _game.Update();
              
                // clear the screen to white
                SplashKit.ClearScreen(Color.White);

                // draw everything in the game
                _game.Draw();
                
                // draw onto the screen, limit to 60fps
                SplashKit.RefreshScreen(60);
            }
        }
    }
}