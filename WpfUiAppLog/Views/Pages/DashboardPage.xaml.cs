// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;
using WpfUiAppLog.ViewModels.Pages;

namespace WpfUiAppLog.Views.Pages
{
    public partial class DashboardPage //: INavigableView<DashboardViewModel>
    {

        public DashboardPage()
        {
            var viewModel = new DashboardViewModel();
            DataContext = viewModel;

            InitializeComponent();
        }

    }
}
