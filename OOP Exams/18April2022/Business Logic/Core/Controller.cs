using Heroes.Core.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IHero> heroes;
        private readonly IRepository<IWeapon> weapons;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            var name = heroes.FindByName(heroName);
            if (name == null)
            {
                return $"Hero { heroName } does not exist.";
            }
            if (name.Weapon != null)
            {
                   return  $"Hero { heroName } is well-armed.";
            }
            var weapon = weapons.FindByName(weaponName);
            if (weapon == null)
            {
                    return $"Weapon { weaponName } does not exist.";
            }       
        
            name.AddWeapon(weapon);
            weapons.Remove(weapon);           
            return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            var namee = heroes.FindByName(name);
            if (namee != null)
            {
               return ($"The hero {name} already exists.");
            }
            if ("Knight"!= type && "Barbarian" != type)
            {
                return ($"Invalid hero type.");
            }
            if (type == "Knight")
            {
                Knight kn = new Knight(name, health, armour);
                heroes.Add(kn);
                return $"Successfully added Sir { name } to the collection.";
            }
            else
            {
                Barbarian ba = new Barbarian(name, health, armour);
                heroes.Add(ba);
                return $"Successfully added Barbarian { name } to the collection.";
            }
            
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            var weapon = weapons.FindByName(name);
            if (weapon != null)
            {
                return $"The weapon { name } already exists.";
            }
          
            if ("Claymore"!= type &&"Mace"!= type)
            {
                return $"Invalid weapon type.";
            }
            if (type == "Claymore")
            {
                Claymore cl = new Claymore(name, durability);
                weapons.Add(cl);
            }
            else
            {
                Mace ma = new Mace(name, durability);
                weapons.Add(ma);
            }
            return $"A {type.ToLower()} { name } is added to the collection.";
        }
        public string HeroReport()
        {
            var h = heroes.Models.OrderBy(x => x.GetType().Name).ThenByDescending(x => x.Health).ThenBy(x => x.Name);
            StringBuilder sb = new StringBuilder();
            foreach (var item in h)
            {
               
                sb.AppendLine($"{item.GetType().Name}: {item.Name}");
                sb.AppendLine($"--Health: {item.Health}");
                sb.AppendLine($"--Armour: { item.Armour}");
                
                if (item.Weapon == null)
                {
                    sb.AppendLine($"--Weapon: Unarmed");
                }
                else
                { 
                    sb.AppendLine($"--Weapon: {item.Weapon.Name}");
                }
               

            }
            return sb.ToString().Trim();
        }

        public string StartBattle()
        {
            Map mp = new Map();
            List<IHero> mm = heroes.Models.Where (x => x.IsAlive && x.Weapon != null).ToList();
            return mp.Fight(mm);
        }
    }
}
