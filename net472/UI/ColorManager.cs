using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace XUi.UI
{
    /// <summary>
    /// Manage the color of XUi
    /// </summary>
    public class ColorManager
    {
        /// <summary>
        /// Return the base color depend to the hex color
        /// </summary>
        /// 
        /// <param name="hexadecimalColor">Hexadecimal color in <see cref="string"/></param>
        /// 
        /// <returns>
        /// Base color created
        /// </returns>
        public static Color CreateBaseColor(string hexadecimalColor)
        {
            return (Color)ColorConverter.ConvertFromString(hexadecimalColor);
        }

        /// <summary>
        /// Return the base color depend to the rgb values
        /// </summary>
        /// 
        /// <param name="r">Red color value</param>
        /// <param name="g">Green color value</param>
        /// <param name="b">Blue color value</param>
        /// 
        /// <returns>
        /// Base color created
        /// </returns>
        public static Color CreateBaseColor(byte r, byte g, byte b)
        {
            return new Color
            {
                A = 255,
                R = r,
                G = g,
                B = b
            };
        }

        /// <summary>
        /// Create the new color palette from the base color
        /// </summary>
        /// 
        /// <param name="baseColor">Color base used to create the color palette</param>
        public static void CreateColorPalette(Color baseColor)
        {
            Color midColor = new Color
            {
                A = 255,
                R = (byte)((baseColor.R - 22 >= 0) ? (baseColor.R - 22) : 0),
                G = (byte)((baseColor.G - 22 >= 0) ? (baseColor.G - 22) : 0),
                B = (byte)((baseColor.B - 22 >= 0) ? (baseColor.B - 22) : 0)
            };

            Color darkColor = new Color
            {
                A = 255,
                R = (byte)((baseColor.R - 22 * 2 >= 0) ? (baseColor.R - 22 * 2) : 0),
                G = (byte)((baseColor.G - 22 * 2 >= 0) ? (baseColor.G - 22 * 2) : 0),
                B = (byte)((baseColor.B - 22 * 2 >= 0) ? (baseColor.B - 22 * 2) : 0)
            };

            XUiTheme.XUiDictionaries["BaseColor"] = baseColor;
            XUiTheme.XUiDictionaries["MidColor"] = midColor;
            XUiTheme.XUiDictionaries["DarkColor"] = darkColor;
        }
    }
}
