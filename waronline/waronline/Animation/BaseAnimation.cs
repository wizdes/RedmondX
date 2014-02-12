using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Media.Animation;

namespace waronline.Animation
{
    class BaseAnimation
    {
        private DoubleAnimation animationSource;

        public BaseAnimation()
        {
            animationSource = new DoubleAnimation();
        }

    }
}
