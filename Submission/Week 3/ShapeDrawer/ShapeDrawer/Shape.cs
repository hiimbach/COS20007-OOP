using SplashKitSDK;
using System;
using System.Collections.Generic;

namespace Shapes
{
    public class Shape
    {
        private Color _color = Color.Green;
        int _width = 100;
        int _height = 100;
        float _x;
        float _y;
        bool _selected;

        public Shape(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public void Draw()
        {
            if (_selected)
            {
                DrawOutline();
            }
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }

        public bool IsAt(Point2D pt)
        {
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

        public void DrawOutline()
        {
            SplashKit.FillRectangle(Color.Black, _x - 2, _y - 2, _width + 4, _height + 4);
        }

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }
    }
}