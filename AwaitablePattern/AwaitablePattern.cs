using System;
using System.Runtime.CompilerServices;

namespace AwaitablePattern
{
    public class MyAwaitableClass
    {
        public MyAwaiter GetAwaiter()
        {
            return new MyAwaiter();
        }
    }

    public class MyAwaiter : INotifyCompletion
    {
        public void GetResult()
        {
        }

        public bool IsCompleted
        {
            get { return true; }
        }

        //From INotifyCompletion
        public void OnCompleted(Action continuation)
        {
        }
    }
}
