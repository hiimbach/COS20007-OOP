using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiers = new List<string>();
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

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }

    }
}
