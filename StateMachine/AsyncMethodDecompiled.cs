using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace StateMachine
{
    public class AsyncMethodDecompiled
    {
        public static void MainAsync()
        {
            PrintAndWait(TimeSpan.FromSeconds(60)).Wait();
        }

        [AsyncStateMachine(typeof(PrintAndWaitStateMachine))]
        [DebuggerStepThrough]
        private static Task PrintAndWait(TimeSpan delay)
        {
            var machine = new PrintAndWaitStateMachine
            {
                delay = delay,
                builder = AsyncTaskMethodBuilder.Create(),
                state = -1
            };
            machine.builder.Start(ref machine);
            return machine.builder.Task;
        }

        [CompilerGenerated]
        private struct PrintAndWaitStateMachine : IAsyncStateMachine
        {
            public int state;
            public AsyncTaskMethodBuilder builder;
            private TaskAwaiter awaiter;
            public TimeSpan delay;

            void IAsyncStateMachine.MoveNext()
            {
                int num = state;
                try
                {
                    TaskAwaiter awaiter1;
                    switch (num)
                    {
                        default:
                            goto MethodStart;
                        case 0:
                            goto FirstAwaitContinuation;
                        case 1:
                            goto SecondAwaitContinuation;
                    }
                MethodStart:
                    Console.WriteLine("Before first delay");
                    awaiter1 = Task.Delay(delay).GetAwaiter();
                    if (awaiter1.IsCompleted)
                    {
                        goto GetFirstAwaitResult;
                    }
                    state = num = 0;
                    awaiter = awaiter1;
                    builder.AwaitUnsafeOnCompleted(ref awaiter1, ref this);
                    return;
                FirstAwaitContinuation:
                    awaiter1 = awaiter;
                    awaiter = default(TaskAwaiter);
                    state = num = -1;
                GetFirstAwaitResult:
                    awaiter1.GetResult();
                    Console.WriteLine("Between delays");
                    TaskAwaiter awaiter2 = Task.Delay(delay).GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto GetSecondAwaitResult;
                    }
                    state = num = 1;
                    awaiter = awaiter2;
                    builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
                    return;
                SecondAwaitContinuation:
                    awaiter2 = awaiter;
                    awaiter = default(TaskAwaiter);
                    state = num = -1;
                GetSecondAwaitResult:
                    awaiter2.GetResult();
                    Console.WriteLine("After second delay");
                }
                catch (Exception exception)
                {
                    state = -2;
                    builder.SetException(exception);
                    return;
                }
                state = -2;
                builder.SetResult();
            }

            [DebuggerHidden]
            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.builder.SetStateMachine(stateMachine);
            }
        }
    }
}
