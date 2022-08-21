using Heroes.Models.Contracts;
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
        private List<IHero> models;

        public HeroRepository ()
        {
            models = new List<IHero> ();
        }

        public IReadOnlyCollection<IHero> Models { get => models; }

        public void Add ( IHero model ) => models.Add (model);
        public IHero FindByName ( string name ) => models.FirstOrDefault (x => x.Name == name);
        public bool Remove ( IHero model )
        {
            if ( models.Contains (model) )
            {
                models.Remove (model);
                return true;
            }

            return false;
        }
    }
}
