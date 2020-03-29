using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Usages
{
    //Problem
    //You have several tasks and need to respond to just one of them completing.The most
    //common situation for this is when you have multiple independent attempts at an operation,
    //with a first-one-takes-all kind of structure. For example, you could request stock
    //quotes from multiple web services simultaneously, but you only care about the first one
    //that responds.
    
    //Solution
    //Use the Task.WhenAny method. This method takes a sequence of tasks and returns a
    //task that completes when any of the tasks complete.The result of the returned task is
    //the task that completed.
    public class WaitingForAnyTaskToComplete
    {
        private static async Task<int> FirstRespondingUrlAsync(string urlA, string urlB)
        {
            var httpClient = new HttpClient();
            // Start both downloads concurrently.
            Task<byte[]> downloadTaskA = httpClient.GetByteArrayAsync(urlA);
            Task<byte[]> downloadTaskB = httpClient.GetByteArrayAsync(urlB);
            // Wait for either of the tasks to complete.
            Task<byte[]> completedTask =
                await Task.WhenAny(downloadTaskA, downloadTaskB);
            // Return the length of the data retrieved from that URL.
            byte[] data = await completedTask;
            return data.Length;
        }

        public static async Task SolveQuizForPeriodOfTime()
        {
            Console.WriteLine("You have 5 seconds to solve this: 111 * 111");

            var inputTask = Task.Run(() =>
            {
                while (true)
                {
                    var input = Console.ReadLine();

                    if (input == "12321")
                    {
                        Console.WriteLine("Correct!");
                        break;
                    }

                    Console.WriteLine("Wrong answer!");
                }
            });

            var timerTask = Task.Run(async () =>
            {
                for (var i = 5; i > 0; i--)
                {
                    Console.WriteLine(i);

                    await Task.Delay(1000);
                }
            });

            await Task.WhenAny(inputTask, timerTask);
        }
    }
}
