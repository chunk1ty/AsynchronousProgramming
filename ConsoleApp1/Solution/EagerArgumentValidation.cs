using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArgumentValidationExceptionHandling.Solution
{
    public class EagerArgumentValidation
    {
        // This method is the same as in LazyArgumentValidation;
        // only ComputeLengthAsync is different.
        public async Task LogicAsync()
        {
            Task<int> task = ComputeLengthAsync(null);
            Console.WriteLine("Fetched the task");
            int length = await task;
            Console.WriteLine("Length: {0}", length);
        }

        private Task<int> ComputeLengthAsync(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            return ComputeLengthAsyncImpl(text);
        }

        private async Task<int> ComputeLengthAsyncImpl(string text)
        {
            await Task.Delay(500);
            return text.Length;
        }
    }
}
