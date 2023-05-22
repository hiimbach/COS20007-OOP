using System;
using System.Collections.Generic;
using System.Text;

namespace Iteration3
{
    public class GameObject:IdentifiableObject
    {
        private string  _description;
        string _name;

        public GameObject(string[] ids, string name, string description): base(ids)
        {
            _description = description;
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public virtual string FullDescription
        {
            get { return _description ; }
        }

        public string ShortDescription
        {
            get { return $"a {_name} ({FirstID})"; }
        }
    }
}
