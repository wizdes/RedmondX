using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace waronline.GUI
{
    abstract class GUIPlayer
    {

        internal List<string> cards;

        public GUIPlayer()
        {
            cards = new List<string>();
        }

        public abstract Vector2 GivePlayerCard(string key);

        protected void addKey(string key)
        {
            this.cards.Add(key);
        }

        virtual public void removeCard(string key)
        {
            this.cards.Remove(key);
        }
    }
}
