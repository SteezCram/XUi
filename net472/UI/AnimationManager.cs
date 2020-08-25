using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace XUi.UI
{
    /// <summary>
    /// Interact with all the animation in XUi
    /// </summary>
    public class AnimationManager
    {
        /// <summary>
        /// Animation for "open" type animation, time in ms
        /// </summary>
        public const int AnimationOpenDuration = 300;
        /// <summary>
        /// Animation for "close" type animation, time in ms
        /// </summary>
        public const int AnimationCloseDuration = 150;


        #region Transition

        /// <summary>
        /// Contain all the transition type
        /// </summary>
        public enum TransitionType
        {
            /// <summary>
            /// Page type transition
            /// </summary>
            PageZoom
        }

        /// <summary>
        /// Load a transition with the "open" type
        /// </summary>
        /// 
        /// <param name="element">Element to apply the transition</param>
        /// <param name="transitionType">Transition type to apply</param>
        /// <param name="transitionTime">Transition time to wait</param>
        public static async Task LoadTransitionOpen(FrameworkElement element, TransitionType transitionType, int transitionTime = AnimationOpenDuration)
        {
            // Start the transition storyboard
            Storyboard storyboard = XUiTheme.XUiDictionaries[$"XUi_Transition{transitionType}Open"] as Storyboard;
            storyboard.Begin(element);
            await Task.Delay(transitionTime);
        }

        /// <summary>
        /// Load a transition with the "close" type
        /// </summary>
        /// 
        /// <param name="element">Element to apply the transition</param>
        /// <param name="transitionType">Transition type to apply</param>
        /// <param name="transitionTime">Transition time to wait</param>
        public static async Task LoadTransitionClose(FrameworkElement element, TransitionType transitionType, int transitionTime = AnimationCloseDuration)
        {
            // Start the transition storyboard
            Storyboard storyboard = XUiTheme.XUiDictionaries[$"XUi_Transition{transitionType}Close"] as Storyboard;
            storyboard.Begin(element);
            await Task.Delay(transitionTime);
        }

        #endregion

        /// <summary>
        /// Contain all the animation type
        /// </summary>
        public enum AnimationType
        {
            /// <summary>
            /// Fade type animation
            /// </summary>
            Fade,

            /// <summary>
            /// Expand height type animation
            /// </summary>
            ExpandHeight,

            /// <summary>
            /// Expand width type animation
            /// </summary>
            ExpandWidth,

            /// <summary>
            /// Rotate type animation
            /// </summary>
            Rotate,
        }

        /// <summary>
        /// Load an animation from the a <see cref="AnimationType"/> enum
        /// </summary>
        /// 
        /// <param name="element">Element to load the animation</param>
        /// <param name="animationType">Animation type, search for an <see cref="Storyboard"/> in the ressource</param>
        /// <param name="fromValue">Start value of the animation</param>
        /// <param name="toValue">End value of the animation</param>
        /// <param name="animationTime">Time of the animation in milliseconds</param>
        /// 
        /// <returns>
        /// </returns>
        public static async Task LoadAnimation(FrameworkElement element, AnimationType animationType, double fromValue = 0, double toValue = 1, int animationTime = 150)
        {
            // Get the storyboard
            Storyboard storyboard = XUiTheme.XUiDictionaries[$"XUi_Animation{animationType.ToString()}"] as Storyboard;
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
