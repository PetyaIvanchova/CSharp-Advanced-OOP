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
        public IReadOnlyCollection<IRace> Models =>models.AsReadOnly();

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
            var sth = models.FirstOrDefault(x => x.RaceName == name);
            if (sth != null)
            {
                return sth;
            }
            else
            {
                return null;
            }
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
