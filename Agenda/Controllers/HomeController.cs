using Agenda.Models;
using Agenda.repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Agenda.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repo;

        public HomeController(IRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_repo.GetPeople());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add([Bind("idCusmtomer,Name,Firstname,Cell,Email,Country,CreationDate")] People people) {
            if (ModelState.IsValid){
                _repo.AddPeople(people);
                return RedirectToAction(nameof(Index));
            }
            return View(people);
        }

        [HttpGet]
        public IActionResult Edit(int? id) {
            var cliente = _repo.GetPeople(id.GetValueOrDefault());
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("idCusmtomer,Name,Firstname,Cell,Email,Country,CreationDate")] People people)
        {
            if (id != people.idCusmtomer)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _repo.UpdatePeople(people);
                return RedirectToAction(nameof(Index));
            }
            return View(people);
        }

        [HttpGet]
        public IActionResult Delete(int? id) {
            
            if(id == null)
            {
                return NotFound();
            }
            _repo.DeletePeople(id.GetValueOrDefault());
            return RedirectToAction(nameof(Index)); ;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}