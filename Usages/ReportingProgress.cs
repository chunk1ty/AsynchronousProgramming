using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Usages
{
    public class ReportingProgress
    {
        // Problem
        // You need to respond to progress while an asynchronous operation is executing.

        // Solution
        // Use the provided IProgress<T> and Progress<T> types.
        static async Task MyMethodAsync(IProgress<int> progress = null)
        {
            for (int i = 0; i < 100; i++)
            {
                await Task.Delay(100);

                if (progress != null)
                {
                    progress.Report(i);
                }
            }
        }

        static async Task CallMyMethodAsync()
        {
            //var progress = new Progress<int>();

            //progress.ProgressChanged += (sender, args) =>
            //{
            //    Console.WriteLine(args + "%");
            //};

            var progress = new Progress<int>(percent =>
            {
                Console.WriteLine(percent + "%");
            });

            await MyMethodAsync(progress);
        }
    }
}
