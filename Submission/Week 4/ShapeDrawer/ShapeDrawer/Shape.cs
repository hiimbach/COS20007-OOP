using SplashKitSDK;
using System;
using System.Collections.Generic;

namespace ShapeDrawer   
{
    public abstract class Shape
    {
        private Color _color;
        float _x, _y;
        bool _selected;

        public Shape(Color color)
        {
            _color = color;
        }

        public Shape() : this(Color.Yellow) { }

        public abstract void Draw();

        public abstract bool IsAt(Point2D pt);

        public abstract void DrawOutline();

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

    }
}