using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MES.Easing;
using MES.Animators;

namespace MES
{
    public static class AnimationExtensions
    {
        public static AnimationStatus Animate( this Control control, IEffect iAnimation,
            EasingDelegate easing, int valueToReach, int duration, int delay, bool reverse = false, int loops = 1 )
        {
            return Animator.Animate( control, iAnimation, easing, valueToReach, duration, delay, reverse, loops );
        }
    }
}
