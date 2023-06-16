using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Media.Imaging;
using System.Windows;

namespace PerorosamaFukuwarai.PeroroManager
{
    public class PeroroComposition
    {
       
        public static string ProjectPath = Directory.GetCurrentDirectory();
        public readonly static string[] CompositionArray = 
            { "Body", "EyeR", "EyeL", "CheekR", "CheekL", "Mouth", "Tongue" };

        public string Body;
        public string EyeR;
        public string EyeL ;
        public string CheekR;
        public string CheekL;
        public string Mouth;
        public string Tongue;

        public Point BodyPosition = new Point();
        public Point EyeRPosition = new Point();
        public Point EyeLPosition = new Point();
        public Point CheekRPosition = new Point();  
        public Point CheekLPosition = new Point();
        public Point MouthPosition = new Point();
        public Point TonguePosition = new Point();


        public PeroroAccessories PeroroAccessories { get; set; }
        public PeroroComposition()
        {
            SetPeroroComposition();
        }
        
       

        private void SetPeroroComposition()
        {
            foreach(string composition in CompositionArray)
            {
                string path = ProjectPath + "/Peroro/" + composition;
                string[] imgPathList = Directory.GetFiles(path, "*.png");
                Random randImg = new System.Random();
                int imagePath = randImg.Next(0, imgPathList.Length);
                switch (composition)
                {
                    case "Body":
                        this.Body = imgPathList[imagePath];
                        break;
                    case "EyeR":
                        this.EyeR = imgPathList[imagePath];
                        break;
                    case "EyeL":
                        this.EyeL = imgPathList[imagePath];
                        break;
                    case "CheekR":
                        this.CheekR = imgPathList[imagePath];
                        break;
                    case "CheekL":
                        this.CheekL = imgPathList[imagePath];
                        break;
                    case "Mouth":
                        this.Mouth = imgPathList[imagePath];
                        break;
                    case "Tongue":
                        this.Tongue = imgPathList[imagePath];
                        break;
                    default:
                        break;

                }
            }
            
            
        }



    }

    public class PeroroAccessories
    {
        private List<string> AccessoryList = new List<string>();
        public PeroroAccessories() { }

        public void AddAccessory(string accessory)
        {
            AccessoryList.Add(accessory);
        }
    }
}
