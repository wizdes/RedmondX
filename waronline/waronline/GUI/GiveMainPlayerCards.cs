using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace waronline.GUI
{
    class GiveMainPlayerCards : GameTemplate
    {
        private List<DrawnCard> cardTextureList;
        private MainBasicGUIPlayer mainPlayer;

        public GiveMainPlayerCards(List<DrawnCard> cardTextureList)
        {
            this.cardTextureList = cardTextureList;
            mainPlayer = new MainBasicGUIPlayer();
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
                }
                else
                {
                    card.IsVisible = false;
                    card.move((int) -100, (int) -100);
                }
                i++;
            }
        }

        public void applyOnTouch(Vector2 position)
        {
            CommonFunctions.removeCardAtPosition(cardTextureList, position);
        }
    }
}
