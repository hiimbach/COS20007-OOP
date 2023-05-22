using System;
using SplashKitSDK;

namespace MyGame
{
	public class Fruit 
	{
        private FruitKind _kind;

        private Point2D _position;
        private Vector2D _velocity;

        private Bitmap MyBitmap()
        {
            switch (_kind)
            {
                case FruitKind.Cherry:
                    return SplashKit.LoadBitmap("Cherry", "Cherry.png");
                case FruitKind.Gooseberry:
                    return SplashKit.LoadBitmap("Gooseberry", "Gooseberry.png");
                case FruitKind.Blueberry:
                    return SplashKit.LoadBitmap("Blueberry", "Blueberry.png");
                case FruitKind.Pomegranate:
                    return SplashKit.LoadBitmap("Pomegranate", "Pomegranate.png");
                case FruitKind.Apricot:
                    return SplashKit.LoadBitmap("Apricot", "Apricot.png");
                case FruitKind.Raspberry:
                   return SplashKit.LoadBitmap("Raspberry", "Raspberry.png");
                case FruitKind.Blackberry:
                    return SplashKit.LoadBitmap("Blackberry", "Blackberry.png");
                case FruitKind.Strawberry:
                    return SplashKit.LoadBitmap("Strawberry", "Strawberry.png");
                case FruitKind.Currant:
                    return SplashKit.LoadBitmap("Currant", "Currant.png");
                default:
                    return SplashKit.LoadBitmap("Currant", "Currant.png");
            }
        }

        public Fruit()
        {
            _position.X = 0;
            _position.Y = SplashKit.ScreenHeight();

            _velocity.X = 3.0;
            _velocity.Y = -7.0 + SplashKit.Rnd(2) - 1;

            _kind = FruitKind.Blueberry;
        }

        public void Update()
        {
            // update the position of the fruit
            _position.X += _velocity.X;
            _position.Y += _velocity.Y;
            // decay the velocity
            _velocity = SplashKit.VectorAdd(_velocity, SplashKit.VectorTo(0, 0.05));
        }

        public void Draw()
        {
            SplashKit.DrawBitmap(MyBitmap(), _position.X, _position.Y);
        }
    }
}
