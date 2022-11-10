using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        private List<IPlayer> terrorist;
        private List<IPlayer> counterTerrorist;

        public Map()
        {
            terrorist = new List<IPlayer>();
            counterTerrorist = new List<IPlayer>();
        }

        public string Start(ICollection<IPlayer> players)
        {
            SeparateTeams(players);

            while (IsTeamAlive(terrorist) && IsTeamAlive(counterTerrorist))
            {
                AttackTeam(terrorist, counterTerrorist);
                AttackTeam(counterTerrorist, terrorist);
                if (!IsTeamAlive(terrorist))
                {
                    return "Counter Terrorist wins!";
                }
                if (!IsTeamAlive(counterTerrorist))
                {
                    return "Terrorist wins!";
                }
            }
            return "";
        }

        private bool IsTeamAlive(List<IPlayer> players)
        {
            return players.Any(x => x.IsAlive);
        }

        private void AttackTeam(List<IPlayer> attacking, List<IPlayer> defending)
        {
            foreach (var attacker in attacking)
            {
                //if (!attacker.IsAlive)
                //{
                //    continue;
                //}
                foreach (var defender in defending)
                {
                    if (defender.IsAlive)
                    {
                        defender.TakeDamage(attacker.Gun.Fire());
                    }
                }
            }
        }

        private void SeparateTeams(ICollection<IPlayer> players)
        {
            foreach (var player in players)
            {
                if (player is CounterTerrorist)
                {
                    counterTerrorist.Add(player);
                }
                else if (player is Terrorist)
                {
                    terrorist.Add(player);
                }
            }
        }
    }
}
