using NLog.Common;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLog.WPF
{
    [Target("NLog.WPF")]
    public sealed class NlogViewerTarget : Target
    {
        public event Action<AsyncLogEventInfo> LogReceived;

        protected override void Write(NLog.Common.AsyncLogEventInfo logEvent)
        {
            base.Write(logEvent);
            LogReceived?.Invoke(logEvent);
        }
    }
}
