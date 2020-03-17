using ArgumentValidationExceptionHandling.Solution;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            //var lazyArgumentValidation = new LazyArgumentValidation();
            //lazyArgumentValidation.LogicAsync().GetAwaiter().GetResult();

            var eagerArgumentValidation = new EagerArgumentValidation();
            eagerArgumentValidation.LogicAsync().GetAwaiter().GetResult();
        }
    }
}
