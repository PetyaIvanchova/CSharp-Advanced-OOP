using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Repositories
{
    using Repositories.Contracts;
    using Models.Astronauts.Contracts;
    using System.Linq;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        public IReadOnlyCollection<IAstronaut> Models => models.AsReadOnly();
        private List<IAstronaut> models;
        public void Add(IAstronaut model)
        {
            models.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            IAstronaut ast = models.FirstOrDefault(x => x.Name == name);
            if (ast!=null)
            {
                return ast;
            }
            else
            {
                return null;
            }
        }

        public bool Remove(IAstronaut model)
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
