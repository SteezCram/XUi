using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace XUi.MarkupExtensions
{
    /// <summary>
    /// Get a resource depending on the theme loaded
    /// </summary>
    public class AppThemeBinding : MarkupExtension, IEventListener
    {
        /// <summary>
        /// Light property to use
        /// </summary>
        public string Light { get; set; }
        /// <summary>
        /// Dark property to use
        /// </summary>
        public string Dark { get; set; }

        private static readonly List<IEventListener> _appThemeBindingListners = new List<IEventListener>();
        private FrameworkElement _targetObject;
        private PropertyInfo _targetProperty;

        #region Public Methods

        /// <summary>
        /// Provide the value for the binding, add a listener to update the value in background
        /// </summary>
        /// 
        /// <param name="serviceProvider"></param>
        /// 
        /// <returns>
        /// Value to use
        /// </returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            // Throw an exception
            if (string.IsNullOrWhiteSpace(Light) || string.IsNullOrWhiteSpace(Dark))
                throw new InvalidOperationException("Inputs cannot be blank");

            // Get the target object and property
            IProvideValueTarget service = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
            _targetObject = service.TargetObject as FrameworkElement;
            DependencyProperty dependencyProperty = service.TargetProperty as DependencyProperty;
            _targetProperty = _targetObject.GetType().GetProperty(dependencyProperty.Name);

            // Add the listener
            _appThemeBindingListners.Add(this);
            return GetResource();
        }

        /// <summary>
        /// Make the change to the property
        /// </summary>
        public void InformThemeChanged()
        {
            // Set the new resource
            object resource = GetResource();
            _targetProperty.SetValue(_targetObject, resource, null);
        }


        /// <summary>
        /// Trigger when the theme has changed
        /// </summary>
        public static void OnThemeChanged()
        {
            foreach (var it in _appThemeBindingListners.ToArray())
            {
                it.InformThemeChanged();
            }
        }


        #endregion

        #region Private Methods

        /// <summary>
        /// Get the resource
        /// </summary>
        /// 
        /// <returns>
        /// Resource to set
        /// </returns>
        private object GetResource()
        {
            if (XUiTheme.CurrentTheme == Theme.Light)
                return XUiTheme.XUiDictionaries[Light];

            return XUiTheme.XUiDictionaries[Dark];
        }

        #endregion
    }
}
