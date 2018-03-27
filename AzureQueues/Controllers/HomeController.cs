using System.Threading.Tasks;
using System.Web.Mvc;
using AzureQueuesModel;

namespace AzureQueuesDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {           
            return View();
        }

        public ActionResult PeekMessage()
        {
            var queuesBusiness = new AzureQueuesBusiness.AzureQueuesBusiness();
            var message = queuesBusiness.PeekMessageInQueue("test");

            return View(model:message==null ? "No Message Found !" : message.AsString);
        }

        public ActionResult GetLengthOfQueue()
        {
            var queuesBusiness = new AzureQueuesBusiness.AzureQueuesBusiness();
            var lengthofQueue = queuesBusiness.GetLengthofQueue("test");
            return View(model: lengthofQueue);
        }

        public ActionResult AddMessage()
        {
            return View(new Message());
        }
        [HttpPost]
        public ActionResult AddMessage(AzureQueuesModel.Message message)
        {
            if (ModelState.IsValid)
            {
                var azureQueues = new AzureQueuesBusiness.AzureQueuesBusiness();
                azureQueues.InsertMessage("test",message.MessageDetails);
            }

            return RedirectToAction("Index");
        }
    }
}