using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Media.Animation;

namespace waronline.Animation
{
    abstract class BaseAnimation
    {
        private BaseAnimation nextAnimation;
        public bool isAnimationOver;
        
        public void AddNextAnimation(BaseAnimation ba)
        {
            nextAnimation = ba;
        }

        public BaseAnimation()
        {
        }

        public abstract void DoAnimation();

    }
}
