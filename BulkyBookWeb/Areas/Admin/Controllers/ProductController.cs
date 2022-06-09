using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<CoverType> objList = _unitOfWork.CoverType.GetAll();
            return View(objList);
        }

        // GET 
        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            {
                Product = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(
                    x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }
                ),
                CoverTypeList = _unitOfWork.CoverType.GetAll().Select(
                    x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }
                )
            };

            if (id == null || id == 0)
            {
                // create product
                return View(productVM);
            }
            else
            {
                // update product
            }

            return View(productVM);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Cover Type updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET 
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var objFromDb = _unitOfWork.CoverType.GetFirstOrDefault(x => x.Id == id);
            if (objFromDb == null)
            {
                return NotFound();
            }

            return View(objFromDb);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.CoverType.GetFirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.CoverType.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Cover Type deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
