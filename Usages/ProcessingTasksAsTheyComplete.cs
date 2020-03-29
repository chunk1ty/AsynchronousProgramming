using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usages
{
    //Problem
    //You have a collection of tasks to await, and you want to do some processing on each
    //task after it completes.However, you want to do the processing for each one as soon as
    //it completes, not waiting for any of the other tasks.

    //Solution
    //The easiest solution is to restructure the code by introducing a higher-level async
    //method that handles awaiting the task and processing its result. Once the processing is
    //factored out, the code is significantly simplified:
    public class ProcessingTasksAsTheyComplete
    {
       
        // This method now prints "1", "2", and "3".
        static async Task ProcessTasksAsync()
        {
            // Create a sequence of tasks.
            Task<int> taskA = DelayAndReturnAsync(2);
            Task<int> taskB = DelayAndReturnAsync(3);
            Task<int> taskC = DelayAndReturnAsync(1);

            var tasks = new[] { taskA, taskB, taskC };

            var processingTasks = tasks.Select(async t =>
            {
                var result = await t;
                Console.WriteLine(result);
                Console.WriteLine("foo");
            }).ToArray();

            // Await all processing to complete
            await Task.WhenAll(processingTasks);
        }

        static async Task<int> DelayAndReturnAsync(int val)
        {
            await Task.Delay(TimeSpan.FromSeconds(val));
            return val;
        }
    }
}
