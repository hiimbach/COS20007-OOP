using System;

namespace CounterClock
{
    
    public class MainClass
    {

        private static void Main()
        {
            Clock time = new Clock();
            for (int i = 0; i < 1008; i++)
            {
                time.Tick();
                Console.WriteLine(time.ReadTime);
            }

        }
    }
}

