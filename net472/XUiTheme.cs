using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace XUi
{
    public class XUiTheme
    {
        public static ResourceDictionary XUiDictionnaries;

        /// <summary>
        /// Initialize the <see cref="XUiTheme.XUiDictionnaries"/>
        /// </summary>
        public static void Initialize()
        {
            ResourceDictionary xuiGeneric = new ResourceDictionary  {
                Source = new Uri("pack://application:,,,/XUi;component/Styles/Generic.xaml", UriKind.RelativeOrAbsolute)
            };

            // Load it into memory
            XUiDictionnaries = xuiGeneric;
        }

        /// <summary>
        /// Change all the colors to the black mode
        /// </summary>
        public static void EnableDarkMode()
        {
            // Redefine all the colors
            XUiDictionnaries["ThemeColor"] = XUiDictionnaries["BlackThemeColor"];
            XUiDictionnaries["FlatBaseColor"] = XUiDictionnaries["FlatBaseBlackThemeColor"];
            XUiDictionnaries["FlatOverColor"] = XUiDictionnaries["FlatOverBlackThemeColor"];
            XUiDictionnaries["FlatPressColor"] = XUiDictionnaries["FlatPressBlackThemeColor"];
            XUiDictionnaries["FlatScrollOverColor"] = XUiDictionnaries["FlatScrollOverBlackThemeColor"];
            XUiDictionnaries["FlatScrollPressColor"] = XUiDictionnaries["FlatScrollPressBlackThemeColor"];
            XUiDictionnaries["FontColor"] = XUiDictionnaries["WhiteFontColor"];

            // Redefine all the brushes
            XUiDictionnaries["ThemeBrush"] = XUiDictionnaries["BlackThemeBrush"];
            XUiDictionnaries["FlatBaseBrush"] = XUiDictionnaries["FlatBaseBlackThemeBrush"];
            XUiDictionnaries["FlatOverBrush"] = XUiDictionnaries["FlatOverBlackThemeBrush"];
            XUiDictionnaries["FlatPressBrush"] = XUiDictionnaries["FlatPressBlackThemeBrush"];
            XUiDictionnaries["FlatScrollOverBrush"] = XUiDictionnaries["FlatScrollOverBlackThemeBrush"];
            XUiDictionnaries["FlatScrollPressBrush"] = XUiDictionnaries["FlatScrollPressBlackThemeBrush"];
            XUiDictionnaries["FontBrush"] = XUiDictionnaries["WhiteFontBrush"];
        }

        /// <summary>
        /// Change all the colors to the light mode
        /// </summary>
        public static void EnableLightMode()
        {
            // Redefine all the colors
            XUiDictionnaries["ThemeColor"] = XUiDictionnaries["WhiteThemeColor"];
            XUiDictionnaries["FlatBaseColor"] = XUiDictionnaries["FlatBaseWhiteThemeColor"];
            XUiDictionnaries["FlatOverColor"] = XUiDictionnaries["FlatOverWhiteThemeColor"];
            XUiDictionnaries["FlatPressColor"] = XUiDictionnaries["FlatPressWhiteThemeColor"];
            XUiDictionnaries["FlatScrollOverColor"] = XUiDictionnaries["FlatScrollOverWhiteThemeColor"];
            XUiDictionnaries["FlatScrollPressColor"] = XUiDictionnaries["FlatScrollPressWhiteThemeColor"];
            XUiDictionnaries["FontColor"] = XUiDictionnaries["BlackFontColor"];

            // Redefine all the brushes
            XUiDictionnaries["ThemeBrush"] = XUiDictionnaries["WhiteThemeBrush"];
            XUiDictionnaries["FlatBaseBrush"] = XUiDictionnaries["FlatBaseWhiteThemeBrush"];
            XUiDictionnaries["FlatOverBrush"] = XUiDictionnaries["FlatOverWhiteThemeBrush"];
            XUiDictionnaries["FlatPressBrush"] = XUiDictionnaries["FlatPressWhiteThemeBrush"];
            XUiDictionnaries["FlatScrollOverBrush"] = XUiDictionnaries["FlatScrollOverWhiteThemeBrush"];
            XUiDictionnaries["FlatScrollPressBrush"] = XUiDictionnaries["FlatScrollPressWhiteThemeBrush"];
            XUiDictionnaries["FontBrush"] = XUiDictionnaries["BlackFontBrush"];
        }
    }
}
