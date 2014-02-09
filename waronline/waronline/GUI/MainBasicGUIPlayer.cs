using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using waronline.GameLogic;

namespace waronline.GUI
{
    class MainBasicGUIPlayer : GUIPlayer
    {
        static private int baseY = 600;
        static private int addY = (int)Math.Ceiling((110 + 10) * Constants.scale);
        static private int baseX = 15;
        static private int addX = (int)Math.Ceiling((75 + 5) * Constants.scale);

        private int cardPosition = 0;

        public override Vector2 GivePlayerCard(string key)
        {
            int level = cardPosition/7;
            Vector2 newPosition = new Vector2(baseX + level * (int) Math.Ceiling((75 + 5) * Constants.scale) / 2 + (cardPosition % 7) * addX, baseY + level * addY);
            cardPosition++;
            base.addKey(key);
            return newPosition;
        }
    }
}
