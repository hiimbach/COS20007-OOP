using SplashKitSDK;
using System;
using System.Collections.Generic;

namespace ShapeDrawer
{ 
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;
        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }

        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }

        public Drawing() : this(Color.White)
        {

        }

        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach (Shape shape in _shapes)
            {
                shape.Draw();
            }
        }

        public void SelectShapeAt()
        {
            foreach (Shape shape in _shapes)
            {
                if (shape.IsAt(SplashKit.MousePosition()))
                {
                    shape.Selected = true;
                }
                else
                {
                    shape.Selected = false;
                }
            }
        }

        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        public void RemoveShapes(Shape shape)
        {
            _shapes.Remove(shape);
        }

        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();
                foreach (Shape shape in _shapes)
                {
                    if (shape.Selected)
                    {
                        result.Add(shape);
                    }
                }
                return result;
            }



        }

        public int ShapeCount
        {
            get { return _shapes.Count; }
        }

    }
}
