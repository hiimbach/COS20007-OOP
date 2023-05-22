using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    class MyCircle : Shape
    {
        float _radius = 50;

        public MyCircle(float radius, Color color)
        {
            _radius = radius;
            Color = color;
        }

        public MyCircle() : this(50, Color.Blue) { }
        public float Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.FillCircle(Color, X, Y, _radius);
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, X, Y, _radius + 2);
        }
        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointInCircle(pt, SplashKit.CircleAt(X, Y, _radius));
        }


    }
}
