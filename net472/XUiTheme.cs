using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using XUi.MarkupExtensions;

namespace XUi
{
    /// <summary>
    /// Theme enumeration to know which theme is loaded
    /// </summary>
    public enum Theme
    {
        /// <summary>
        /// Light theme
        /// </summary>
        Light = 1,
        /// <summary>
        /// Dark theme
        /// </summary>
        Dark = 2,
    }

    /// <summary>
    /// XUiTheme of the application
    /// </summary>
    public static class XUiTheme
    {
        /// <summary>
        /// Dictionary of the <see cref="XUiTheme"/>, contain all the resources
        /// </summary>
        public static ResourceDictionary XUiDictionaries;

        /// <summary>
        /// Get the current theme of XUi
        /// </summary>
        public static Theme CurrentTheme => _currentTheme;

        private static Theme _currentTheme = Theme.Light;

        /// <summary>
        /// Initialize the <see cref="XUiTheme.XUiDictionaries"/>
        /// </summary>
        public static void Initialize()
        {
            ResourceDictionary xuiGeneric = new ResourceDictionary  {
                Source = new Uri("pack://application:,,,/XUi;component/Styles/Generic.xaml", UriKind.RelativeOrAbsolute)
            };

            // Load it into memory
            XUiDictionaries = xuiGeneric;
        }

        /// <summary>
        /// Change all the colors to the black mode
        /// </summary>
        public static void EnableDarkMode()
        {
            // Redefine all the colors
            XUiDictionaries["ThemeColor"] = XUiDictionaries["BlackThemeColor"];
            XUiDictionaries["FlatBaseColor"] = XUiDictionaries["FlatBaseBlackThemeColor"];
            XUiDictionaries["FlatOverColor"] = XUiDictionaries["FlatOverBlackThemeColor"];
            XUiDictionaries["FlatPressColor"] = XUiDictionaries["FlatPressBlackThemeColor"];
            XUiDictionaries["FlatScrollOverColor"] = XUiDictionaries["FlatScrollOverBlackThemeColor"];
            XUiDictionaries["FlatScrollPressColor"] = XUiDictionaries["FlatScrollPressBlackThemeColor"];
            XUiDictionaries["FlatContextMenuColor"] = XUiDictionaries["FlatContextMenuBlackThemeColor"];
            XUiDictionaries["FontColor"] = XUiDictionaries["WhiteFontColor"];

            // Redefine all the brushes
            XUiDictionaries["ThemeBrush"] = XUiDictionaries["BlackThemeBrush"];
            XUiDictionaries["FlatBaseBrush"] = XUiDictionaries["FlatBaseBlackThemeBrush"];
            XUiDictionaries["FlatOverBrush"] = XUiDictionaries["FlatOverBlackThemeBrush"];
            XUiDictionaries["FlatPressBrush"] = XUiDictionaries["FlatPressBlackThemeBrush"];
            XUiDictionaries["FlatScrollOverBrush"] = XUiDictionaries["FlatScrollOverBlackThemeBrush"];
            XUiDictionaries["FlatScrollPressBrush"] = XUiDictionaries["FlatScrollPressBlackThemeBrush"];
            XUiDictionaries["FlatContextMenuBrush"] = XUiDictionaries["FlatContextMenuBlackThemeBrush"];
            XUiDictionaries["FontBrush"] = XUiDictionaries["WhiteFontBrush"];

            _currentTheme = Theme.Dark;
            AppThemeBinding.OnThemeChanged();
        }

        /// <summary>
        /// Change all the colors to the light mode
        /// </summary>
        public static void EnableLightMode()
        {
            // Redefine all the colors
            XUiDictionaries["ThemeColor"] = XUiDictionaries["WhiteThemeColor"];
            XUiDictionaries["FlatBaseColor"] = XUiDictionaries["FlatBaseWhiteThemeColor"];
            XUiDictionaries["FlatOverColor"] = XUiDictionaries["FlatOverWhiteThemeColor"];
            XUiDictionaries["FlatPressColor"] = XUiDictionaries["FlatPressWhiteThemeColor"];
            XUiDictionaries["FlatScrollOverColor"] = XUiDictionaries["FlatScrollOverWhiteThemeColor"];
            XUiDictionaries["FlatScrollPressColor"] = XUiDictionaries["FlatScrollPressWhiteThemeColor"];
            XUiDictionaries["FlatContextMenuColor"] = XUiDictionaries["FlatContextMenuWhiteThemeColor"];
            XUiDictionaries["FontColor"] = XUiDictionaries["BlackFontColor"];

            // Redefine all the brushes
            XUiDictionaries["ThemeBrush"] = XUiDictionaries["WhiteThemeBrush"];
            XUiDictionaries["FlatBaseBrush"] = XUiDictionaries["FlatBaseWhiteThemeBrush"];
            XUiDictionaries["FlatOverBrush"] = XUiDictionaries["FlatOverWhiteThemeBrush"];
            XUiDictionaries["FlatPressBrush"] = XUiDictionaries["FlatPressWhiteThemeBrush"];
            XUiDictionaries["FlatScrollOverBrush"] = XUiDictionaries["FlatScrollOverWhiteThemeBrush"];
            XUiDictionaries["FlatScrollPressBrush"] = XUiDictionaries["FlatScrollPressWhiteThemeBrush"];
            XUiDictionaries["FlatContextMenuBrush"] = XUiDictionaries["FlatContextMenuWhiteThemeBrush"];
            XUiDictionaries["FontBrush"] = XUiDictionaries["BlackFontBrush"];

            _currentTheme = Theme.Light;
            AppThemeBinding.OnThemeChanged();
        }
    }
}
