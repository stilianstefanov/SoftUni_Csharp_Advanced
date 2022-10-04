using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        public Team(string name, int openPositions, char group)
        {            
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            this.Players = new List<Player>();
        }

        public List<Player> Players { get; set; }
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public int Count { get { return this.Players.Count; } }

        public string AddPlayer(Player player)
        {
            if (player.Name == null || player.Name == string.Empty 
                || player.Position == null || player.Position == string.Empty)
            {
                return "Invalid player's information.";
            }
            else if (this.OpenPositions == 0)
            {
                return "There are no more open positions.";
            }
            else if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }
            else
            {
                this.Players.Add(player);
                this.OpenPositions--;
                return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";
            }
        }
        public bool RemovePlayer(string name)
        {
            if (!this.Players.Any(p => p.Name == name))
            {
                return false;
            }
            else
            {
                this.Players.Remove(this.Players.Find(p => p.Name == name));
                this.OpenPositions++;

                return true;
            }
        }

        public int RemovePlayerByPosition(string position)
        {
            int count = 0;

            for (int i = 0; i < this.Players.Count; i++)
            {
                if (this.Players[i].Position == position)
                {
                    this.Players.Remove(Players[i]);
                    count++;
                    this.OpenPositions++;
                    i--;
                }
            }

            return count;
        }

        public Player RetirePlayer(string name)
        {
            if (!this.Players.Any(p => p.Name == name))
            {
                return null;
            }
            else
            {
                Player player = this.Players.Find(p => p.Name == name);
                player.Retired = true;

                return player;
            }
        }

        public List<Player> AwardPlayers(int games)
        {
            List<Player> list = this.Players.Where(p => p.Games >= games).ToList();
            
            return list;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {this.Name} from Group {this.Group}:");
            foreach (var player in this.Players)
            {
                if (player.Retired == false)
                {
                    sb.AppendLine(player.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
