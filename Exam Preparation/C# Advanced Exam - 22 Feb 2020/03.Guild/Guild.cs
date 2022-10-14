using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roaster;

        public Guild(string name, int capacity)
        {
            this.roaster = new List<Player>();
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.roaster.Count; } }

        public void AddPlayer(Player player)
        {
            if (roaster.Count < this.Capacity)
            {
                roaster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            if (this.roaster.Any(p => p.Name == name))
            {
                this.roaster.Remove(this.roaster.First(p => p.Name == name));
                return true;
            }
            return false;
        }
        public void PromotePlayer(string name)
        {
            if (this.roaster.Any(p => p.Name == name))
            {
                Player player = this.roaster.First(p => p.Name == name);
                if (player.Rank == "Member") return;

                player.Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            if (this.roaster.Any(p => p.Name == name))
            {
                Player player = this.roaster.First(p => p.Name == name);
                if (player.Rank == "Trial") return;

                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            Player[] playerList = this.roaster.Where(p => p.Class == @class).ToArray();
            this.roaster.RemoveAll(p => p.Class == @class);

            return playerList;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in this.roaster)
            {
                sb.AppendLine($"{player.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
