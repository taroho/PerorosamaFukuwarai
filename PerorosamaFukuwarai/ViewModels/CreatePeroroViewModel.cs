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
        string[] compositionArray = PeroroComposition.CompositionArray;
        private int nowPeroroImageNum;
        public Canvas peroroCanvas;
        public Image peroroBodyImage;
        public Image peroroEyeRImage;
        public Image peroroEyeLImage;
        public Image peroroCheekRImage;
        public Image peroroCheekLImage;
        public Image peroroMouthImage;
        public Image peroroTongueImage;

        public CreatePeroroViewModel()
        {
            nowPeroroImageNum = 0;
           

            BodyImage = peroroComposition.Body;
            EyeRImage = peroroComposition.EyeR;
            EyeLImage = peroroComposition.EyeL;
            CheekRImage = peroroComposition.CheekR;
            CheekLImage = peroroComposition.CheekL;
            MouthImage = peroroComposition.Mouth;
            TongueImage = peroroComposition.Tongue;

            
            PeroroEyeR = peroroComposition.EyeRPosition;
            PeroroEyeL = peroroComposition.EyeLPosition;
            PeroroCheekR = peroroComposition.CheekRPosition;
            PeroroCheekL = peroroComposition.CheekLPosition;
            PeroroMouth = peroroComposition.MouthPosition;
            PeroroTongue = peroroComposition.TonguePosition;
            
            Debug.Print(BodyImage);


        }

        private string bodyImage;
        public string BodyImage
        {
            get { return bodyImage; }
            set
            {
                bodyImage = value;
                RaisePropertyChanged(nameof(BodyImage));
            }
        }

        private string eyeRImage;
        public string EyeRImage
        {
            get { return eyeRImage; }
            set
            {
                eyeRImage = value;
                RaisePropertyChanged(nameof(EyeRImage));
            }
        }

        private string eyeLImage;
        public string EyeLImage
        {
            get { return eyeLImage; }
            set
            {
                eyeLImage = value;
                RaisePropertyChanged(nameof(EyeLImage));
            }
        }

        private string cheekRImage;
        public string CheekRImage
        {
            get { return cheekRImage; }
            set
            {
                cheekRImage = value;
                RaisePropertyChanged(nameof(CheekRImage));
            }
        }

        private string cheekLImage;
        public string CheekLImage
        {
            get { return cheekLImage; }
            set
            {
                cheekLImage = value;
                RaisePropertyChanged(nameof(CheekLImage));
            }
        }

        private string mouthImage;
        public string MouthImage
        {
            get { return mouthImage; }
            set
            {
                mouthImage = value;
                RaisePropertyChanged(nameof(MouthImage));
            }
        }

        private string tongueImage;
        public string TongueImage
        {
            get { return tongueImage; }
            set
            {
                tongueImage = value;
                RaisePropertyChanged(nameof(TongueImage));
            }
        }


        private Point peroroNext;
        public Point PeroroNext
        {
            get { return peroroNext; }
            set
            {
                peroroNext = value;
                RaisePropertyChanged(nameof(PeroroNext));
            }
        }

        private Point peroroEyeR;
        public Point PeroroEyeR
        {
            get { return peroroEyeR; }
            set
            {
                peroroEyeR = value;
                RaisePropertyChanged(nameof(PeroroEyeR));
            }
        }

        private Point peroroEyeL;
        public Point PeroroEyeL
        {
            get { return peroroEyeL; }
            set
            {
                peroroEyeL = value;
                RaisePropertyChanged(nameof(PeroroEyeL));
            }
        }

        private Point peroroCheekR;
        public Point PeroroCheekR
        {
            get { return peroroCheekR; }
            set
            {
                peroroCheekR = value;
                RaisePropertyChanged(nameof(PeroroCheekR));
            }
        }

        private Point peroroCheekL;
        public Point PeroroCheekL
        {
            get { return peroroCheekL; }
            set
            {
                peroroCheekL = value;
                RaisePropertyChanged(nameof(PeroroCheekL));
            }
        }

        private Point peroroMouth;
        public Point PeroroMouth
        {
            get { return peroroMouth; }
            set
            {
                peroroMouth = value;
                RaisePropertyChanged(nameof(PeroroMouth));
            }


        }

        private Point peroroTongue;
        public Point PeroroTongue
        {
            get { return peroroTongue; }
            set
            {
                peroroTongue = value;
                RaisePropertyChanged(nameof(PeroroTongue));
            }


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
            PeroroNext = mousepos;
        }

        public void NextStepPeroro(Point mousepos, Image image)
        {
            string path = null;
            
            if(nowPeroroImageNum == compositionArray.Length)
            {
                CreatePeroroImage(PeroroFileManager.OpenFolderDialog(), peroroCanvas);
                return;
            }
            if (nowPeroroImageNum >= compositionArray.Length)
            {
                return;
            }

            switch (compositionArray[nowPeroroImageNum])
            {
                case "Body":
                    peroroBodyImage.Source = PeroroFileManager.ReturnBitmapImageResource("transparentImage.png");
                    path = peroroComposition.EyeR;
                    break;
                case "EyeR":
                    peroroComposition.EyeRPosition = mousepos;
                    path = peroroComposition.EyeL;
                    break;
                case "EyeL":
                    peroroComposition.EyeLPosition = mousepos;
                    path = peroroComposition.CheekR;
                    break;
                case "CheekR":
                    peroroComposition.CheekRPosition = mousepos;
                    path = peroroComposition.CheekL;
                    break;
                case "CheekL":
                    peroroComposition.CheekLPosition = mousepos;
                    path = peroroComposition.Mouth;
                    break;
                case "Mouth":
                    peroroComposition.MouthPosition = mousepos;
                    path = peroroComposition.Tongue;
                    break;
                case "Tongue":
                    peroroComposition.TonguePosition = mousepos;
                    path = null;
                    ShowCompleteImage();
                    break;
                default:
                    break;
                
            }
            nowPeroroImageNum++;
            if(path == null)
            {
                image.Source = PeroroFileManager.ReturnBitmapImageResource("transparentImage.png");
                return;
            }
           
            image.Source = PeroroFileManager.ReturnBitmapImage(path);
        }

        private void ShowCompleteImage()
        {
            peroroBodyImage.Source = PeroroFileManager.ReturnBitmapImage(peroroComposition.Body);
            peroroEyeRImage.Visibility = Visibility.Visible;
            peroroEyeLImage.Visibility = Visibility.Visible;
            peroroCheekRImage.Visibility = Visibility.Visible;
            peroroCheekLImage.Visibility = Visibility.Visible;
            peroroMouthImage.Visibility = Visibility.Visible;
            peroroTongueImage.Visibility = Visibility.Visible;

            PeroroEyeR = peroroComposition.EyeRPosition;
            PeroroEyeL = peroroComposition.EyeLPosition;
            PeroroCheekR = peroroComposition.CheekRPosition;
            PeroroCheekL = peroroComposition.CheekLPosition;
            PeroroMouth = peroroComposition.MouthPosition;
            PeroroTongue = peroroComposition.TonguePosition;
        }

    }
}