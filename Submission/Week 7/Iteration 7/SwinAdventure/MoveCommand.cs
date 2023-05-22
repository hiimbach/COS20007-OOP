using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        Path _invalid = new Path(new string[] { "" }, new Location("", ""), "");
        Path _no = new Path(new string[] { "" }, new Location("", ""), "");
        string _chosen_direction;
        public MoveCommand() : base(new string[] { "move", "go", "head" })
        {


        }

        public override string Execute(Player p, string[] text)
        {
            Path path = TakePath(p, text);
            if (path == _invalid)
            {
                return "Please go to correct direction";
            }
            else if (path == _no)
            {
                return "There is no destination in that direction";
            }
            else
            {
                path.MovePlayer(p);
                return $"You move to {_chosen_direction}\n{path.Description}\nYou have arrived in {p.Location.Name}";
            }
        }


        public Path TakePath(Player p, string[] text)
        {
            if (text.Length == 2)
            {
                _chosen_direction = $"{text[1]}";
            }
            else if (text.Length == 3)
            {
                _chosen_direction = $"{text[1]} {text[2]}";
            }
            else
            {
                return _invalid;
            }

            foreach (Path path in p.Location.AllPath)
            {
                if (path.AreYou(_chosen_direction))
                {
                    return path;
                }
            }
            return _no;
        }



    }
}
