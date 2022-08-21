using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{

    public abstract class Weapon : IWeapon
    {


        public Weapon ( string name , int durability )
        {
          this. Name = name;
          this. Durability = durability;
        }
        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                if ( string.IsNullOrWhiteSpace (value) )
                {
                    throw new ArgumentException ("Weapon type cannot be null or empty.");
                }
                this.name = value;
            }

        }
        private int durability;
        public int Durability
        {
            get { return durability; }
            protected set
            {
                if ( value < 0 )
                {
                    throw new ArgumentException ("Durability cannot be below 0.");
                }
                this.durability = value;
            }

        }

        public abstract int DoDamage ();

    }
}


