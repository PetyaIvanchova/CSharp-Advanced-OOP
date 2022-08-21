using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Map
{
    using Models.Contracts;
    using Models.Heroes;
    public class Map : IMap
    {

        public string Fight ( ICollection<IHero> players )
        {
            List<Knight> kn = new List<Knight> ();
            List<Barbarian> ba = new List<Barbarian> ();
            int countK = 0;
            int countB = 0;
            foreach ( var item in players )
            {
                if ( item is Knight knight )
                {
                    kn.Add (knight);
                    if ( knight.IsAlive )
                    {
                        countK++;                    
                    }
                }
                else
                {
                    ba.Add ((Barbarian) item);
                    if ( ( (Barbarian) item ).IsAlive )
                    {
                        countB++;
                    }
                }
            }
                while ( countB > 0 && countK > 0 )
                {
                    foreach ( var item in kn )
                    {
                        if ( item.IsAlive  )
                        {
                            foreach ( var item1 in ba )
                            {
                                if ( item1.IsAlive  )
                                {
                                    int weapondamage = item.Weapon.DoDamage ();
                                    item1.TakeDamage (weapondamage);
                                    if ( !item1.IsAlive )
                                    {
                                        countB--;
                                    }
                                }
                       if ( countB == 0) return $"The knights took {kn.Count - countK} casualties but won the battle.";
                            }
                        }

                    }
                    foreach ( var item in ba )
                    {
                        if ( item.IsAlive  )
                        {
                            foreach ( var item1 in kn )
                            {
                                if ( item1.IsAlive  )
                                {
                                    int weapondamage = item.Weapon.DoDamage ();
                                    item1.TakeDamage (weapondamage);
                                    if ( !item1.IsAlive )
                                    {
                                        countK--;
                                    }
                                }
                                if ( countK == 0 ) return $"The barbarians took {ba.Count - countB} casualties but won the battle.";
                            }
                        }
                    }
                }
                return $"The barbarians took {ba.Count - countB} casualties but won the battle.";
            }
        }
    }
