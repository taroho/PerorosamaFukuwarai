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
        
        public CreatePeroroViewModel()
        {
            
        }


        public void FollowMousePeroroImage(Point mousepos)
        {
            ImagePeroroNext.RenderTransform = new TranslateTransform(mousepos.X, mousepos.Y);
        }

        public void NextStepPeroro(Point mousepos)
        {
            if(nowPeroroImageNum == 0)
            {

                ImagePeroroBody.Visibility = Visibility.Hidden;
                ImagePeroroNext.Source = PeroroFileManager.ReturnBitmapImage(peroroComposition.PeroroPartsList[nowPeroroImageNum+1].GetPath());
                nowPeroroImageNum++;
                return;
            }
            else if (nowPeroroImageNum == peroroComposition.GetPeroroPartListCount()-1)
            {
                peroroComposition.PeroroPartsList[peroroComposition.GetPeroroPartListCount() -1].SetPos(mousepos);
                ShowResultPeroroImage();
                nowPeroroImageNum++;
                return;
            }
            else if(nowPeroroImageNum == peroroComposition.GetPeroroPartListCount())
            {
                string path = PeroroFileManager.OpenFolderDialog();
                PeroroFileManager.CreatePeroroImage(path, CanvasPeroro);
                return;
            }

            peroroComposition.PeroroPartsList[nowPeroroImageNum].SetPos(mousepos);
            ImagePeroroNext.Source = PeroroFileManager.ReturnBitmapImage(peroroComposition.PeroroPartsList[nowPeroroImageNum+1].GetPath());
            nowPeroroImageNum++;
        }

        private void ShowResultPeroroImage()
        {
            ImagePeroroBody.Visibility = Visibility.Visible;
            ImagePeroroNext.Visibility = Visibility.Hidden;
            ImagePeroroList.AddRange
                (new Image[] {ImagePeroroBody, ImagePeroroEyeR, ImagePeroroEyeL, 
                               ImagePeroroCheekR,ImagePeroroCheekL, ImagePeroroMouth, ImagePeroroTongue});
            for (int i = 0; i < peroroComposition.GetPeroroPartListCount();i++)
            {
                ImagePeroroList[i].Source = PeroroFileManager.ReturnBitmapImage(peroroComposition.PeroroPartsList[i].GetPath());
                ImagePeroroList[i].RenderTransform = new TranslateTransform(peroroComposition.PeroroPartsList[i].GetPos().X, 
                                                                            peroroComposition.PeroroPartsList[i].GetPos().Y);
            }
        }
    }
}