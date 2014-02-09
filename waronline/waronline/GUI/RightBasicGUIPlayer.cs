using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace waronline.GUI
{
    class RightBasicGUIPlayer : GUIPlayer
    {
        static private int baseY = (int)((110 + 20) * Constants.scale);
        static private int addY = (int)Math.Ceiling((30 + 10) * Constants.scale);
        static private int baseX = 415;

        private int cardPosition = 0;

        public override Vector2 GivePlayerCard(string key)
        {
            base.addKey(key);
            return new Vector2(baseX, baseY + cardPosition++ * addY);
        }
    }
}
