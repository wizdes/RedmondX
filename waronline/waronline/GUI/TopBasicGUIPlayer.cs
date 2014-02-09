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
        static private int baseY = 5;
        static private int addX = (int)Math.Ceiling((30 + 10) * Constants.scale);
        static private int baseX = 15;

        private int cardPosition = 0;

        public override Vector2 GivePlayerCard(string key)
        {
            base.addKey(key);
            return new Vector2(baseX + cardPosition++ * addX, baseY);
        }
    }
}
