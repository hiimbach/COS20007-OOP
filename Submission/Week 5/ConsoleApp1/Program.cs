using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    struct A
    {
        public int x, y;
    }
    internal class Program
    {
        class Test
        {
            public delegate void ShowData(string data);
            public void Infor (String data)
            {
                Console.WriteLine("Infor running: "+ data);
            }

            public void Warning(String data)
            {
                Console.WriteLine("Warning running: " + data);
            }

            public void Running()
            {
                ShowData sd;
                sd = Infor;
                sd("Hello");
                sd = Warning;
                sd("World");
            }
        }
        static void Main(string[] args)
        {
            Test test = new Test();
            test.Running();

        }
    }
}
