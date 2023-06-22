using PerorosamaFukuwarai.PeroroManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace PerorosamaFukuwarai.ViewModels
{
    public class CreateFreePeroroViewModel : ViewModelBase
    {
        public PeroroComposition peroroComposition = new PeroroComposition();
        private int nowPeroroImageNum = 0;
        public Canvas CanvasPeroro;
        public Image ImagePeroroBody;
        public Image ImagePeroroEyeR;
        public Image ImagePeroroEyeL;
        public Image ImagePeroroCheekR;
        public Image ImagePeroroCheekL;
        public Image ImagePeroroMouth;
        public Image ImagePeroroTongue;
        public List<Image> ImagePeroroAccessariesList = new List<Image>();
        public Image ImagePeroroNext;

        public List<Image> ImagePeroroList = new List<Image>();

        public CreateFreePeroroViewModel()
        {


        }

        public void StartUp()
        {
            for (int i = 0; i < Convert.ToInt32(PeroroFileManager.ReturnConfigText(PeroroFileManager.ReturnTextFile("Peroro/Config.txt"))[1]); i++)
            {
                Image image = new Image();
                image.Width = 400;
                image.Height = 400;
                image.VerticalAlignment = VerticalAlignment.Top;
                image.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                ImagePeroroAccessariesList.Add(image);
                peroroComposition.AddPeroroAccessary();
            }

            ImagePeroroNext.Source = PeroroFileManager.ReturnBitmapImageResource("start.png");
            ImagePeroroBody.Source = PeroroFileManager.ReturnBitmapImage(peroroComposition.PeroroPartsList[0].GetPath());
            string[] colorCode = PeroroFileManager.ReturnConfigText(PeroroFileManager.ReturnTextFile("Peroro/Config.txt"))[0].Split(',');

            try
            {
                byte alpha = Convert.ToByte(colorCode[0]);
                byte red = Convert.ToByte(colorCode[1]);
                byte blue = Convert.ToByte(colorCode[2]);
                byte green = Convert.ToByte(colorCode[3]);
                CanvasPeroro.Background = new SolidColorBrush(Color.FromArgb(alpha, red, green, blue));
            }
            catch
            {
                Debug.Print("byte");
            }

        }

        public void FollowMousePeroroImage(Point mousepos)
        {
            ImagePeroroNext.RenderTransform = new TranslateTransform(mousepos.X, mousepos.Y);
        }

        public void NextStepPeroro(Point mousepos)
        {
            if (nowPeroroImageNum == 0)
            {

                ImagePeroroNext.Source = PeroroFileManager.ReturnBitmapImage(peroroComposition.PeroroPartsList[nowPeroroImageNum + 1].GetPath());
                nowPeroroImageNum++;
                return;
            }
            else if (nowPeroroImageNum == peroroComposition.GetPeroroPartListCount() - 1)
            {
                Debug.Print((peroroComposition.GetPeroroPartListCount() - 1).ToString());
                peroroComposition.PeroroPartsList[peroroComposition.GetPeroroPartListCount() - 1].SetPos(mousepos);
                ShowResultPeroroImage();
                nowPeroroImageNum++;
                return;
            }
            else if (nowPeroroImageNum == peroroComposition.GetPeroroPartListCount())
            {
                string path = PeroroFileManager.OpenFolderDialog();
                PeroroFileManager.CreatePeroroImage(path, CanvasPeroro);
                return;
            }

            peroroComposition.PeroroPartsList[nowPeroroImageNum].SetPos(mousepos);
            ImagePeroroNext.Source = PeroroFileManager.ReturnBitmapImage(peroroComposition.PeroroPartsList[nowPeroroImageNum + 1].GetPath());
            switch(nowPeroroImageNum)
            {
                case 1:
                    ImagePeroroEyeR.Source = PeroroFileManager.ReturnBitmapImage(peroroComposition.PeroroPartsList[nowPeroroImageNum].GetPath());
                    ImagePeroroEyeR.RenderTransform = new TranslateTransform(peroroComposition.PeroroPartsList[nowPeroroImageNum].GetPos().X,
                                                                            peroroComposition.PeroroPartsList[nowPeroroImageNum].GetPos().Y);
                    break;
                case 2:
                    ImagePeroroEyeL.Source = PeroroFileManager.ReturnBitmapImage(peroroComposition.PeroroPartsList[nowPeroroImageNum].GetPath());
                    ImagePeroroEyeL.RenderTransform = new TranslateTransform(peroroComposition.PeroroPartsList[nowPeroroImageNum].GetPos().X,
                                                                            peroroComposition.PeroroPartsList[nowPeroroImageNum].GetPos().Y);
                    break;
                case 3:
                    ImagePeroroCheekR.Source = PeroroFileManager.ReturnBitmapImage(peroroComposition.PeroroPartsList[nowPeroroImageNum].GetPath());
                    ImagePeroroCheekR.RenderTransform = new TranslateTransform(peroroComposition.PeroroPartsList[nowPeroroImageNum].GetPos().X,
                                                                            peroroComposition.PeroroPartsList[nowPeroroImageNum].GetPos().Y);
                    break;
                case 4:
                    ImagePeroroCheekL.Source = PeroroFileManager.ReturnBitmapImage(peroroComposition.PeroroPartsList[nowPeroroImageNum].GetPath());
                    ImagePeroroCheekL.RenderTransform = new TranslateTransform(peroroComposition.PeroroPartsList[nowPeroroImageNum].GetPos().X,
                                                                            peroroComposition.PeroroPartsList[nowPeroroImageNum].GetPos().Y);
                    break;
                case 5:
                    ImagePeroroMouth.Source = PeroroFileManager.ReturnBitmapImage(peroroComposition.PeroroPartsList[nowPeroroImageNum].GetPath());
                    ImagePeroroMouth.RenderTransform = new TranslateTransform(peroroComposition.PeroroPartsList[nowPeroroImageNum].GetPos().X,
                                                                            peroroComposition.PeroroPartsList[nowPeroroImageNum].GetPos().Y);
                    break;
                case 6:
                    ImagePeroroTongue.Source = PeroroFileManager.ReturnBitmapImage(peroroComposition.PeroroPartsList[nowPeroroImageNum].GetPath());
                    ImagePeroroTongue.RenderTransform = new TranslateTransform(peroroComposition.PeroroPartsList[nowPeroroImageNum].GetPos().X,
                                                                            peroroComposition.PeroroPartsList[nowPeroroImageNum].GetPos().Y);
                    Debug.Print(nowPeroroImageNum.ToString());

                    break;
                default:
                    ImagePeroroAccessariesList[nowPeroroImageNum - 7].Source = PeroroFileManager.ReturnBitmapImage(peroroComposition.PeroroPartsList[nowPeroroImageNum].GetPath());
                    ImagePeroroAccessariesList[nowPeroroImageNum - 7].RenderTransform = new TranslateTransform(peroroComposition.PeroroPartsList[nowPeroroImageNum].GetPos().X,
                                                                            peroroComposition.PeroroPartsList[nowPeroroImageNum].GetPos().Y);
                    CanvasPeroro.Children.Add(ImagePeroroAccessariesList[nowPeroroImageNum - 7]);
                    break;
            }
            nowPeroroImageNum++;
        }

        
        private void ShowResultPeroroImage()
        {
            ImagePeroroNext.Visibility = Visibility.Collapsed;
            ImagePeroroAccessariesList[nowPeroroImageNum - 7].Source = PeroroFileManager.ReturnBitmapImage(peroroComposition.PeroroPartsList[nowPeroroImageNum].GetPath());
            ImagePeroroAccessariesList[nowPeroroImageNum - 7].RenderTransform = new TranslateTransform(peroroComposition.PeroroPartsList[nowPeroroImageNum].GetPos().X,
                                                                    peroroComposition.PeroroPartsList[nowPeroroImageNum].GetPos().Y);
            CanvasPeroro.Children.Add(ImagePeroroAccessariesList[nowPeroroImageNum - 7]);
        }
    }
}
