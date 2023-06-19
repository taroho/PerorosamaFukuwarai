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
using PerorosamaFukuwarai.PeroroManager;
using PerorosamaFukuwarai.ViewModels;

namespace PerorosamaFukuwarai.Views
{
    /// <summary>
    /// CreateFreePeroroView.xaml の相互作用ロジック
    /// </summary>
    public partial class CreateFreePeroroView : UserControl
    {
        public CreateFreePeroroView()
        {
            InitializeComponent();
            DataContext = new CreateFreePeroroViewModel();

            nextImage.Source = PeroroFileManager.ReturnBitmapImage(VM.peroroComposition.EyeR);
            VM.peroroEyeRImage = PeroroEyeRImage;
            VM.peroroEyeLImage = PeroroEyeLImage;
            VM.peroroCheekRImage = PeroroCheekRImage;
            VM.peroroCheekLImage = PeroroCheekLImage;
            VM.peroroMouthImage = PeroroMouthImage;
            VM.peroroTongueImage = PeroroTongueImage;
        }

        private CreateFreePeroroViewModel VM => (CreateFreePeroroViewModel)DataContext;

        private void GetMouseClickPositon(object sender, MouseButtonEventArgs e)
        {
            VM.NextStepPeroro(e.GetPosition(this), nextImage);
        }

        private void GetMouseMovePotison(object sender, MouseEventArgs e)
        {
            VM.FollowMousePeroroImage(e.GetPosition(this));
        }
    }
}
