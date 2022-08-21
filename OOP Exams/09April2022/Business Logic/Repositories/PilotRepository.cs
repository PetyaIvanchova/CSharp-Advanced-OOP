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
        public IReadOnlyCollection<IPilot> Models => models;
        public PilotRepository()
        {
            models = new List<IPilot>();
        }
        public void Add(IPilot model)
        {
            models.Add(model);
        }

        public IPilot FindByName(string name)
        {
            return  models.FirstOrDefault(x => x.FullName == name);
           
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
