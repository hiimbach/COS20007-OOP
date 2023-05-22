using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    internal class MyLine : Shape
    {

        public MyLine() : this(Color.Red, 0, 0) { }
        public MyLine(Color clr, float x, float y) : base(clr)
        {
            X = x;
            Y = y;
        }


        public override void Draw()
        {
            if (Selected)
            {
                SplashKit.FillCircle(Color.Black, X, Y, 2);
                SplashKit.FillCircle(Color.Black, X + 100, Y, 2);
            }
            SplashKit.DrawLine(Color, X, Y, X+100, Y);
        }

        public override void DrawOutline()
        {
            
        }
        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointOnLine(pt, SplashKit.LineFrom(SplashKit.PointAt(X, Y), SplashKit.PointAt(X + 100, Y)));
        }

    }
}
