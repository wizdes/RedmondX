using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace waronline
{
    class CommonFunctions
    {
        internal static DrawnCard moveCardToCenter(List<DrawnCard> cardTextureList, string cardName, int cardsInCenter)
        {
            DrawnCard cardToRemove = null;
            foreach (DrawnCard card in cardTextureList)
            {
                if (card.isA(cardName))
                {
                    cardToRemove = card;
                }
            }
            if (cardToRemove != null)
            {
                cardToRemove.IsVisible = true;
                cardToRemove.IsShowingCardFront = true;
                cardToRemove.move(100 + cardsInCenter * 80, 300);
            }

            return cardToRemove;
        }

        internal static DrawnCard moveCardToCenter(List<DrawnCard> cardTextureList, Vector2 position, int cardsInCenter)
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
                cardToRemove.IsVisible = true;
                cardToRemove.IsShowingCardFront = true;
                cardToRemove.move(100 + cardsInCenter*80, 300);
            }

            return cardToRemove;
        }

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

        public static DrawnCard GetCardByPosition(List<DrawnCard> cardTextureList, Vector2 position)
        {
            DrawnCard cardByName = null;
            foreach (DrawnCard card in cardTextureList)
            {
                if (card.containsPosition(position))
                {
                    cardByName = card;
                }
            }
            return cardByName;
        }

        public static void removeCard(DrawnCard card)
        {
            card.IsVisible = false;
            card.move(-100, -100);
        }

        public static DrawnCard GetCardByCardName(List<DrawnCard> cardTextureList,string drawnCard)
        {
            DrawnCard cardToRemove = null;
            foreach (DrawnCard card in cardTextureList)
            {
                if (card.isA(drawnCard))
                {
                    cardToRemove = card;
                }
            }
            return cardToRemove;
        }        
    }
}
