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
        private static readonly List<AsyncLogEventInfo> asyncLogEventInfos = new();
        public static List<AsyncLogEventInfo> CachedLogs = asyncLogEventInfos;

        public event Action<AsyncLogEventInfo> LogReceived;

        protected override void Write(NLog.Common.AsyncLogEventInfo logEvent)
        {
            base.Write(logEvent);
            if (LogReceived == null)
            {
                CachedLogs.Add(logEvent);
            }
            LogReceived?.Invoke(logEvent);
        }
    }
}
