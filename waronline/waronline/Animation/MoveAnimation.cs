using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace waronline.Animation
{
    class MoveAnimation : BaseAnimation
    {
        private DateTime startTime;
        private Point startPoint;
        private Point endPoint;
        private DateTime endTime;
        static private double animationLengthMilliseconds = 500;

        public MoveAnimation(Point startPoint, Point endPoint)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            startTime = DateTime.Now;
            endTime = DateTime.Now + new TimeSpan(0, 0, 0, 0, (int)animationLengthMilliseconds);
        }
    }
}
