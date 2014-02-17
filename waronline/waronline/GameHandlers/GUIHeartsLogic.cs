using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using waronline.Animation;
using waronline.GameLogic;
using Point = System.Windows.Point;

namespace waronline.GUI
{
    class MainGameLogic : GameTemplate
    {
        private GUIPlayer mainPlayer;
        private GUIPlayer leftPlayer;
        private GUIPlayer rightPlayer;
        private GUIPlayer topPlayer;

        private List<GUIPlayer> guiPlayers;

        private GameLogic.HeartsLogic coreLogic;
        private Dictionary<string, DrawnCard> cardTextureMap;

        private List<string> centerCardList; 

        public MainGameLogic(List<DrawnCard> cardTextureList, Dictionary<string, DrawnCard> cardTextureMap)
        {
            this.centerCardList = new List<string>();
            this.cardTextureList = cardTextureList;
            this.cardTextureMap = cardTextureMap;
        }

        public override void initCards()
        {
            coreLogic = GameLogic.HeartsLogic.Instance;
            updateState();
        }

        public override void updateState()
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
            int cardsInMiddle = 0;

            int i = 0;

            // handle the animation 
            foreach (BaseAnimation animation in DynamicStoryboard.getInstance().StoryboardAnimations)
            {
                animation.DoAnimation();
            }

            DynamicStoryboard.getInstance()
                .StoryboardAnimations.RemoveAll(animation => animation.isAnimationOver == true);

            foreach (Player p in coreLogic.Players)
            {
                GUIPlayer guiplayer = guiPlayers.ElementAt(i);
                foreach (Card c in p.Hand)
                {
                    DrawnCard guiCard = CommonFunctions.GetCardByCardName(this.cardTextureList, c.ToString());
                    Vector2 cardPosition = guiplayer.GivePlayerCard(c.ToString());
                    guiCard.move((int)cardPosition.X, (int)cardPosition.Y);
                    guiCard.IsShowingCardFront = false;
                    guiCard.IsVisible = true;

                    // the main player will show the card's front
                    if (i == 0)
                    {
                        guiCard.IsShowingCardFront = true;
                    }
                }

                i++;
            }

            // no cards have been played, you're done
            if (centerCardList.Count == coreLogic.CardsInPlay.Count)
            {
                return;
            }

            //centerCardList.Clear();

            int centerCount = 0;

            // only call this if a card has been played 
            foreach (Card card in coreLogic.CardsInPlay)
            {
                if (centerCount++ < centerCardList.Count)
                {
                    continue;
                }

                DrawnCard GuiCard = CommonFunctions.GetCardByCardName(cardTextureList, card.ToString());
                GuiCard.IsVisible = true;
                GuiCard.IsShowingCardFront = true;
                DynamicStoryboard.getInstance().AddAnimation(
                    new MoveAnimation(
                        GuiCard,
                        new Point(GuiCard.X, GuiCard.Y),
                        CommonFunctions.MoveCardToCenterGetPosition(centerCardList.Count)));
                centerCardList.Add(card.ToString());
            }

            if (coreLogic.CardsInPlay.Count == 4)
            {
                coreLogic.CardsInPlay.Clear();
                foreach (string card in centerCardList)
                {
                    DrawnCard GuiCard = CommonFunctions.GetCardByCardName(cardTextureList, card.ToString());
                    DynamicStoryboard.getInstance().AddAnimation(
                        new MoveAnimation(
                            GuiCard,
                            new Point(GuiCard.X, GuiCard.Y),
                            new Point(-100, -100)));
                }
                centerCardList.Clear();
            }
        }

        public override void applyOnTouch(Vector2 position)
        {
            DrawnCard cardTouched = CommonFunctions.GetCardByPosition(cardTextureList, position);
            if (cardTouched != null)
            {
                coreLogic.HandleCardPlay(cardTouched.cardName);                
            }
        }

        public override void draw(SpriteBatch _spriteBatch)
        {

            foreach (GUIPlayer player in guiPlayers)
            {
                foreach (string cardKey in player.cards)
                {
                    DrawnCard card = cardTextureMap[cardKey];
                    if (card.IsVisible)
                    {
                        _spriteBatch.Draw(card.Reference, new Vector2(card.X, card.Y), null, Color.White, 0, Vector2.Zero, Constants.scale, SpriteEffects.None, 0.0f);
                    }
                }
            }

            foreach (string cardKey in centerCardList)
            {
                DrawnCard card = cardTextureMap[cardKey];
                if (card.IsVisible)
                {
                    _spriteBatch.Draw(card.Reference, new Vector2(card.X, card.Y), null, Color.White, 0, Vector2.Zero, Constants.scale, SpriteEffects.None, 0.0f);
                }                
            }

            //foreach (DrawnCard card in cardTextureList)
            //{
            //    if (card.IsVisible)
            //    {
            //        _spriteBatch.Draw(card.Reference, new Vector2(card.X, card.Y), null, Color.White, 0, Vector2.Zero, Constants.scale, SpriteEffects.None, 0.0f);
            //    }
            //}               
        }
    }
}
