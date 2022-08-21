using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Repositories
{
    using Models.Contracts;
    using Repositories.Contracts;
    using System.Linq;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> models;
        public IReadOnlyCollection<IFormulaOneCar> Models => models.AsReadOnly();
        public FormulaOneCarRepository()
        {
            models = new List<IFormulaOneCar>();
        }
       
        public void Add(IFormulaOneCar model)
        {
            models.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            var sth = models.FirstOrDefault(x => x.Model == name);
            if (sth!=null)
            {
                return sth;
            }
            else
            {
                return null;
            }
            
        }

        public bool Remove(IFormulaOneCar model)
        {
            if (models.Remove(model))
            {
                return true;
            }
            return false;
        }
    }
}
