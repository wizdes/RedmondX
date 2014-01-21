using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Xna.Framework.Graphics;

namespace gamedemo
{
    class DrawnCard
    {
        private int x;
        private int y;
        private Texture2D reference;
        private bool isVisible;
        private bool isMoving;

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public Texture2D Reference
        {
            get { return reference; }
        }

        public DrawnCard(Texture2D reference)
        {
            this.reference = reference;
            isVisible = false;
            isMoving = false;
            x = 0;
            y = 0;
        }

        public bool IsVisible
        {
            get
            {
                return isVisible;
            }
            set { isVisible = value; }
        }

        public bool IsMoving
        {
            get
            {
                return isMoving;
            }
            set { isMoving = value; }
        }

        public void move(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
