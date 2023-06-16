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
    }
}
