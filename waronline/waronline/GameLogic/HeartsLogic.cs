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
        private IOrderedEnumerable<Player> players;
        private Deck deck;
        private List<Card> cardsInPlay;
        private int nonce;
        private Player currentPlayer;

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

        public IOrderedEnumerable<Player> Players
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

        public void HandleCardPlay(string cardString)
        {
            this.HandleCardPlay(Deck.GetCardFromString(cardString));
        }

        private void HandleCardPlay(Card card)
        {
            if (currentPlayer.Hand.Contains(card))
            {
                currentPlayer.Hand.Remove(card);
                cardsInPlay.Add(card);
                nonce++;
            }
        }

        // <summary>
        // Resets the game to its initial state.
        // </summary>
        public override void Initialize()
        {
            currentPhase = Phase.Trading;
            tradeDirection = TradingDirection.Left;
            this.deck = new Deck();

            // Remove once we are done testing
            this.MockPlayers();
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

            this.currentPlayer = this.players.Where(x => x.PlayerType == PlayerType.Device).Single();
        }

        public void SetPlayers(List<Player> listOfPlayers)
        {
            this.players = listOfPlayers.OrderBy(x => x.PlayerNumber);
        }

        private void MockPlayers()
        {
            List<Player> listOfPlayers = new List<Player>();
            listOfPlayers.Add(new Player() { PlayerType = PlayerType.Device, PlayerNumber = 0 });
            listOfPlayers.Add(new Player() { PlayerType = PlayerType.Network, PlayerNumber = 1 });
            listOfPlayers.Add(new Player() { PlayerType = PlayerType.Network, PlayerNumber = 2 });
            listOfPlayers.Add(new Player() { PlayerType = PlayerType.Network, PlayerNumber = 3 });

            this.players = listOfPlayers.OrderBy(x => x.PlayerNumber);
        }
    }
}
