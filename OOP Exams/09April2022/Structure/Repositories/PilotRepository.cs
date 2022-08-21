using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Repositories
{
    using Repositories.Contracts;
    using Models.Contracts;
    using System.Linq;

    public class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> models;
        public IReadOnlyCollection<IPilot> Models => models.AsReadOnly();

        public void Add(IPilot model)
        {
            models.Add(model);
        }

        public IPilot FindByName(string name)
        {
            var sth = models.FirstOrDefault(x => x.FullName == name);
            if (sth != null)
            {
                return sth;
            }
            else
            {
                return null;
            }
        }

        public bool Remove(IPilot model)
        {
            if (models.Remove(model))
            {
                return true;
            }
            return false;
        }
    }
}
