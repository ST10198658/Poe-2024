using Microsoft.AspNetCore.Mvc;
using Poe.Models;
using System.Diagnostics;

namespace Poe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PoeDbContext _context;

        public HomeController(ILogger<HomeController> logger, PoeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Invoice()
        {
            var allLecturer = _context.Lecturers.ToList();

            var totalRate = allLecturer.Sum(x => x.Rate);

            ViewBag.Lecturer = totalRate;

            return View(allLecturer);
        }
        public IActionResult EditInvoice(int? id)
        {
            if (id == null)
            {
                var lecturerInDb = _context.Lecturers.FirstOrDefault(lecturer => lecturer.Id == id);
                return View(lecturerInDb);
            }           

            return View();
        }
        public IActionResult DeleteInvoice(int id)
        {
            var lecturerInDb = _context.Lecturers.FirstOrDefault(lecturer => lecturer.Id == id);
            _context.Lecturers.Remove(lecturerInDb);
            _context.SaveChanges();
            return RedirectToAction("Invoice");
        }
        public IActionResult EditInvoiceForm(Lecturer model)
        {
            if(0 == model.Id)
            {
                //create
                _context.Lecturers.Add(model);
            }
            else
            {
                //edit
                _context.Lecturers.Update(model);
            }


            _context.SaveChanges();

            return RedirectToAction("Invoice");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
