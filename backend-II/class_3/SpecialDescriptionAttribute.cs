using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDescription
{
    public class SpecialDescriptionAttribute : Attribute
    {
        public string Description { get; private set; }

        public SpecialDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}
