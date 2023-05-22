using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    internal class MyRectangle:Shape
    {
        int _width, _height;

        public MyRectangle(): this(Color.Green, 0, 0, 100, 100) { }
        public MyRectangle(Color clr, float x, float y, int width, int height): base (clr)
        {
            _width = width;
            _height = height;
            X = x;
            Y = y;
        }


        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.FillRectangle(Color, X, Y, _width, _height);
        }

        public override void DrawOutline()
        {
            SplashKit.FillRectangle(Color.Black, X - 2, Y - 2, _width + 4, _height + 4);
        }
        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointInRectangle(pt, SplashKit.RectangleFrom(X, Y, _width, _height));
        }

    }
}
