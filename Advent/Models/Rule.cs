using System;
using System.Collections.Generic;
using System.Text;

namespace Advent.Models
{
    class Rule
    {
        public string Bag { get; set; }
        public List<ContainedBag> ContainedBags { get; set; } = new List<ContainedBag>();
    }
}
