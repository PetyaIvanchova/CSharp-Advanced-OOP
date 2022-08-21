﻿using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{



    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> heroes;

        public HeroRepository ()
        {
            heroes = new List<IHero> ();
        }

        public IReadOnlyCollection<IHero> Models { get => heroes.AsReadOnly(); }

        public void Add ( IHero model ) => heroes.Add (model);
        public IHero FindByName ( string name ) => heroes.FirstOrDefault (x => x.Name == name);
        public bool Remove ( IHero model )
        {  
            if ( heroes.Contains (model) )
            {
                heroes.Remove (model);
                return true;
            }

            return false;
        }
    }
}