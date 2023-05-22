using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class Pet
    {
        private string _name;
        string _color;
        int _old;

        public void makeSound()
        {
            Console.WriteLine("{0} says {1}", _name, GetSound());
        }

        public virtual string GetSound()
        {
            return "";
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Color
        {
            get { return _color; }
            set { _color = value;  }
        }

        public int Old
        {
            get { return _old; }
            set { _old = value; }
        }
    }

    class Cat:Pet
    {
        public override string GetSound()
        {
            return "Meow meow";
        }
    }

    class Dog:Pet
    {
        public override string GetSound()
        {
            return "Go go";
        }
    }
}
