using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace XUi.UI
{
    public class AnimationManager
    {
        #region Transition

        public enum TransitionType
        {
            PageZoom
        }

        /// <summary>
        /// Load a transition with the "open" type
        /// </summary>
        /// 
        /// <param name="element">Element to apply the transition</param>
        /// <param name="transitionType">Transition type to apply</param>
        public static async Task LoadTransitionOpen(FrameworkElement element, TransitionType transitionType)
        {
            // Start the transition storyboard
            Storyboard storyboard = XUiTheme.XUiDictionnaries[$"XUi_Transition{transitionType.ToString()}Open"] as Storyboard;
            storyboard.Begin(element);
            await Task.Delay(300);
        }

        /// <summary>
        /// Load a transition with the "close" type
        /// </summary>
        /// 
        /// <param name="element">Element to apply the transition</param>
        /// <param name="transitionType">Transition type to apply</param>
        public static async Task LoadTransitionClose(FrameworkElement element, TransitionType transitionType)
        {
            // Start the transition storyboard
            Storyboard storyboard = XUiTheme.XUiDictionnaries[$"XUi_Transition{transitionType.ToString()}Close"] as Storyboard;
            storyboard.Begin(element);
            await Task.Delay(150);
        }

        #endregion

        public enum AnimationType
        {
            Fade,
            ExpandHeight,
            ExpandWidth,
            Rotate,
        }

        public static async Task LoadAnimation(FrameworkElement element, AnimationType animationType, double fromValue = 0, double toValue = 1, int animationTime = 150)
        {
            // Get the storyboard
            Storyboard storyboard = XUiTheme.XUiDictionnaries[$"XUi_Animation{animationType.ToString()}"] as Storyboard;
            DoubleAnimationUsingKeyFrames animationKeyFrames = ((DoubleAnimationUsingKeyFrames)storyboard.Children[0]);

            // Get the start key frame
            EasingDoubleKeyFrame startKeyFrame = ((EasingDoubleKeyFrame)animationKeyFrames.KeyFrames[0]);
            startKeyFrame.Value = fromValue;
            // Get the end key frame
            EasingDoubleKeyFrame endKeyFrame = ((EasingDoubleKeyFrame)animationKeyFrames.KeyFrames[1]);
            endKeyFrame.Value = toValue;
            endKeyFrame.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(animationTime));

            // Apply the storyboard
            storyboard.Begin(element);
            await Task.Delay(animationTime);
        }
    }
}
