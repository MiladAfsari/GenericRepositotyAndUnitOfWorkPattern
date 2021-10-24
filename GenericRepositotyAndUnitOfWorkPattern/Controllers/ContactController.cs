using GenericRepositotyAndUnitOfWorkPattern.Models;
using GenericRepositotyAndUnitOfWorkPattern.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepositotyAndUnitOfWorkPattern.Controllers
{
    public class ContactController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Contact> result = await _unitOfWork.Contact.All();
            return View(result);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Contact model)
        {
            if (!ModelState.IsValid) return View(model);

            await _unitOfWork.Contact.Add(model);
            await _unitOfWork.CompleteAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var contact = await _unitOfWork.Contact.GetById(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Contact contact)
        {
            if (!ModelState.IsValid) return View(contact);

            await _unitOfWork.Contact.Upsert(contact);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var contact = await _unitOfWork.Contact.GetById(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteContact(int id)
        {
            if (!ModelState.IsValid) return NotFound();
            var contact = await _unitOfWork.Contact.GetById(id);
            if (contact == null)
            {
                return NotFound();
            }

            await _unitOfWork.Contact.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction("Index");
        }
    }
}
