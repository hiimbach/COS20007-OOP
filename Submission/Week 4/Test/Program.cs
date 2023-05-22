using System;

namespace Test
{

    class Car
    {
        string _category;
        string _color;
        int day_used = 0;
        string _owner;

        
        public string Name
        {
            get { return _owner; }
            set { _owner = value; }
        }
        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public int DayUsed
        {
            get { return day_used;}
            set
            {
                day_used = value;
            }
        }

        public void UseOneMoreDay()
        {
            day_used++;
        }

        public void ReNewTheCar()
        {
            day_used = 0;
        }

        public virtual string CarType()
        {
            return "";
        }
        
    }

    class Audi:Car
    {
        public override string CarType()
        {
            return "This is an Audi";
        }
    }
    class Toyota : Car
    {
        public override string CarType()
        {
            return "This is an Toyota";
        }
    }

    internal class Program
    {
        public static void Main()
        {
            Car car = new Car();
        }

    }
}
