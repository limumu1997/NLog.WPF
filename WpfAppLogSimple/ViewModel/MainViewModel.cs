using System.Threading.Tasks;
using NLog;
using System.Text;
using System;
using System.Windows.Documents;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfAppLogSimple.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly static Logger logger = LogManager.GetCurrentClassLogger();

        public MainViewModel()
        {
            logger.Info("Constructor function", false);
        }

        [RelayCommand]
        private async Task ShowlogAsync()
        {
            logger.Info("xss");
            await Task.Delay(100);
        }


    }
}
