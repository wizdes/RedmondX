using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace waronline.GUI
{
    interface GUIPlayer
    {
        Vector2 GivePlayerCard(string key);

        void removeCard(string key);
    }
}
