using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Planets
{
    using Models.Planets.Contracts;
    public class Planet : IPlanet
    {
        public ICollection<string> Items => items.AsReadOnly();
        private List<string> items;
        public Planet(string name)
        {
            Name = name;
            items = new List<string>();
        }
        private string name;
        public string Name
        {
            get { return this.name; }
           private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Invalid name!");
                }
                this.name = value;
            }
        }
    }
}
