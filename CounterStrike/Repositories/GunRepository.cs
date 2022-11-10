using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private List<IGun> models;

        public GunRepository()
        {
            models = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models
        {
            get
            {
                return models.AsReadOnly();
            }
        }

        public void Add(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Gun Repository");
            }
            models.Add(model);
        }

        public IGun FindByName(string name)
        {
            IGun model = models.FirstOrDefault(x => x.Name == name);
            return model;
        }

        public bool Remove(IGun model)
        {
            return models.Remove(model);
        }
    }
}
