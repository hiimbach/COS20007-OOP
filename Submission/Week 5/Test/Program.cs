using System;
using System.Collections.Generic;

namespace Test
{

    public class Phone
    {
        public Phone() { }
        private string _name, _phone;
        public virtual void insertPhone(string name, string phone) { }

        public virtual void removePhone(string name) { }

        public virtual void updatePhone(string name, string newphone) { }

        public virtual void searchPhone(string name) { }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Phone_Number
        {
            get { return _phone; }
            set { _phone = value;  }
        }
    }

    public class PhoneBook:Phone
    {
        List<Phone> PhoneList;
        public PhoneBook()
        {
            PhoneList = new List<Phone>();
        }

        public override void insertPhone(string name, string phone)
        {
            foreach (Phone phone_in_list in PhoneList)
            {
                if (name == phone_in_list.Name)
                {
                    if (phone == phone_in_list.Phone_Number)
                    {
                        Console.WriteLine("This phone is already in the phone list");
                        return; 
                    }
                    else
                    {
                        updatePhone(name, phone);
                        return;
                    }
                    
                }
            }
            Phone new_phone = new Phone();
            new_phone.Name = name;
            new_phone.Phone_Number = phone;
            PhoneList.Add(new_phone);
            Console.WriteLine("Added");
        }

        public override void updatePhone(string name, string newphone)
        {
            foreach (Phone phone_in_list in PhoneList)
            {
                if (name == phone_in_list.Name)
                {
                    phone_in_list.Phone_Number = newphone;
                    Console.WriteLine("Updated");
                    return;
                }
            }
            Console.WriteLine("This phone does not belong to anyone to be updated");
        }

        public override void removePhone(string name)
        {
            foreach (Phone phone_in_list in PhoneList)
            {
                if (name == phone_in_list.Name)
                {
                    PhoneList.Remove(phone_in_list);
                    Console.WriteLine("Removed");
                    return;
                }
            }
        }

        public override void searchPhone(string name)
        {
            foreach (Phone phone_in_list in PhoneList)
            {
                if (name == phone_in_list.Name)
                { 
                    Console.WriteLine(phone_in_list.Phone_Number);
                    return;
                }
                Console.WriteLine($"There is not any one named {name}");
            }
        }
    }

    internal class Program
    {
        static void Main()
        {
            PhoneBook FB = new PhoneBook();
            bool open = true;
            while (open)
            {
                Console.WriteLine("PHONEBOOK MANAGEMENT SYSTEM");
                Console.WriteLine("1. Insert Phone");
                Console.WriteLine("2. Update Phone");
                Console.WriteLine("3. Remove Phone");
                Console.WriteLine("4. Search Phone");
                Console.WriteLine("5. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());
                
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Insert Phone");
                        Console.WriteLine("Name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Phone:");
                        string phone = Console.ReadLine();
                        FB.insertPhone(name, phone);
                        break;
                    case 2:
                        Console.WriteLine("Update Phone");
                        Console.WriteLine("Name:");
                        name = Console.ReadLine();
                        Console.WriteLine("Phone:");
                        phone = Console.ReadLine();
                        FB.updatePhone(name, phone);
                        break;
                    case 3:
                        Console.WriteLine("Remove Phone");
                        Console.WriteLine("Name:");
                        name = Console.ReadLine();
                        FB.removePhone(name);
                        break;
                    case 4:
                        Console.WriteLine("Search Phone");
                        Console.WriteLine("Name:");
                        name = Console.ReadLine();
                        FB.searchPhone(name);
                        break;
                    case 5:
                        open = false;
                        break;
                    default:
                        Console.WriteLine("Choose 1 to 5 please!");
                        break;
                }

                Console.WriteLine("------------------------------------------------------------");

            }

        }
    }
}
