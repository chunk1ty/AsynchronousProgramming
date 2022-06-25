using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;


const int MinWorkerThreads = 16;
const int MinIoThreads = 16;
// ThreadPool.SetMinThreads(MinWorkerThreads, MinIoThreads);
ThreadPool.SetMaxThreads(MinWorkerThreads, MinIoThreads);

//Task.Run(PrintComputerThreads);
Task.Run(PrintThreadPoolThreads);

// non blocking thread pool threads
//for (int i = 0; i < 8; i++)
//{
//    ThreadPool.QueueUserWorkItem(async async => await NonBlockingTaskMethod());
//}

// blocking thread pool threads
//for (int i = 0; i < 8; i++)
//{
//    ThreadPool.QueueUserWorkItem(_ => BlockingThreadOrTask());
//}

// blocking threads (non thread pool)
var threads = new List<Thread>();
for (int i = 0; i < 10; i++)
{
    threads.Add(new Thread(Work));
}

foreach (var item in threads)
{
    item.Start();
}

Console.ReadLine();

async Task PrintComputerThreads()
{
    while (true)
    {
        ProcessThreadCollection currentThreads = Process.GetCurrentProcess().Threads;

        foreach (ProcessThread thread in currentThreads)
        {
            Console.WriteLine($"thread id [{thread.Id}] - [{thread.ThreadState}]");
        }

        Console.WriteLine("=====================================================");
        await Task.Delay(2000);
    }
}

async Task PrintThreadPoolThreads()
{
    while (true)
    {
        int worker = 0;
        int io = 0;
        ThreadPool.GetAvailableThreads(out worker, out io);

        Console.WriteLine($"work threads: [{worker}] {io}");
        await Task.Delay(2000);
    }
}

async Task NonBlockingTaskMethod()
{
    await Task.Delay(10000);
    Console.WriteLine("Work completed");
}

void BlockingThreadOrTask()
{
    //Task.Delay(10000).GetAwaiter().GetResult();
    Thread.Sleep(10000);
    Console.WriteLine("Work completed");
}

void Work()
{
    Thread.Sleep(10000);
    Console.WriteLine("Work completed");

}