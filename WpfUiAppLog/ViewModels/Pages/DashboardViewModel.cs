using NLog;
using System.Windows.Media;
using Wpf.Ui.Appearance;

namespace WpfUiAppLog.ViewModels.Pages
{
    public partial class DashboardViewModel : ObservableObject
    {
        private readonly static Logger logger = LogManager.GetCurrentClassLogger();

        [ObservableProperty]
        private bool _isLightTheme;

        [ObservableProperty]
        private int _counter = 0;

        public DashboardViewModel()
        {
            Theme.Changed += Theme_Changed;
        }

        private void Theme_Changed(ThemeType currentTheme, Color systemAccent)
        {
            IsLightTheme = currentTheme == ThemeType.Light;
        }

        [RelayCommand]
        private void OnCounterIncrement()
        {
            Counter++;
            // ture is show on the nlog textbox
            logger.Info(Counter.ToString(), true);
            logger.Info(IsLightTheme.ToString(),true);


        }
    }
}
