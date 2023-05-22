using SplashKitSDK;
using System;

namespace ShapeDrawer
{
    public class Program
    {
        public class Shape
        {
            private Color _color = Color.Green;
            int _width = 100;
            int _height = 100;
            float _x ;
            float _y ;

            public void Draw()
            {
                SplashKit.FillRectangle(_color, _x, _y, _width, _height);
            }

            public bool IsAt(Point2D pt) {
                return SplashKit.PointInRectangle(pt, SplashKit.RectangleFrom(_x, _y, _width, _height));
            }

            public void ChangePosition(float new_x, float new_y)
            {
                _x = new_x;
                _y = new_y;
            }

            public void ChangeColor(Color new_color)
            {
                _color = new_color;
            }
        }

        
        public static void Main()
        {    
            new Window("Shape Drawer", 800, 600);
            Shape myShape = new Shape();
            myShape.Draw();
            do
            {
                SplashKit.ProcessEvents();

                myShape.Draw();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    myShape.ChangePosition(SplashKit.MouseX(), SplashKit.MouseY());
                    SplashKit.ClearScreen();

                }


                if (SplashKit.KeyDown(KeyCode.SpaceKey) && myShape.IsAt(SplashKit.MousePosition()))
                {
                    Color new_color = SplashKit.RandomRGBColor(255);
                    myShape.ChangeColor(new_color);
                    SplashKit.ClearScreen();
                }
                
                SplashKit.RefreshScreen();
            } while (!SplashKit.WindowCloseRequested("Shape Drawer"));


        }
    }
}