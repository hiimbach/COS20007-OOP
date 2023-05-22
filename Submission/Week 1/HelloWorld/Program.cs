using System;

namespace HelloWorld
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Message helloWorld;
            helloWorld = new Message("Hello World - from Message Object");
            helloWorld.Print();

            Message myMessage1;
            myMessage1 = new Message("Hi , wanna have a cup of tea?");
            Message myMessage2;
            myMessage2 = new Message("I know you, you dumb");
            Message myMessage3;
            myMessage3 = new Message("Finally I have found a beautiful name");
            Message myMessage4;
            myMessage4 = new Message("So..This is called a nAmE?");

            Message[] messages = new Message[] { myMessage1, myMessage2, myMessage3, myMessage4 };

            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();

            if (name.ToLower() == "trung")
            {
                messages[0].Print();
            }
            else if (name.ToLower() == "bach")
            {
                messages[1].Print();
            }
            else if (name.ToLower() == "tan")
            {   
                messages[2].Print();
            }
            else
            {
                messages[3].Print();    
            }

        }
    }
}