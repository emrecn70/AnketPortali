using AnketPortali.Models;
using AnketPortali.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AnketPortali.Controllers
{
    public class SoruController : Controller
    {
        private readonly AppDbContext _context;

        public SoruController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public IActionResult Index()
        {
            var sorusModel = _context.Sorus.Select(x => new SoruModel()
            {
                Id = x.Id,
                Question = x.Question,
                Description = x.Description,


            }).ToList();
            return View(sorusModel);
        }
        public IActionResult Detail(int id)
        {
            var soruModel = _context.Sorus.Select(x => new SoruModel()
            {
                Id = x.Id,
                Question = x.Question,
                Description = x.Description,


            }).SingleOrDefault(x => x.Id == id);
            return View(soruModel);

        }
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(SoruModel model)
        {
            var soru = new Soru();
            soru.Question = model.Question;
            soru.Description = model.Description;


            _context.Sorus.Add(soru);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var soruModel = _context.Sorus.Select(x => new SoruModel()
            {
                Id = x.Id,
                Question = x.Question,
                Description = x.Description,


            }).SingleOrDefault(x => x.Id == id);
            return View(soruModel);
        }

        [HttpPost]
        public IActionResult Edit(SoruModel model)
        {
            var soru = _context.Sorus.SingleOrDefault(x => x.Id == model.Id);
            soru.Question = model.Question;
            soru.Description = model.Description;


            _context.Sorus.Update(soru);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var soruModel = _context.Sorus.Select(x => new SoruModel()
            {
                Id = x.Id,
                Question = x.Question,
                Description = x.Description,


            }).SingleOrDefault(x => x.Id == id);
            return View(soruModel);
        }

        [HttpPost]
        public IActionResult Delete(SoruModel model)
        {
            var soru = _context.Sorus.SingleOrDefault(x => x.Id == model.Id);
            _context.Sorus.Remove(soru);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
