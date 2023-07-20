using NLog.Common;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLog.Avalonia
{
    [Target("NLog.Avalonia")]
    public sealed class NlogViewerTarget : Target
    {
        public event Action<AsyncLogEventInfo>? LogReceived;

        protected override void Write(AsyncLogEventInfo logEvent)
        {
            base.Write(logEvent);
            LogReceived?.Invoke(logEvent);
        }
    }
}
