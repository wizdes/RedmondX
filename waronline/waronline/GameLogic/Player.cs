using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace waronline.GameLogic
{
    public enum PlayerType
    {
        Device,
        Network,
        Artificial
    }

    public class Player
    {
        public Player()
        {
            this.Hand = new List<Card>();
        }

        public string Username { get; set; }

        public PlayerType PlayerType { get; set; }

        public List<Card> Hand { get; private set; }

        // <summary>
        // The place that the player is sitting.
        // </summary>
        public int PlayerNumber { get; set; }
    }
}
