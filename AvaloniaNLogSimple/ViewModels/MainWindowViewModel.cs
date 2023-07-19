using CommunityToolkit.Mvvm.Input;
using NLog;

namespace AvaloniaNLogSimple.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        public string Greeting => "Welcome to Avalonia!";

        [RelayCommand]
        private void TestLog()
        {
            logger.Info("TestLog");
        }

        [RelayCommand]
        private void ClearLog()
        {

        }
    }
}