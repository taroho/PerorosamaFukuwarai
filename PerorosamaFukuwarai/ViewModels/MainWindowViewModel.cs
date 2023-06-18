using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerorosamaFukuwarai.ViewModels
{
    public class MainWindowViewModel:ViewModelBase
    {
        public MainWindowViewModel()
        {
            CreatePeroroViewModel createPeroroViewModel = new CreatePeroroViewModel();
            ActiveView = createPeroroViewModel;
            Debug.Print(ActiveView.ToString());
        }

        
        private ViewModelBase activeView;
        public ViewModelBase ActiveView
        {
            get { return activeView; }
            set
            {
                activeView = value;
                RaisePropertyChanged(nameof(ActiveView));
            }
        }

        public void GoCreatePeroroView()
        {
            ActiveView = new CreateFreePeroroViewModel();
        }

        public void GoFukuwaraiPeroroView() 
        {
            ActiveView = new CreatePeroroViewModel();
        }

       
    }
}
