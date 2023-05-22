using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure.Command
{
    internal class CommandProfessor
    {
        MoveCommand _move_command;
        LookCommand _look_command;

        public CommandProfessor()
        {
            _move_command = new MoveCommand();
            _look_command = new LookCommand();
        }

        public string Execute(Player p, string user_input)
        {
            string[] text = user_input.Split(' ');
            if (text.Length == 0)
            {
                return "Please type something...";
            }
            string type = text[0];
            if (text.Length == 1)
            {
                if (text[0] == "look")
                {
                    return p.Location.Description;
                }
                else if (text[0] == "quit")
                {
                    Environment.Exit(0);
                    return "";
                }
                else if ("inventory inv".Contains(text[0].ToLower()))
                {
                    return p.FullDescription;
                }
                else
                {
                    return "Invalid command";
                }
                
            }
            else if (_look_command.AreYou(type))
            {
                return _look_command.Execute(p, text);
            }
            else if (_move_command.AreYou(type))
            {
                Console.WriteLine("go go go");
                return _move_command.Execute(p, text);
            }
            
            
            else
            {
                return "Invalid command";
            }
        }


    }
}
