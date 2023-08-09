using System.Windows;
using System.Windows.Controls;

namespace NLog.WPF
{
    /// <summary>
    /// WpfUiRichTextBox.xaml 的交互逻辑
    /// </summary>
    public partial class RichTextBox : System.Windows.Controls.RichTextBox
    {
        /// <summary>
        /// Property for <see cref="IsTextSelectionEnabledProperty"/>.
        /// </summary>
        public static readonly DependencyProperty IsTextSelectionEnabledProperty =
            DependencyProperty.Register(
                nameof(IsTextSelectionEnabled),
                typeof(bool),
                typeof(RichTextBox),
                new PropertyMetadata(false)
            );

        /// <summary>
        /// TODO
        /// </summary>
        public bool IsTextSelectionEnabled
        {
            get => (bool)GetValue(IsTextSelectionEnabledProperty);
            set => SetValue(IsTextSelectionEnabledProperty, value);
        }


    }
}
