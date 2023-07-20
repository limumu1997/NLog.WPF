using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Threading;
using NLog.Common;
using System;
using System.Linq;

namespace NLog.Avalonia;

public class NlogTextBox : TemplatedControl
{
    public event EventHandler ItemAdded = delegate { };

    public NlogTextBox()
    {
        if (!Design.IsDesignMode)
        {
            foreach (var target in LogManager.Configuration.AllTargets.Where(t => t is NlogViewerTarget).Cast<NlogViewerTarget>())
            {
                target.LogReceived += LogReceived;
            }
        }
    }

    protected void LogReceived(AsyncLogEventInfo log)
    {
        Dispatcher.UIThread.InvokeAsync(new Action(() =>
        {
            string msg = FormattedMessage(log.LogEvent);
            ShowMsg(msg);
            ItemAdded(this, (NLogEvent)log.LogEvent);
        }));
    }

    private string FormattedMessage(LogEventInfo logEventInfo)
    {
        var Time = logEventInfo.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss.fff");
        var LoggerName = logEventInfo.LoggerName;
        var Level = logEventInfo.Level.ToString();
        var Message = logEventInfo.Message;
        return $"{Time} [{Level}] {Message}";
    }

    private void ShowMsg(string msg)
    {

    }

    public void ClearMsg()
    {

    }
}