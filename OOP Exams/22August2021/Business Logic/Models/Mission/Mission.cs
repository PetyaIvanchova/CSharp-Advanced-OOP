using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Mission
{
    using Models.Mission.Contracts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Planets.Contracts;
    using System.Linq;
    using Models.Bags;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var ast in astronauts)
            {
                if (ast.Oxygen > 0)
                {
                    List<string> plItems = new List<string>();
                    foreach (var item in planet.Items)
                    {
                        ast.Breath();
                        ast.Bag.Items.Add(item);
                        plItems.Add(item);
                        if (ast.Oxygen == 0)
                        {
                            break;
                        }
                    }
                    foreach (var item in plItems)
                    {
                        planet.Items.Remove(item);
                    }

                }
            }
        }
    }
}
