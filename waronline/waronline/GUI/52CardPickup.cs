using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace waronline.GUI
{
    class _52CardPickup : GameTemplate
    {
        private List<DrawnCard> cardTextureList;

        public _52CardPickup(List<DrawnCard> cardTextureList)
        {
            this.cardTextureList = cardTextureList;
        }

        public void initCards()
        {
            Random r = new Random();
            foreach (DrawnCard card in cardTextureList)
            {
                card.IsVisible = true;
                card.move(r.Next(480), r.Next(800));
            }
        }

        public void applyOnTouch(Vector2 position)
        {
            CommonFunctions.removeCardAtPosition(cardTextureList, position);
        }
    }
}
