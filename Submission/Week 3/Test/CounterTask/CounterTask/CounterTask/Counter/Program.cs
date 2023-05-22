using System;

namespace CounterTask
{
    class Counter
    {
        private string _name;
        int _count;

        public Counter(string name)
        {
            _name = name;
            _count = 0;
        }

        public void Incremend()
        {
            _count+= 1;
        }

        public void Reset()
        {
            _count = 0;
        }

        public int Ticks
        {
            get { return _count; }
        }

        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

    }
    
    public class MainClass
    {
         private static void PrintCounters(Counter[] counters)
        {
            foreach (Counter c in counters)
            {
                Console.WriteLine("{0} is {1}", c.Name, c.Ticks);
            }
            
        }

        private static void Main(string[] args)
        {
            Counter[] myCounters = new Counter[3];
            myCounters[0] = new Counter("Counter1");
            myCounters[1] = new Counter("Counter2");
            myCounters[2] = myCounters[0];

            for (int i = 0; i<=4; i++)
            {
                myCounters[0].Incremend();
            }

            for (int i = 0; i<=9; i++)
            {
                myCounters[1].Incremend();
            }

            PrintCounters(myCounters);
            myCounters[2].Reset();

            PrintCounters(myCounters);



        }
    }
}

