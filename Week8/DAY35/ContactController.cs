using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using WebApplication4.Repositories;

namespace WebApplication4.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _repo;

        public ContactController(IContactRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View(_repo.GetAllContacts());
        }

        public IActionResult Details(int id)
        {
            return View(_repo.GetContactById(id));
        }

        public IActionResult Create()
        {
            LoadDropdowns();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                _repo.AddContact(contact);
                return RedirectToAction("Index");
            }

            LoadDropdowns();
            return View(contact);
        }

        public IActionResult Edit(int id)
        {
            LoadDropdowns();
            return View(_repo.GetContactById(id));
        }

        [HttpPost]
        public IActionResult Edit(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateContact(contact);
                return RedirectToAction("Index");
            }

            LoadDropdowns();
            return View(contact);
        }

        public IActionResult Delete(int id)
        {
            _repo.DeleteContact(id);
            return RedirectToAction("Index");
        }

        private void LoadDropdowns()
        {
            ViewBag.Companies = _repo.GetCompanies();
            ViewBag.Departments = _repo.GetDepartments();
        }
    }
}