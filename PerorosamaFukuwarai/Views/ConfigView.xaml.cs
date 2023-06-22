using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PerorosamaFukuwarai.PeroroManager;
using PerorosamaFukuwarai.ViewModels;

namespace PerorosamaFukuwarai.Views
{
    /// <summary>
    /// ConfigView.xaml の相互作用ロジック
    /// </summary>
    public partial class ConfigView : UserControl
    {
        private ConfigViewModel VM => (ConfigViewModel)DataContext;
        public ConfigView()
        {
            InitializeComponent();
            DataContext = new ConfigViewModel();

            VM.TextBoxBackGruond = TextBoxBackGruond;
            VM.TextBoxAccessaryNum = TextBoxAccessaryNum;

            VM.SetText();

            string[] colorCode = PeroroFileManager.ReturnConfigText(PeroroFileManager.ReturnTextFile("Peroro/Config.txt"))[0].Split(',');
            byte alpha = Convert.ToByte(colorCode[0]);
            byte red = Convert.ToByte(colorCode[1]);
            byte blue = Convert.ToByte(colorCode[2]);
            byte green = Convert.ToByte(colorCode[3]);

            Debug.Print(red.ToString());
            TextBackGruond.Foreground = new SolidColorBrush(Color.FromArgb(alpha, red, green, blue));
        }

        private void ButtonConfigSave(object sender, RoutedEventArgs e)
        {
            VM.ConfigSave();
        }
    }
}
