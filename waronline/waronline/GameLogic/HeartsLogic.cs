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
        private Deck deck;
        private List<Card> cardsInPlay;
        private int nonce;

        private static HeartsLogic _instance;

        public HeartsLogic()
        {
            this.Initialize();
        }

        public static HeartsLogic Instance
        {
            get
            {
                return _instance ?? (_instance = new HeartsLogic());
            }
        }

        public List<Player> Players
        {
            get { return this.players; }
        }

        public List<Card> CardsInPlay
        {
            get { return this.cardsInPlay; }
        }

        public int Nonce
        {
            get { return this.nonce; }
        }

        public override void HandleMessage(IMessage message)
        {
            
        }

        public void HandleCardPlay(Card card)
        {

        }

        public void HandleCardPlay(string cardString)
        {
            this.HandleCardPlay(Deck.GetCardFromString(cardString));
        }

        // <summary>
        // Resets the game to its initial state.
        // </summary>
        public override void Initialize()
        {
            currentPhase = Phase.Trading;
            tradeDirection = TradingDirection.Left;
            this.players = new List<Player>();
            this.deck = new Deck();
        }

        public void DealCardsToPlayers()
        {
            foreach (Player player in this.players)
            {
                for (int i = 0; i < 13; i++)
                {
                    player.Hand.Add(this.deck.GetRandomCard());
                }
            }
        }
    }
}
