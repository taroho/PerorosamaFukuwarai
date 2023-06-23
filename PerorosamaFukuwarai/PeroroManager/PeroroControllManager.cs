using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PerorosamaFukuwarai.PeroroManager
{
    public class PeroroControllManager
    {
        /// <summary>
        ///   型 SolidColorBrushを返します。
        ///   無効な引数の場合、0,0,0,0になる
        /// </summary>
        /// <param name="colorCode">4個の要素を持つstring[]</param>
        /// <returns></returns>
        public static SolidColorBrush ReturnColorByte(string[] colorCode)
        {
            try
            {
                byte alpha = Convert.ToByte(colorCode[0]);
                byte red = Convert.ToByte(colorCode[1]);
                byte blue = Convert.ToByte(colorCode[2]);
                byte green = Convert.ToByte(colorCode[3]);
                return new SolidColorBrush(Color.FromArgb(alpha, red, green, blue));
            }
            catch
            {

                return new SolidColorBrush(Color.FromArgb(0x0, 0x0, 0x0, 0x0));
            }
        }
            
    }
}
