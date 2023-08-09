using NLog;
using System.Windows.Media;
using Wpf.Ui.Appearance;

namespace WpfUiAppLog.ViewModels.Pages
{
    public partial class DashboardViewModel : ObservableObject
    {
        private readonly static Logger logger = LogManager.GetCurrentClassLogger();

        [ObservableProperty]
        private bool _aaAAA = true;

        [ObservableProperty]
        private int _counter = 0;

        public DashboardViewModel()
        {
            Theme.Changed += Theme_Changed;
        }

        private void Theme_Changed(ThemeType currentTheme, Color systemAccent)
        {
            if (currentTheme == ThemeType.Light)
            {
                AaAAA = true;
            }
        }

        [RelayCommand]
        private void OnCounterIncrement()
        {
            Counter++;
            logger.Info(Counter.ToString());
            AaAAA = !AaAAA;
            logger.Info(AaAAA.ToString());


        }
    }
}
