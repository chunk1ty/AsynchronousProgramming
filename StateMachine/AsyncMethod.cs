using System;
using System.Threading.Tasks;

namespace StateMachine
{
    class AsyncMethod
    {
        static void Main(string[] args)
        {
            //PrintAndWait(TimeSpan.FromSeconds(1)).Wait();

            AsyncMethodDecompiled.MainAsync();

            
        }

        static async Task PrintAndWait(TimeSpan delay)
        {
            Console.WriteLine("Before first delay");
            await Task.Delay(delay);
            Console.WriteLine("Between delays");
            await Task.Delay(delay);
            Console.WriteLine("After second delay");
        }
    }
}
