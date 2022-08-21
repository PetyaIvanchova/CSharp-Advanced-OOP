using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> models;
        public IReadOnlyCollection<IWeapon> Models { get => models; }

        public void Add ( IWeapon model ) => models.Add (model);
        public IWeapon FindByName ( string name ) => models.FirstOrDefault (x => x.Name == name);
        public bool Remove ( IWeapon model )
        {
            var p = models.FirstOrDefault (x => x.Name == model.Name && x.Durability == model.Durability);
            if ( p != null )
            {
                models.Remove (p);
                return true;
            }
            return false;
        }
    }
}

