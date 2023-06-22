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

        public void SetText()
        {
            TextBoxBackGruond.Text = PeroroFileManager.ReturnConfigText(PeroroFileManager.ReturnTextFile("Peroro/Config.txt"))[0];
            TextBoxAccessaryNum.Text = PeroroFileManager.ReturnConfigText(PeroroFileManager.ReturnTextFile("Peroro/Config.txt"))[1];
        }

        public void ConfigSave()
        {
            List<string> textBoxList = new List<string>();
            textBoxList.AddRange(new List<string>() { TextBoxBackGruond.Text, TextBoxAccessaryNum.Text });
            PeroroFileManager.WriteConfigFile(textBoxList);
        }
           
        public void LimitInput(TextCompositionEventArgs e)
        {
            e.Handled = !new Regex("[0-9,]").IsMatch(e.Text);
        }
    }
}
