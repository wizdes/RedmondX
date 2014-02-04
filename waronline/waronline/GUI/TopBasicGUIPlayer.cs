using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace waronline.GUI
{
    class TopBasicGUIPlayer : GUIPlayer
    {
        private int baseY = 5;
        private int addX = (int)Math.Ceiling((30 + 10) * Constants.scale);
        private int baseX = 15;

        private int cardPosition = 0;

        public Vector2 GivePlayerCard(string key)
        {
            return new Vector2(baseX + cardPosition++ * addX, baseY);
        }

        public void removeCard(string key)
        {
            return;
        }

    }
}
