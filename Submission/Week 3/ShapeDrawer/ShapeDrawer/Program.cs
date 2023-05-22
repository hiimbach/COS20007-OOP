using SplashKitSDK;
using System;
using System.Collections.Generic;
using Shapes;
using ShapeDrawing;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {    
            new Window("Shape Drawer", 800, 600);
            Drawing drawing = new Drawing();
            do
            {
                SplashKit.ProcessEvents();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape new_shape = new Shape(SplashKit.MouseX(), SplashKit.MouseY());
                    drawing.AddShape(new_shape);
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    drawing.SelectShapeAt();
                }


                if (SplashKit.KeyDown(KeyCode.SpaceKey))
                {
                    Color new_color = SplashKit.RandomRGBColor(255);
                    drawing.Background = new_color;
                }

                if (SplashKit.KeyDown(KeyCode.DeleteKey) || SplashKit.KeyDown(KeyCode.BackspaceKey))
                {
                    foreach (Shape shape in drawing.SelectedShapes)
                    {
                        if (shape.Selected)
                        {
                            drawing.RemoveShapes(shape);
                        }
                    }
                }

                drawing.Draw();

                SplashKit.RefreshScreen(60);
            } while (!SplashKit.WindowCloseRequested("Shape Drawer"));


        }
    }
}