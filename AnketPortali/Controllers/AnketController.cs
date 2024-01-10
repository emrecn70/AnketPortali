using AnketPortali.Models;
using AnketPortali.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace AnketPortali.Controllers
{
    public class AnketController : Controller
    {
        private readonly AppDbContext _context;

        public AnketController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var degerler = _context.Ankets.ToList();
            return View(degerler);
        }

        public IActionResult AnketListAjax()
        {
            var anketModels = _context.Ankets.Select(x => new AnketModel()
            {
                Id = x.Id,
                Title = x.Title,
                Status = x.Status,
            }).ToList();

            return Json(anketModels);
        }
        public IActionResult AnketByIdAjax(int id)
        {
            var anketModel = _context.Ankets.Where(s => s.Id == id).Select(x => new AnketModel()
            {
                Id = x.Id,
                Title = x.Title,
                Status = x.Status,
            }).SingleOrDefault();

            return Json(anketModel);
        }

        [HttpPost]
        public IActionResult AnketAddEditAjax(AnketModel model)
        {
            var sonuc = new SonucModel();
            if (model.Id == 0)
            {

                if (_context.Ankets.Count(c => c.Title == model.Title) > 0)
                {
                    sonuc.Status = false;
                    sonuc.Message = "Girilen Başlık Kayıtlıdır!";
                    return Json(sonuc);
                }

                var anket = new Anket();
                anket.Title = model.Title;
                anket.Status = model.Status;
                _context.Ankets.Add(anket);
                _context.SaveChanges();
                sonuc.Status = true;
                sonuc.Message = "İşlem Eklendi";
            }
            else
            {
                var anket = _context.Ankets.FirstOrDefault(x => x.Id == model.Id);
                anket.Status = model.Status;
                anket.Title = model.Title;
                _context.SaveChanges();
                sonuc.Status = true;
                sonuc.Message = "İşlem Güncellendi";
            }

            return Json(sonuc);
        }
        public IActionResult AnketRemoveAjax(int id)
        {
            var anket = _context.Ankets.FirstOrDefault(x => x.Id == id);
            _context.Ankets.Remove(anket);
            _context.SaveChanges();

            var sonuc = new SonucModel();
            sonuc.Status = true;
            sonuc.Message = "İşlem Silindi";
            return Json(sonuc);
        }
    }
}
