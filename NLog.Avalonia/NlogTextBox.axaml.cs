using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Threading;
using NLog.Common;
using System;
using System.Linq;
using Avalonia;

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
    
    public event EventHandler ItemAdded = delegate { };

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
        Dispatcher.UIThread.InvokeAsync(new Action(() =>
        {
            var msg = FormattedMessage(log.LogEvent);
            ShowMsg(msg);
            ItemAdded(this, (NLogEvent)log.LogEvent);
        }));
    }

    private static string FormattedMessage(LogEventInfo logEventInfo)
    {
        var time = logEventInfo.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss.fff");
        var loggerName = logEventInfo.LoggerName;
        var level = logEventInfo.Level.ToString();
        var message = logEventInfo.Message;
        return $"{time} [{level}] {message}";
    }

    private static void ShowMsg(string msg)
    {

    }

    public void ClearMsg()
    {

    }
}