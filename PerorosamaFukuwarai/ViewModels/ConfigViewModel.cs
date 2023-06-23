using PerorosamaFukuwarai.PeroroManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PerorosamaFukuwarai.ViewModels
{
    public class ConfigViewModel:ViewModelBase
    {
        public TextBox TextBoxBackGruond;
        public TextBox TextBoxAccessaryNum;
        private List<string> ConfigList = new List<string>();

        public ConfigViewModel()
        {
            
        }

        /// <summary>
        /// /Peroro/Config.txtの内容をTextBoxに表示します
        /// </summary>
        public void SetText()
        {
            string CheckedBoxTextBackGruond = CheckConfigTextBackGruond(PeroroFileManager.ReturnConfigText(PeroroFileManager.ReturnTextFile("Peroro/Config.txt"))[0]);
            string CheckedTextBoxAccessaryNum = CheckConfigTextAccessaryNum(PeroroFileManager.ReturnConfigText(PeroroFileManager.ReturnTextFile("Peroro/Config.txt"))[1]);
            TextBoxBackGruond.Text = CheckedBoxTextBackGruond;
            TextBoxAccessaryNum.Text = CheckedTextBoxAccessaryNum;
        }

        public void ConfigSave()
        {
            List<string> textBoxList = new List<string>();
            TextBoxBackGruond.Text = CheckConfigTextBackGruond(TextBoxBackGruond.Text);
            TextBoxAccessaryNum.Text = CheckConfigTextAccessaryNum(TextBoxAccessaryNum.Text);
            textBoxList.AddRange(new List<string>() { TextBoxBackGruond.Text, TextBoxAccessaryNum.Text });
            PeroroFileManager.WriteConfigFile(textBoxList);
        }
           
        public void LimitInput(TextCompositionEventArgs e)
        {
            e.Handled = !new Regex("[0-9,]").IsMatch(e.Text);
        }

        private string CheckConfigTextBackGruond(string str)
        {
            if(string.IsNullOrEmpty(str))
            {
                str = "0,0,0,0";
                System.Windows.MessageBox.Show(
                    "BackGroundColorの値が無効です。\n\"a,R,B,G\"です。各値は0~255", "警告", 
                    System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
            return str;
        }

        private string CheckConfigTextAccessaryNum(string str)
        {
            if(string.IsNullOrEmpty(str))
            {
                str = "1";
                System.Windows.MessageBox.Show(
                    "BackGroundColorの値が無効です。整数のみを入力してください","警告",
                    System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
            return str;
        }
    }
}
