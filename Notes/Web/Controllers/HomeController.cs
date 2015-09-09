using System.Web.Mvc;
using Services;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly INotesService _notesService;

        public HomeController(INotesService notesService)
        {
            _notesService = notesService;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}