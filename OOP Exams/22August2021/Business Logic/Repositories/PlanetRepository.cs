using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Repositories
{
    using Repositories.Contracts;
    using Models.Planets.Contracts;
    using System.Linq;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models;
        public IReadOnlyCollection<IPlanet> Models => models;

        public PlanetRepository()
        {
            models = new List<IPlanet>();
        }
        public void Add(IPlanet model)
        {
            models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IPlanet model)
        {
            if (models.Remove(model))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
