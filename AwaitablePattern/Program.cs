using System;
using System.Threading.Tasks;

namespace AwaitablePattern
{
    class Program
    {
        static  void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();           
        }

        public static async Task MainAsync(string[] args)
        {
            MyAwaitableClass awaitableObject = new MyAwaitableClass();
            await awaitableObject;

            await TimeSpan.FromSeconds(15);

            Console.WriteLine("End");
        }
    }
}
