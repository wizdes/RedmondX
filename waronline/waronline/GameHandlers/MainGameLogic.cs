using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using waronline.GameLogic;

namespace waronline.GUI
{
    class MainGameLogic : GameTemplate
    {
        private List<DrawnCard> cardTextureList;
        private GUIPlayer mainPlayer;
        private GUIPlayer leftPlayer;
        private GUIPlayer rightPlayer;
        private GUIPlayer topPlayer;

        private List<GUIPlayer> guiPlayers;

        private GameLogic.HeartsLogic coreLogic;

        public MainGameLogic(List<DrawnCard> cardTextureList)
        {
            this.cardTextureList = cardTextureList;
        }

        public void initCards()
        {
            guiPlayers = new List<GUIPlayer>();
            mainPlayer = new MainBasicGUIPlayer();
            leftPlayer = new LeftBasicGUIPlayer();
            rightPlayer = new RightBasicGUIPlayer();
            topPlayer = new TopBasicGUIPlayer();
            guiPlayers.Add(mainPlayer);
            guiPlayers.Add(leftPlayer);
            guiPlayers.Add(rightPlayer);
            guiPlayers.Add(topPlayer);
            coreLogic = GameLogic.HeartsLogic.Instance;
            int cardsInMiddle = 0;
            foreach (Card card in coreLogic.CardsInPlay)
            {
                //CommonFunctions.moveCardToCenter(cardTextureList, card.ToString(), cardsInMiddle++);
            }

            int i = 0;

            foreach (Player p in coreLogic.Players)
            {
                GUIPlayer guiplayer = guiPlayers.ElementAt(i);
                foreach (Card c in p.Hand)
                {
                    DrawnCard guiCard = CommonFunctions.GetCardByCardName(this.cardTextureList, c.ToString());
                    Vector2 cardPosition = guiplayer.GivePlayerCard(c.ToString());
                    guiCard.move((int)cardPosition.X, (int)cardPosition.Y);
                    guiCard.IsShowingCardFront = true;
                    guiCard.IsVisible = true;
                }
                i++;
                
            }
        }

        public void updateState()
        {
            initCards();
        }

        public void applyOnTouch(Vector2 position)
        {
            coreLogic.HandleCardPlay(CommonFunctions.GetCardByPosition(cardTextureList, position).cardName);
        }
    }
}
