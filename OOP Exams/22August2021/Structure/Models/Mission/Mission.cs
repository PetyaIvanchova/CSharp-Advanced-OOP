using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Mission
{
    using Models.Mission.Contracts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Planets.Contracts;
    using System.Linq;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var ast in astronauts)
            {
                if (ast.Oxygen>0)
                {

                    var itemFound = planet.Items.FirstOrDefault();
                    if (itemFound != null)
                    {
                        ast.Bag.Items.Add(itemFound);
                        ast.Breath();
                        planet.Items.Remove(itemFound);
                    }
                    if (planet.Items.Count == 0) break;

                }
            }
        }
    }
}
