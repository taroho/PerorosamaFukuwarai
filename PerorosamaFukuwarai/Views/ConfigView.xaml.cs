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
        }

        private void ButtonConfigSave(object sender, RoutedEventArgs e)
        {
            VM.ConfigSave();
        }

        private void TextBoxBackGruond_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            VM.LimitInput(e);
        }
    }
}
