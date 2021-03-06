﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using waronline.GameLogic;

namespace waronline
{
    public class SpriteMovable
    {
        internal int x;
        internal int y;
    }


    class DrawnCard : SpriteMovable
    {
        private int x_size = 75;
        private int y_size = 110;
        private Texture2D reference;
        private Texture2D backReference;
        private bool isVisible;
        private bool isMoving;
        private bool isShowingCardFront;
        public string cardName;

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
            get
            {
                if (isShowingCardFront)
                {
                    return reference;
                }
                return backReference;
            }
        }

        public bool containsPosition(Vector2 position){
            if (position.X > x && position.X < x + x_size * Constants.scale &&
                position.Y > y && position.Y < y + y_size * Constants.scale)
            {
                return true;
            }

            return false;
        }

        public DrawnCard(Texture2D reference, Texture2D backReference, string cardName)
        {
            this.reference = reference;
            this.cardName = cardName;
            this.backReference = backReference;
            isVisible = false;
            isMoving = false;
            isShowingCardFront = false;
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

        public bool IsShowingCardFront
        {
            get { return isShowingCardFront; }
            set { isShowingCardFront = value; }

        }

        public void move(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool isA(string cardName)
        {
            if (cardName.Equals(this.cardName))
            {
                return true;
            }

            return false;
        }
    }
}
