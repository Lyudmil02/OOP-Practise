using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> models;

        public PlayerRepository()
        {
            models = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models
        {
            get
            {
                return models.AsReadOnly();
            }
        }

        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Player Repository");
            }
            models.Add(model);
        }

        public IPlayer FindByName(string name)
        {
            IPlayer model = models.FirstOrDefault(x => x.Username == name);
            return model;
        }

        public bool Remove(IPlayer model)
        {
            return models.Remove(model);
        }
    }
}
