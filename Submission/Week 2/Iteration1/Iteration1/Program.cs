using System;
using System.Collections.Generic;



namespace Iteration1
{
    public class IdentifiableObject
    {
        List<string> _identifiers = new List<string>();
        public IdentifiableObject(string[] idents)
        {
            foreach (string ident in idents)
            {
                _identifiers.Add(ident.ToLower());

            }
        }

        public bool AreYou(string id)
        {
            if (_identifiers.Contains(id.ToLower()))
            {
                return true;
            }
            else
            {
                return false;   
            }
        }

        public string FirstID
        {
            get
            {
                if (_identifiers.Count == 0)
                {
                    return "";
                }
                else
                {
                    return _identifiers[0];
                }
            }
        }

        public void AddIdentifier (string id)
        {
            _identifiers.Add (id.ToLower());
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IdentifiableObject switches = new IdentifiableObject(new string[] { "cherry", "ktt", "jwick" });
            Console.WriteLine(switches.AreYou("ktt"));
            Console.WriteLine(switches.AreYou("kailh"));
            Console.WriteLine(switches.AreYou("cHErrY"));
            Console.WriteLine(switches.FirstID);
            switches.AddIdentifier("kailh");
            Console.WriteLine(switches.AreYou("KAILH"));

        }
    }
}
