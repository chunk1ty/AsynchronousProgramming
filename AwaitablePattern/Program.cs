namespace AwaitablePattern
{
    class Program
    {
        static async void Main(string[] args)
        {
            MyAwaitableClass awaitableObject = new MyAwaitableClass();

            await awaitableObject;
        }
    }
}
