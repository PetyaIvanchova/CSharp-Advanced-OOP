using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    using Models.Astronauts.Contracts;
    using SpaceStation.Models.Bags.Contracts;

    public abstract class Astronaut : IAstronaut
    {
        private string name;
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                   throw new ArgumentNullException("Astronaut name cannot be null or empty.");
                }
                this.name = value;
            }
        }
        private double oxygen;
        public double Oxygen
        {
            get { return this.oxygen; }
            protected set
            {
                if (value<0)
                {
                    throw new ArgumentException("Cannot create Astronaut with negative oxygen!");

                }
                this.oxygen = value;
            }
        }

        public bool CanBreath { get; private set; }

        public IBag Bag { get;private set; }

        public virtual void Breath()
        {
            Oxygen -= 10;
            if (Oxygen<0)
            {
                Oxygen = 0;
            }
        }
        public Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
        }
    }
}
