using System;
using System.Threading.Tasks;

namespace ArgumentValidationExceptionHandling.Problem
{
    public class LazyArgumentValidation
    {
        // Async method never directly throws an exception. Even if the first thing the method body does is throw an exception, it’ll return a faulted task. Suppose you want to do some work in an async method after validating that the parameters don’t have null values.   If you validate the parameters as you would in a normal synchronous code, the caller won’t have any indication of the problem until the task is awaited
        public async Task LogicAsync()
        {
            Task<int> task = ComputeLengthAsync(null);
            // The problem is that we are going to do some aditional work even that ComputeLengthAsync() throws an exception. 
            Console.WriteLine("Fetched the task");
            int length = await task;
            Console.WriteLine("Length: {0}", length);
        }

        // Async method never directly throws an exception. 
        private async Task<int> ComputeLengthAsync(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            await Task.Delay(500);

            return text.Length;
        }
    }
}
