using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }

        private static void Main()
        {
            ShapeKind kindToAdd = ShapeKind.Circle;
            new Window("Shape Drawer", 800, 600);
            Drawing myDrawing = new Drawing();
            do
            {
                SplashKit.ProcessEvents();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape = new MyRectangle();
                    if (kindToAdd == ShapeKind.Rectangle)
                    {
                        MyRectangle newRect = new MyRectangle() ;
                        newRect.X = SplashKit.MouseX();
                        newRect.Y = SplashKit.MouseY();
                        newShape = newRect;
                    }
                    else if (kindToAdd == ShapeKind.Circle)
                    {
                        MyCircle newCirle = new MyCircle();
                        newCirle.X = SplashKit.MouseX();
                        newCirle.Y = SplashKit.MouseY();
                        newShape = newCirle;
                    }
                    else if (kindToAdd == ShapeKind.Line)
                    {
                        MyLine newLine = new MyLine();
                        newLine.X = SplashKit.MouseX();
                        newLine.Y = SplashKit.MouseY();
                        newShape = newLine;
                        
                    }

                    myDrawing.AddShape(newShape);
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectShapeAt();
                }


                if (SplashKit.KeyDown(KeyCode.SpaceKey))
                {
                    Color new_color = SplashKit.RandomRGBColor(255);
                    myDrawing.Background = new_color;
                }

                if (SplashKit.KeyDown(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }

                if (SplashKit.KeyDown(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                if (SplashKit.KeyDown(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                if (SplashKit.KeyDown(KeyCode.DeleteKey) || SplashKit.KeyDown(KeyCode.BackspaceKey))
                {
                    foreach (Shape shape in myDrawing.SelectedShapes)
                    {
                        if (shape.Selected)
                        {
                            myDrawing.RemoveShapes(shape);
                        }
                    }
                }

                myDrawing.Draw();

                SplashKit.RefreshScreen(60);
            } while (!SplashKit.WindowCloseRequested("Shape Drawer"));


        }
    }
}