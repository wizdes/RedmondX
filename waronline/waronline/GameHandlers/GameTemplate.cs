using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace waronline.GUI
{
    interface GameTemplate
    {
        void initCards();

        void updateState();

        void applyOnTouch(Vector2 position);
    }
}
