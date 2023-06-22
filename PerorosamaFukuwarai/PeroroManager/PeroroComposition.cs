using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Shapes;

namespace PerorosamaFukuwarai.PeroroManager
{
    public enum Peroro
    {
        Body,
        EyeR,
        EyeL,
        CheekR,
        CheekL,
        Mouth,
        Tongue,
        Accessaries,
    }

    public class PeroroComposition
    {
       
        public static string ProjectPath = Directory.GetCurrentDirectory();
        
        public List<PeroroPart> PeroroPartsList = new List<PeroroPart>();

        private PeroroPart Body = new PeroroPart();
        private PeroroPart EyeR = new PeroroPart();
        private PeroroPart EyeL = new PeroroPart() ;
        private PeroroPart CheekR = new PeroroPart();
        private PeroroPart CheekL = new PeroroPart();
        private PeroroPart Mouth = new PeroroPart();
        private PeroroPart Tongue = new PeroroPart();



        public PeroroComposition()
        {
            Body.SetPeroroEnum(Peroro.Body);
            EyeR.SetPeroroEnum(Peroro.EyeR);
            EyeL.SetPeroroEnum(Peroro.EyeL);
            CheekR.SetPeroroEnum(Peroro.CheekR);
            CheekL.SetPeroroEnum(Peroro.CheekL);
            Mouth.SetPeroroEnum(Peroro.Mouth);
            Tongue.SetPeroroEnum(Peroro.Tongue);
            PeroroPartsList.AddRange(new List<PeroroPart>() { Body, EyeR, EyeL, CheekR, CheekL, Mouth, Tongue});
            SetPeroroComposition(this.PeroroPartsList);
        }
        
        public int GetPeroroPartListCount()
        {
            return PeroroPartsList.Count;
        }

        public void AddPeroroAccessary()
        {
            PeroroPart peroroPart = new PeroroPart();
            peroroPart.SetPath(ReturnRandomPeroroAccessary());                     
            this.PeroroPartsList.Add(peroroPart);
        }

        private string ReturnRandomPeroroAccessary()
        {
            string path = ProjectPath + "/Peroro/Accessaries";
            string[] imgPathList = Directory.GetFiles(path, "*.png");
            Random randImg = new System.Random();
            int imagePathNum = randImg.Next(0, imgPathList.Length);

            return imgPathList[imagePathNum];
        }

        
        private void SetPeroroComposition(List<PeroroPart> peroroPartsList)
        {
            string path = ProjectPath + "/Peroro/";
            for (int i = 0;i < peroroPartsList.Count;i++)
            {
                SwitchPeroro(i, path, peroroPartsList);
               
            }            
        }
        private void SwitchPeroro(int num, string path, List<PeroroPart> peroroPartsList)
        {
            switch (peroroPartsList[num].GetPeroroEnum())
            {
                case Peroro.Body:
                case Peroro.EyeR:
                case Peroro.EyeL:
                case Peroro.CheekR:
                case Peroro.CheekL:
                case Peroro.Mouth:
                case Peroro.Tongue:
                    path += peroroPartsList[num].GetPeroroEnum().ToString();
                    break;
                default:
                    break;
            }
            string[] imgPathList = Directory.GetFiles(path, "*.png");
            Random randImg = new System.Random();
            int imagePathNum = randImg.Next(0, imgPathList.Length);
            peroroPartsList[num].SetPath(imgPathList[imagePathNum]);
        }
    }


    public class PeroroPart
    {
        private Peroro peroroEnum;
        private string path;
        private Point pos;

        public void SetPeroroEnum(Peroro peroro)
        {
            this.peroroEnum = peroro;
        }

        public Peroro GetPeroroEnum() 
        { 
            return this.peroroEnum; 
        }

        public void SetPath(string path)
        {
            this.path = path;
        }

        public string GetPath()
        {
            return path;
        }

        public void SetPos(Point point) 
        {
            this.pos = point;
        }
        public Point GetPos()
        {
            return pos;
        }
    }
}
