using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Threading;
using NLog.Common;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

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
        //if (textBox1.Document.Blocks.Count > MaxRowCount)
        //{
        //    ClearMsg();
        //}
        //this.textBox1.AppendText(msg);
        //if (!msg.EndsWith(Environment.NewLine))
        //{
        //    this.textBox1.AppendText(Environment.NewLine);
        //}
        //textBox1.ScrollToEnd();
    }

    public void ClearMsg()
    {
        
    }

}