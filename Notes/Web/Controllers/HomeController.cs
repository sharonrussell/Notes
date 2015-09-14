using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Services;
using Web.Models.Home;

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
            IEnumerable<NoteDto> notesDtos = _notesService.GetAllNotes();

            List<NoteViewModel> viewModels = notesDtos.Select(notesDto => new NoteViewModel
            {
                Id = notesDto.Id, 
                Text = notesDto.Text
            }).ToList();


            return View(viewModels);
        }

        [HttpGet]
        public ActionResult Add()
        {
            NoteViewModel model = new NoteViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(NoteViewModel model)
        {
            _notesService.AddNote(model.Text);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _notesService.DeleteNote(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var noteDto = _notesService.GetNote(id);

            var model = new NoteViewModel
            {
                Text = noteDto.Text,
                Id = noteDto.Id
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(NoteViewModel model)
        {
            NoteDto noteDto = new NoteDto
            {
                Id = model.Id,
                Text = model.Text
            };

            _notesService.EditNote(noteDto);

            return RedirectToAction("Index");
        }
    }
}