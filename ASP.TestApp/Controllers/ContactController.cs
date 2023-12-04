using ASP.DataAccess.Repository.IRepository;
using ASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ContactController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var objProductList = _unitOfWork.Contact.GetAll();

            return View(objProductList);
        }

        public IActionResult UpSert(int? id)
        {
            var contact = new Contact();
            if (id == null || id == 0)
            {
                return View(contact);
            }
            else
            {
                contact = _unitOfWork.Contact.Get(u => u.Id == id);
                return View(contact);
            }
        }
        public IActionResult View(int id)
        {
            Contact contact = _unitOfWork.Contact.Get(u => u.Id == id);

            if (contact == null)
            {

                return NotFound();
            }

            return View(contact);
        }

        [HttpPost]
        public IActionResult Upsert(Contact contact, IFormFile? file)
        {
            if (ModelState.IsValid)
            {

                if (contact.Id == 0)
                {
                    _unitOfWork.Contact.Add(contact);
                }
                else
                {
                    _unitOfWork.Contact.Update(contact);
                }
                _unitOfWork.Save();
                TempData["success"] = "Contact created successfully";
                return RedirectToAction("Index");

            }
            else
            {
                contact = new Contact();
                return View(contact);
            }

        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Contact.Update(contact);
                _unitOfWork.Save();
                TempData["success"] = "Contact updated successfully";
                return RedirectToAction("Index");

            }
            return View();
        }
        #region ApiCalls
        [HttpGet]
        public IActionResult GetAll()
        {
            var objContactList = _unitOfWork.Contact.GetAll();
            return Json(new { data = objContactList });
        }

        public IActionResult Delete(int? id)
        {
            var productForDelete = _unitOfWork.Contact.Get(u => u.Id == id);
            if (productForDelete == null)
            {
                return Json(new { success = false, message = "Error while downloading" });
            }
            _unitOfWork.Contact.Remove(productForDelete);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}
