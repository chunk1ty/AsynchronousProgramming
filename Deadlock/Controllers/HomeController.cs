using System.Threading.Tasks;
using System.Web.Mvc;

namespace Deadlock.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> About()
        {
            ViewBag.Message = "Your application description page.";
            // .Wait() is the same blocking operation but "recommended" way to block is .GetAwaiter().GetResult() (behind the scenes compiler use it)
            
            // 1) Someone calls AsyncOperation() (within the UI/ASP.NET context! in Asp.Net Core and Console.App there is NOT SynchronisationContext)
            // 2) AsyncOperation() starts an async request for Task.Delay()
            // 3) Task.Delay() return not complete task
            // 4) Now I am waiting that task to complete. The context is captured at this point and will be used to restore the task at some point.
            // 5) AsyncOperation().GetAwaiter().GetResult() synchronously blocks on the Task returned by AsyncOperation(). This blocks the restoration of the context.
            // 6) At some point in the future Task.Delay finishes. This complete the task.
            // 7) The continuation for the task is now ready to run, but must wait for the context to be available so it can execute in the context.
            // 8) Deadlock. AsyncOperation().GetAwaiter().GetResult() is blocking the context thread, waiting for AsyncOperation to complete
            //              AsyncOperation() is waiting for the context to be free so it can complete.
            var str =  AsyncOperation().GetAwaiter().GetResult();

            return View();
        }

        private async Task<int> AsyncOperation()
        {
           // Worker 1
           await Task.Delay(5);  // .ConfigureAwait(false) prevents deadlock 

            return 5;
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}