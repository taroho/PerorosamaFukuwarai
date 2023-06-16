using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

namespace PerorosamaFukuwarai.PeroroManager
{
    public class PeroroFileManager
    {
        public PeroroFileManager() { }

        public static string OpenFolderDialog()
        {
            using (var cofd = new CommonOpenFileDialog()
            {
                Title = "フォルダを選択してください",
                InitialDirectory = @"D:\Users\threeshark",
                DefaultFileName = "peroroImage.png",
            })
            {
                if (cofd.ShowDialog() != CommonFileDialogResult.Ok)
                {
                    return null ;
                }

                // FileNameで選択されたフォルダを取得する
                System.Windows.MessageBox.Show($"{cofd.FileName}を選択しました");
                return cofd.FileName;
            }
        }

        public static BitmapImage ReturnBitmapImage(string path)
        {
            BitmapImage bmpImage = new BitmapImage();
            using (FileStream stream = File.OpenRead(path))
            {
                bmpImage.BeginInit();
                bmpImage.StreamSource = stream;
                bmpImage.DecodePixelWidth = 400;
                bmpImage.DecodePixelHeight = 400;
                bmpImage.CacheOption = BitmapCacheOption.OnLoad;
                bmpImage.CreateOptions = BitmapCreateOptions.None;
                bmpImage.EndInit();
                bmpImage.Freeze();
            }

            return bmpImage;
        }

        public static BitmapImage ReturnBitmapImageResource(string fileName)
        {
            BitmapImage result = null;
            Uri resource_uri = new Uri("/Resources/Images/" + fileName, UriKind.Relative);
            StreamResourceInfo info = Application.GetResourceStream(resource_uri);

            if (info != null)
            {
                using (Stream stream = info.Stream)
                {
                    if (stream != null)
                    {
                        result = new BitmapImage();

                        result.BeginInit();
                        result.StreamSource = stream;
                        result.CacheOption = BitmapCacheOption.OnLoad;
                        result.EndInit();
                    }
                }
            }

            return result;
        }
    }
}
