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
        static private double animationLengthMilliseconds = 75;
        private SpriteMovable animatingObject;

        public MoveAnimation(SpriteMovable obj, Point startPoint, Point endPoint)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            startTime = DateTime.Now;
            endTime = DateTime.Now + new TimeSpan(0, 0, 0, 0, (int)animationLengthMilliseconds);
            isAnimationOver = false;
            animatingObject = obj;
        }

        private double calculateProportionMilliseconds(DateTime startTime, DateTime endTime, DateTime currentTime)
        {
            TimeSpan total = endTime - startTime;
            TimeSpan elapsed = currentTime - startTime;
            return ((elapsed - total).Milliseconds) * 1.0 / total.Milliseconds;
        }

        public Point GetCurrentPoint()
        {
            DateTime currentTime = DateTime.Now;
            double proportion = calculateProportionMilliseconds(startTime, endTime, currentTime);

            if (proportion >= 1)
            {
                isAnimationOver = true;
                return endPoint;
            }

            if (proportion < 0)
            {
                proportion = 0;
            }

            return new Point(
                startPoint.X + proportion * (endPoint.X - startPoint.X),
                startPoint.Y + proportion * (endPoint.Y - startPoint.Y));
        }

        public override void DoAnimation()
        {
            Point currentPoint = GetCurrentPoint();
            animatingObject.x = (int) currentPoint.X;
            animatingObject.y = (int) currentPoint.Y;
        }
    }
}
