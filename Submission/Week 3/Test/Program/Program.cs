using System;
using SplashKitSDK;

public class Program
{
    public class Shape
    {
        float _x;
        float _y;
        float speed = 3;
        

        
        public Shape (float x, float y, double angle)
        {
            _x = x; _y = y;
        }
        public void Draw()
        {
            SplashKit.DrawCircle(Color.Black, _x, _y, 50);
        }
    }
    public static void Main()
    {
        Random r = new Random();
        float angle = r.NextDouble();
        for (int i = 0; i < 5, i++)
        {
            Shape shape = new Shape();
        }
        new Window("New games", 800, 600);
        do
        {
            
         

        } while (!SplashKit.WindowCloseRequested("New games"));
    }
}