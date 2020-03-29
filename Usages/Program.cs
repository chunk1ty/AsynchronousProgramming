using System;
using System.Threading.Tasks;

namespace Usages
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            ReportingProgress.CallMyMethodAsync().GetAwaiter().GetResult();
        }
    }
}
