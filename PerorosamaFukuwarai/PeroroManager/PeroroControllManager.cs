using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PerorosamaFukuwarai.PeroroManager
{
    public class PeroroControllManager
    {
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
                System.Windows.MessageBox.Show("無効な設定");
                return new SolidColorBrush(Color.FromArgb(0x0, 0x0, 0x0, 0x0));
            }
        }
            
    }
}
