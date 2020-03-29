using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Usages
{
    // Problem
    // You need to(asynchronously) wait for a period of time.This can be useful when unit
    // testing or implementing retry delays. This solution can also be useful for simple timeouts.

    // Solution
    // The Task type has a static method Delay that returns a task that completes after the
    // specified time.
    public class PausingForPeriodOfTime
    {
        static async Task<T> DelayResult<T>(T result, TimeSpan delay)
        {
            await Task.Delay(delay);
            return result;
        }

        // simple implementation of an exponential backoff
        static async Task<string> DownloadStringWithRetries(string uri)
        {
            using (var client = new HttpClient())
            {
                // Retry after 1 second, then after 2 seconds, then 4.
                var nextDelay = TimeSpan.FromSeconds(1);
                for (int i = 0; i != 3; ++i)
                {
                    try
                    {
                        return await client.GetStringAsync(uri);
                    }
                    catch
                    {
                    }
                    await Task.Delay(nextDelay);
                    nextDelay = nextDelay + nextDelay;
                }
                // Try one last time, allowing the error to propogate.
                return await client.GetStringAsync(uri);
            }
        }

        // simple implementation of an timeout;
        static async Task<string> DownloadStringWithTimeout(string uri)
        {
            using (var client = new HttpClient())
            {
                var downloadTask = client.GetStringAsync(uri);
                var timeoutTask = Task.Delay(3000);
                var completedTask = await Task.WhenAny(downloadTask, timeoutTask);
                if (completedTask == timeoutTask)
                    return null;
                return await downloadTask;
            }
        }
    }
}
