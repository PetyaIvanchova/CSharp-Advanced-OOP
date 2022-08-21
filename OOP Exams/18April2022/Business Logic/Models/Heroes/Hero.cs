using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Heroes
{
    
    
    public abstract class Hero : IHero
    {
        private string name;
        public string Name
        {
            get { return this.name; }
            private set
            {
                if ( string.IsNullOrWhiteSpace (value) )
                {
                    throw new ArgumentException ("Hero name cannot be null or empty.");
                }
                this.name = value;
            }
        }
        private int health;
        public int Health
        {
            get { return health; }
            private set
            {
                if ( value < 0 )
                {
                    throw new ArgumentException ("Hero health cannot be below 0.");
                }
                health = value;

            }

        }
        private int armour;
        public int Armour
        {
            get { return armour; }
            private set
            {
                if ( value < 0 )
                {
                    throw new ArgumentException ("Hero armour cannot be below 0.");
                }

                armour = value;

            }
        }
        private bool isAlive;

        public Hero ( string name , int health , int armour )
        {
          this. Name = name;
          this. Health = health;
          this. Armour = armour;
            
        }

        public bool IsAlive
        {
            get
            {
                if ( this.health > 0 )
                {

                    isAlive = true;
                }
                else
                {
                    isAlive = false;
                }
                return isAlive;
            }
        }
        private IWeapon weapon;
        public IWeapon Weapon
        {
            get
            {

                return this.weapon;
            }
            private set
            {
                if ( value is null )
                {
                    throw new ArgumentNullException ("Weapon cannot be null.");
                }
                weapon = value;
            }

        }

        public void TakeDamage ( int points )
        {
            int p = this.Armour - points;
            if ( p <= 0 )
            {
                this.Armour = 0;
                if ( Health + p < 0 )
                {
                    Health = 0;
                }
                else { Health += p; }
            }  
                 
                
            
            else
            {
                this.Armour = p;   
            }
        }

        public void AddWeapon ( IWeapon weapon )
        {
            this.Weapon = weapon;
        }
    }
}
