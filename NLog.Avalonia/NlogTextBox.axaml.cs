using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Threading;
using NLog.Common;
using System;
using System.Linq;
using Avalonia;
using Avalonia.Interactivity;

namespace NLog.Avalonia;

public class NlogTextBox : TemplatedControl
{
    // styledP auto generate
    public static readonly StyledProperty<int> NlogHeightProperty = AvaloniaProperty.Register<NlogTextBox, int>(
        nameof(NlogHeight));

    public int NlogHeight
    {
        get => GetValue(NlogHeightProperty);
        set => SetValue(NlogHeightProperty, value);
    }

    private static readonly RoutedEvent<RoutedEventArgs> ValueChangedEvent =
        RoutedEvent.Register<NlogTextBox, RoutedEventArgs>(nameof(ValueChanged), RoutingStrategies.Bubble);

    public event EventHandler<RoutedEventArgs> ValueChanged
    {
        add => AddHandler(ValueChangedEvent, value);
        remove => RemoveHandler(ValueChangedEvent, value);
    }

    protected virtual void OnValueChanged()
    {
        RoutedEventArgs args = new RoutedEventArgs(ValueChangedEvent);
        RaiseEvent(args);
    }
    
    public event EventHandler ItemAdded = delegate { };

    private TextBox? _textBox;

    public NlogTextBox()
    {
        if (Design.IsDesignMode) return;
        foreach (var target in LogManager.Configuration.AllTargets.Where(t => t is NlogViewerTarget).Cast<NlogViewerTarget>())
        {
            target.LogReceived += LogReceived;
        }
    }

    private void LogReceived(AsyncLogEventInfo log)
    {
        Dispatcher.UIThread.InvokeAsync(() =>
        {
            var msg = FormattedMessage(log.LogEvent);
            ShowMsg(msg);
            ItemAdded(this, (NLogEvent)log.LogEvent);
        });
    }

    private static string FormattedMessage(LogEventInfo logEventInfo)
    {
        var time = logEventInfo.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss.fff");
        var loggerName = logEventInfo.LoggerName;
        var level = logEventInfo.Level.ToString();
        var message = logEventInfo.Message;
        return $"{time} [{level}] {message}";
    }

    private void ShowMsg(string msg)
    {
        if (_textBox != null) _textBox.Text = _textBox.Text + Environment.NewLine + msg;
    }

    public void ClearMsg()
    {
        _textBox!.Text = "";
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        _textBox = e.NameScope.Find<TextBox>("textBox1");
    }
}