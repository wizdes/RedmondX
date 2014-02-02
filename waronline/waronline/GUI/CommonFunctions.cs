using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace waronline.GUI
{
    class CommonFunctions
    {
        internal static void removeCardAtPosition(List<DrawnCard> cardTextureList, Vector2 position)
        {
            DrawnCard cardToRemove = null;
            foreach (DrawnCard card in cardTextureList)
            {
                if (card.containsPosition(position))
                {
                    cardToRemove = card;
                }
            }
            if (cardToRemove != null)
            {
                cardToRemove.IsVisible = false;
                cardToRemove.move(-100, -100);
            }
        }
    }
}
