using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace waronline.GUI
{
    class GivePlayersCards : GameTemplate
    {
        private List<DrawnCard> cardTextureList;
        private GUIPlayer mainPlayer;
        private GUIPlayer leftPlayer;
        private GUIPlayer rightPlayer;
        private GUIPlayer topPlayer;

        public GivePlayersCards(List<DrawnCard> cardTextureList)
        {
            this.cardTextureList = cardTextureList;
            mainPlayer  = new MainBasicGUIPlayer();
            leftPlayer  = new LeftBasicGUIPlayer();
            rightPlayer = new RightBasicGUIPlayer();
            topPlayer   = new TopBasicGUIPlayer();

        }
        public void initCards()
        {
            Random r = new Random();
            int i = 0;
            foreach (DrawnCard card in cardTextureList)
            {
                if (i < 13)
                {
                    card.IsVisible = true;
                    Vector2 position = mainPlayer.GivePlayerCard(card.ToString());
                    card.move((int) position.X, (int) position.Y);
                    card.IsShowingCardFront = true;
                }
                else if(i < 26)
                {
                    card.IsVisible = true;
                    Vector2 position = leftPlayer.GivePlayerCard(card.ToString());
                    card.move((int)position.X, (int)position.Y);
                    card.IsShowingCardFront = false;
                }
                else if (i < 39)
                {
                    card.IsVisible = true;
                    Vector2 position = rightPlayer.GivePlayerCard(card.ToString());
                    card.move((int)position.X, (int)position.Y);
                    card.IsShowingCardFront = false;
                }
                else
                {
                    card.IsVisible = true;
                    Vector2 position = topPlayer.GivePlayerCard(card.ToString());
                    card.move((int)position.X, (int)position.Y);
                    card.IsShowingCardFront = false;
                }
                i++;
            }
        }

        public void updateState()
        {
            return;
        }

        public void applyOnTouch(Vector2 position)
        {
            CommonFunctions.removeCardAtPosition(cardTextureList, position);
        }
    }
}
