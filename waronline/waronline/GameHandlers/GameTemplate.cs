using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace waronline.GUI
{
    abstract class GameTemplate
    {
        protected List<DrawnCard> cardTextureList;

        public abstract void initCards();

        public abstract void updateState();

        public abstract void applyOnTouch(Vector2 position);

        public virtual void draw(SpriteBatch _spriteBatch)
        {
            foreach (DrawnCard card in cardTextureList)
            {
                if (card.IsVisible)
                {
                    _spriteBatch.Draw(card.Reference, new Vector2(card.X, card.Y), null, Color.White, 0, Vector2.Zero, Constants.scale, SpriteEffects.None, 0.0f);
                }
            }            
        }
    }
}
