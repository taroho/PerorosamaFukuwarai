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

namespace PerorosamaFukuwarai.Views
{
    using PerorosamaFukuwarai.ViewModels;
    using System.Diagnostics;
    using System.Drawing.Imaging;
    using System.IO;

    /// <summary>
    /// CreatePeroroView.xaml の相互作用ロジック
    /// </summary>
    public partial class CreatePeroroView : UserControl
    {
        public CreatePeroroView()
        {
            InitializeComponent();
            DataContext = new CreatePeroroViewModel();

            nextImage.Source = PeroroFileManager.ReturnBitmapImage("Peroro/EyeR/peroroeyeR.png");
            VM.peroroCanvas = peroroCanvas;
            VM.peroroEyeRImage = PeroroEyeRImage;
            VM.peroroEyeLImage = PeroroEyeLImage;
            VM.peroroCheekRImage = PeroroCheekRImage;
            VM.peroroCheekLImage = PeroroCheekLImage;
            VM.peroroMouthImage = PeroroMouthImage;
            VM.peroroTongueImage = PeroroTongueImage;
        }

        private CreatePeroroViewModel VM => (CreatePeroroViewModel)DataContext;

        private void ClickCreatePeroroImage(object sender, RoutedEventArgs e)
        {
            VM.CreatePeroroImage( PeroroFileManager.OpenFolderDialog(), peroroCanvas);
        }
       

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
