using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure.Command
{
    public interface IHaveInventory
    {
        public GameObject Locate(string id);

        public string Name
        {
            get;
        }
        public Inventory Inventory
        {
            get;
        }
    }
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" })
        {

        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 5 && text.Length != 3)
            {
                return "I don't know how to look like that";
            }
            if (text[0] != "look")
            {
                return "Error in look input";
            }
            if (text[1] != "at")
            {
                return "What do you want to look at?";
            }
            if (text.Length == 5 && text[3] != "in")
            {
                return "What do you want to look in";
            }
            if (text.Length == 5)
            {
                string containerID = text[4];
                IHaveInventory container = FetchContainer(p, containerID);
                if (container != null)
                {
                    return LookAtIn(text[2], container);
                }
                else
                {
                    return $"I can't find the {containerID}";

                }
            }
            else
            {
                return LookAtIn(text[2], p);
            }

        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            if (p.AreYou(containerId))
            {
                return p;
            }
            return p.Locate(containerId) as IHaveInventory;
        }

        private string LookAtIn(string thingID, IHaveInventory container)
        {
            GameObject thing = container.Locate(thingID);
            if (thing != null)
            {
                return thing.FullDescription;
            }
            return $"I can't find the {thingID}";
        }



    }
}
