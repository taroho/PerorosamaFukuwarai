using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerorosamaFukuwarai.PeroroManager;
using System.Windows;
using System.Diagnostics;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Input;
using PerorosamaFukuwarai.Views;
using System.Windows.Forms;
using System.IO;
using System.Windows.Media;
using System.Net.NetworkInformation;
using System.Windows.Shapes;

namespace PerorosamaFukuwarai.ViewModels
{
    public class CreatePeroroViewModel : ViewModelBase
    {
        public PeroroComposition peroroComposition = new PeroroComposition();
        private int nowPeroroImageNum;
        private int savePeroroImageNum;
        public Canvas CanvasPeroro;

        public Image ImagePeroroBody;
        public Image ImagePeroroEyeR;
        public Image ImagePeroroEyeL;
        public Image ImagePeroroCheekR;
        public Image ImagePeroroCheekL;
        public Image ImagePeroroMouth;
        public Image ImagePeroroTongue;
        public Image ImagePeroroNext;
        
        public CreatePeroroViewModel()
        {
            nowPeroroImageNum = 0;
        }


        public void CreatePeroroImage(string path, Canvas canvas)
        {
            if(path==null)
            {
                return;
            }
            BitmapEncoder encoder = null;


            var size = new Size(canvas.Width, canvas.Height);
            canvas.Measure(size);
            canvas.Arrange(new Rect(size));

            // VisualObjectをBitmapに変換する
            var renderBitmap = new RenderTargetBitmap((int)size.Width,       // 画像の幅
                                                      (int)size.Height,      // 画像の高さ
                                                      96.0d,                 // 横400.0DPI
                                                      96.0d,                 // 縦400.0DPI
                                                      PixelFormats.Pbgra32); // 32bit(RGBA各8bit)
            renderBitmap.Render(canvas);

            // 出力用の FileStream を作成する
            using (var os = new FileStream(path, FileMode.Create))
            {
                // 変換したBitmapをエンコードしてFileStreamに保存する。
                // BitmapEncoder が指定されなかった場合は、PNG形式とする。
                encoder = encoder ?? new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                encoder.Save(os);
            }
        }

        public void FollowMousePeroroImage(Point mousepos)
        {
            ImagePeroroNext.RenderTransform = new TranslateTransform(mousepos.X, mousepos.Y);
        }

        public void NextStepPeroro(Point mousepos, Image image)
        {
            //image.Source = PeroroFileManager.ReturnBitmapImage(path);
        }

       
        

    }
}