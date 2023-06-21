using System;
using System.Collections.Generic;
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


namespace PerorosamaFukuwarai
{
    using PerorosamaFukuwarai.PeroroManager;
    using PerorosamaFukuwarai.ViewModels;
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();

            ButtonImage.Source = PeroroFileManager.ReturnBitmapImageResource("perorobody.png");
            ButtonFreeImage.Source = PeroroFileManager.ReturnBitmapImageResource("peroroImageresources.png");
        }

        private MainWindowViewModel VM => (MainWindowViewModel) DataContext;

        private void ClickFukuwaraiButton(object sender, RoutedEventArgs e)
        {
            VM.GoFukuwaraiPeroroView();
        }

        private void ClickCreateButton(object sender, RoutedEventArgs e)
        {
            VM.GoCreatePeroroView();
        }
    }
}
