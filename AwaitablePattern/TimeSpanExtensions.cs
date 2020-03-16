using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AwaitablePattern
{
    public static class TimeSpanExtensions
    {
        public static TaskAwaiter GetAwaiter(this TimeSpan timeSpan)
        {
            return TaskEx.Delay(timeSpan).GetAwaiter();
        }
    }
}
