using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace waronline.Animation
{
    internal class DynamicStoryboard
    {
        static private DynamicStoryboard staticDynamicStoryboard = null;

        private static List<BaseAnimation> animations;

        private DynamicStoryboard()
        {
            animations = new List<BaseAnimation>();
        }

        public void AddAnimation(BaseAnimation ba)
        {
            animations.Add(ba);
        }

        public void AddAnimationTo(BaseAnimation origin, BaseAnimation next)
        {
            animations.First(animation => animation.Equals(origin)).AddNextAnimation(next);
        }

        public static DynamicStoryboard getInstance()
        {
            return staticDynamicStoryboard ?? (staticDynamicStoryboard = new DynamicStoryboard());
        }
    }
}
