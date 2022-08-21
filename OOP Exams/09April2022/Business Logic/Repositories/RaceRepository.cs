using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Repositories
{
    using Models.Contracts;
    using Repositories.Contracts;
    using System.Linq;

    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> models;
        public IReadOnlyCollection<IRace> Models =>models;

        public RaceRepository()
        {
            models = new List<IRace>();
        }
        public void Add(IRace model)
        {
            models.Add(model);
        }

        public IRace FindByName(string name)
        {
            return models.FirstOrDefault(x => x.RaceName == name);
            
        }

        public bool Remove(IRace model)
        {
            if (models.Remove(model))
            {
                return true;
            }
            return false;
        }
    }
}
