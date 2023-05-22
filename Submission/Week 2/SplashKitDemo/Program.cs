using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        new Window("New games", 800, 600);
        do
        {
            SplashKit.ProcessEvents();
            //SplashKit.DrawCircle(Color.Red, 100, 100, 20);
            SplashKit.FillCircle(Color.Red, 100, 100, 20);
            SplashKit.DrawRectangle(Color.Blue, 100, 100, 40, 40);
            SplashKit.DrawTriangle(Color.Red, 100, 100, 200, 200, 100, 400);
            Console.WriteLine("drawing");
            //SplashKit.ClearScreen();
            SplashKit.RefreshScreen();

        } while (!SplashKit.WindowCloseRequested("New games"));
    }
}