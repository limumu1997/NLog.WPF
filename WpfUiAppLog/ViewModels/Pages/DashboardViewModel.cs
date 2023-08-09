// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using NLog;
using Wpf.Ui.Appearance;

namespace WpfUiAppLog.ViewModels.Pages
{
    public partial class DashboardViewModel : ObservableObject
    {
        private readonly static Logger logger = LogManager.GetCurrentClassLogger();

        [ObservableProperty]
        private int _counter = 0;

        [ObservableProperty]
        private bool _isLightTheme;

        public DashboardViewModel()
        {
            Theme.Changed += Theme_Changed;
        }

        private void Theme_Changed(ThemeType currentTheme, System.Windows.Media.Color systemAccent)
        {
            if (currentTheme == ThemeType.Light)
            {
                //IsLightTheme = true;
            }
        }

        [RelayCommand]
        private void OnCounterIncrement()
        {
            Counter++;

            if (IsLightTheme)
            {
                IsLightTheme = false;
            }
            else
            {
                IsLightTheme = true;
            }
            logger.Info(IsLightTheme.ToString());


        }
    }
}
