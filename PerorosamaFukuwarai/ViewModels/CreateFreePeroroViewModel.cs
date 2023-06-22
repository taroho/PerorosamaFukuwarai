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

namespace PerorosamaFukuwarai.ViewModels
{
    public class CreateFreePeroroViewModel:ViewModelBase
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
        public Image ImagePeroroNext;

        public List<Image> ImagePeroroList = new List<Image>();

        public CreateFreePeroroViewModel()
        {

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
            switch (peroroComposition.PeroroPartsList[nowPeroroImageNum].GetPeroroEnum())
            {
                case Peroro.Body:
                case Peroro.EyeR:
                case Peroro.EyeL:
                case Peroro.CheekR:
                case Peroro.CheekL:
                case Peroro.Mouth:
                case Peroro.Tongue:
                    break;
                default:
                    break;
            }
            peroroComposition.PeroroPartsList[nowPeroroImageNum].SetPos(mousepos);
            ImagePeroroList[nowPeroroImageNum].Source = PeroroFileManager.ReturnBitmapImage(peroroComposition.PeroroPartsList[nowPeroroImageNum].GetPath());
            nowPeroroImageNum++;
        }

        private void ShowResultPeroroImage()
        {
            ImagePeroroBody.Visibility = Visibility.Visible;
            ImagePeroroNext.Visibility = Visibility.Hidden;
            ImagePeroroList.AddRange
                (new Image[] {ImagePeroroBody, ImagePeroroEyeR, ImagePeroroEyeL,
                               ImagePeroroCheekR,ImagePeroroCheekL, ImagePeroroMouth, ImagePeroroTongue});
            for (int i = 0; i < peroroComposition.GetPeroroPartListCount(); i++)
            {
                ImagePeroroList[i].Source = PeroroFileManager.ReturnBitmapImage(peroroComposition.PeroroPartsList[i].GetPath());
                ImagePeroroList[i].RenderTransform = new TranslateTransform(peroroComposition.PeroroPartsList[i].GetPos().X,
                                                                            peroroComposition.PeroroPartsList[i].GetPos().Y);
            }
        }
    }
}
