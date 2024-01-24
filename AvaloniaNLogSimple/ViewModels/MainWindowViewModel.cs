using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using NLog;

namespace AvaloniaNLogSimple.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        public string Greeting => "Welcome to Avalonia!";

        [RelayCommand]
        private async Task TestLogAsync()
        {
            for (int i = 0; i < 20; i++)
            {
                await Task.Delay(10);
                logger.Info("TestLog");
            }
        }

        [RelayCommand]
        private void ClearLog()
        {

        }
    }
}