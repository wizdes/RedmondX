using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using waronline.Data;

namespace waronline.GameLogic
{
    public enum Phase
    {
        Trading,
        Main
    }

    public enum TradingDirection
    {
        Left,
        Right,
        Across
    }

    public class HeartsLogic : GameLogic
    {
        private Phase currentPhase;
        private TradingDirection tradeDirection;
        private List<Player> players;

        public HeartsLogic(List<Player> players)
        {
            currentPhase = Phase.Trading;
            tradeDirection = TradingDirection.Left;
            players = this.players;
        }

        public override void HandleMessage(IMessage message)
        {
            
        }

        // <summary>
        // Resets the game to its initial state.
        // </summary>
        public override void Reset()
        {
            currentPhase = Phase.Trading;
        }
    }
}
