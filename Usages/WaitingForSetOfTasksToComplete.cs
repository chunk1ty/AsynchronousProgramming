using System;
using System.Threading.Tasks;

namespace Usages
{
    //Problem
    //You have several tasks and need to wait for them all to complete.

    //Solution
    //The framework provides a Task.WhenAll method for this purpose.This method takes
    //several tasks and returns a task that completes when all of those tasks have completed
    public class WaitingForSetOfTasksToComplete
    {
        static async Task WaitMultipleTasks()
        {
            Task task1 = Task.Delay(TimeSpan.FromSeconds(1));
            Task task2 = Task.Delay(TimeSpan.FromSeconds(2));
            Task task3 = Task.Delay(TimeSpan.FromSeconds(1));

            await Task.WhenAll(task1, task2, task3);

            // If all the tasks have the same result type and they all complete successfully, then the
            // Task.WhenAll task will return an array containing all the task results:

            // Task task1 = Task.FromResult(3);
            // Task task2 = Task.FromResult(5);
            // Task task3 = Task.FromResult(7);
            // int[] results = await Task.WhenAll(task1, task2, task3);
            // "results" contains { 3, 5, 7 }
        }

        //Most of the time, I do not observe all the exceptions when using Task.WhenAll. It is
        //usually sufficient to just respond to the first error that was thrown, rather than all of them.
        static async Task ObserveAllExceptionsAsync()
        {
            var task1 = ThrowNotImplementedExceptionAsync();
            var task2 = ThrowInvalidOperationExceptionAsync();
            Task allTasks = Task.WhenAll(task1, task2);

            try
            {
                await allTasks;
            }
            catch
            {
                AggregateException allExceptions = allTasks.Exception;
                // ...
            }
        }

        static async Task ThrowNotImplementedExceptionAsync()
        {
            throw new NotImplementedException();
        }
        static async Task ThrowInvalidOperationExceptionAsync()
        {
            throw new InvalidOperationException();
        }
    }
}
