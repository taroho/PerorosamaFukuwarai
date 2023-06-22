using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;

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

        public static void CreatePeroroImage(string path, Canvas canvas)
        {
            if (path == null)
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

        public static List<string> ReturnTextFile(string path)
        {
            
            //読み込むテキストを保存する変数
            var texts = new List<string>();

            try
            {
                //ファイルをオープンする
                using (StreamReader sr = new StreamReader(path, Encoding.GetEncoding("Shift_JIS")))
                {
                    while (0 <= sr.Peek())
                    {
                        texts.Add(sr.ReadLine());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return texts;
        }

        public static List<string> ReturnConfigText(List<string> texts, int num = 1)
        {
            List<string> result = new List<string>();   
            foreach (string text in texts)
            {
                string[] dest = text.Split(new char[] { '=', ';' });
                result.Add(dest[num]);
            }
            return result;
        }

        public static void WriteConfigFile(List<string> textbox)
        {
            List<string> text = PeroroFileManager.ReturnConfigText(PeroroFileManager.ReturnTextFile("Peroro/Config.txt"), 0);
            string path = "Peroro/Config.txt";
            //ファイルをオープンする
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.GetEncoding("Shift_JIS")))
            {
                for (int i = 0; i < textbox.Count; i++)
                {
                    textbox[i] = textbox[i].Replace(" ", "");
                    sw.WriteLine(text[i] +"="+textbox[i]+";");
                }
            }
        }

    }
}
