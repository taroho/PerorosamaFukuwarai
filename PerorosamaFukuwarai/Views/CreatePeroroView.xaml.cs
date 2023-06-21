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
        private CreatePeroroViewModel VM => (CreatePeroroViewModel)DataContext;

        public CreatePeroroView()
        {

            InitializeComponent();
            DataContext = new CreatePeroroViewModel();

            VM.CanvasPeroro = CanvasPeroro;
            VM.ImagePeroroBody = ImagePeroroBody;
            VM.ImagePeroroEyeR = ImagePeroroEyeR;
            VM.ImagePeroroEyeL = ImagePeroroEyeL;
            VM.ImagePeroroCheekR = ImagePeroroCheekR;
            VM.ImagePeroroCheekL = ImagePeroroCheekL;
            VM.ImagePeroroMouth = ImagePeroroMouth;
            VM.ImagePeroroTongue = ImagePeroroTongue;
            VM.ImagePeroroNext = ImagePeroroNext;
            ImagePeroroNext.Source = PeroroFileManager.ReturnBitmapImageResource("start.png");
        }


        private void GetMouseClickPositon(object sender, MouseButtonEventArgs e) 
        {
            VM.NextStepPeroro(e.GetPosition(this), ImagePeroroNext);
        }
        
         
        private void GetMouseMovePotison(object sender, MouseEventArgs e)
        {
            VM.FollowMousePeroroImage(e.GetPosition(this));
        }
    }
}
