using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Bags
{
    using Models.Bags.Contracts;
    public class Backpack : IBag
    {
        private List<string> items;
        public ICollection<string> Items => items;
        public Backpack()
        {
            items = new List<string>();
        }
    }
}
