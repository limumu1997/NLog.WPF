using NLog.Common;
using NLog.Fluent;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace NLog.WPF
{
    /// <summary>
    /// NlogRichTextBox.xaml 的交互逻辑
    /// </summary>
    public partial class NlogRichTextBox : UserControl
    {
        public event EventHandler ItemAdded = delegate { };

        public static readonly ICommand ClearCommand = new RoutedCommand("Clear", typeof(NlogRichTextBox));


        /// <summary>
        /// Property for <see cref="IsLightThemeProperty"/>.
        /// </summary>
        public static readonly DependencyProperty IsLightThemeProperty =
            DependencyProperty.Register(
                nameof(IsLightTheme),
                typeof(bool),
                typeof(NlogRichTextBox),
                new FrameworkPropertyMetadata(false, (d, e) =>
                {
                    var nlogRichTextBox = (NlogRichTextBox)d;
                    nlogRichTextBox._isLightTheme = (bool)e.NewValue;
                })
            );

        private bool _isLightTheme;
        public bool IsLightTheme
        {
            get => (bool)GetValue(IsLightThemeProperty);
            set => SetValue(IsLightThemeProperty, value);
        }

        private int _MaxRowCount = 200;
        [Description("Document Max count."), Category("Data")]
        [TypeConverter(typeof(Int32Converter))]
        public int MaxRowCount
        {
            get { return _MaxRowCount; }
            set { _MaxRowCount = value; }
        }

        public NlogRichTextBox()
        {
            InitializeComponent();
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                foreach (var target in LogManager.Configuration.AllTargets.Where(t => t is NlogViewerTarget).Cast<NlogViewerTarget>())
                {
                    target.LogReceived += LogReceived;
                }
            }
            CommandBindings.Add(new CommandBinding(ClearCommand, ClearCommand_Executed));
        }

        protected void LogReceived(AsyncLogEventInfo log)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                SetupColors(log.LogEvent);
                FormattedMessage(log.LogEvent);
                ItemAdded(this, (NLogEvent)log.LogEvent);
            }));
        }

        private void FormattedMessage(LogEventInfo logEventInfo)
        {
            var Time = logEventInfo.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var LoggerName = logEventInfo.LoggerName;
            var Level = logEventInfo.Level.ToString();
            var Message = logEventInfo.Message;
            var LogMsg = $"{Time} [{Level}] {Message}";
            ShowMsg(LogMsg);
        }

        private void ShowMsg(string msg)
        {
            if (richTextBox1.Document.Blocks.Count > MaxRowCount)
            {
                ClearMsg();
            }
            this.richTextBox1.AppendText(msg);
            if (!msg.EndsWith(Environment.NewLine))
            {
                this.richTextBox1.AppendText(Environment.NewLine);
            }
            richTextBox1.ScrollToEnd();
        }

        public void ClearMsg()
        {
            richTextBox1.Document.Blocks.Clear();
        }

        private void ClearCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ClearMsg();
        }

        private void SetupColors(LogEventInfo logEventInfo)
        {
            // 获取最后一个段落
            if (richTextBox1.Document.Blocks.LastBlock is not Paragraph lastParagraph)
                return;

            if (logEventInfo.Level == LogLevel.Warn)
            {
                lastParagraph.Foreground = Brushes.Orange;
            }
            else if (logEventInfo.Level == LogLevel.Error)
            {
                lastParagraph.Foreground = Brushes.Tomato;
            }
            else if (logEventInfo.Level == LogLevel.Debug)
            {
                lastParagraph.Foreground = Brushes.LightGray;
            }
            else
            {
                if (_isLightTheme)
                {
                    lastParagraph.Foreground = Brushes.Black;
                }
            }

        }

    }
}
