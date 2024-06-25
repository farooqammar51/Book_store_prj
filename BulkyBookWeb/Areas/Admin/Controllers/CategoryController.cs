using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            //IEnumerable<Category> categoryList = _unitOfWork.Category.GetAll();
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Category obj = new Category();
            if (id == null || id == 0)
            {
                //create category
                return View(obj);
            }
            else
            {
                //update category
                var categoryobj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
                return View(categoryobj);
            }
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name cannot be the same as the Display Order");
            }
            if(ModelState.IsValid)
            {
                if(obj.Id == 0)
                {
                    _unitOfWork.Category.Add(obj);
                    TempData["success"] = "Category Added Successfully";
                }
                else
                {
                    _unitOfWork.Category.Update(obj);
                    TempData["success"] = "Category Updated Successfully";
                }
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            return View(obj);
        }

        #region APICALLS
        [HttpGet]
        public IActionResult GetCategory() 
        {
            var categoryList = _unitOfWork.Category.GetAll();
            return Json(new { data = categoryList });
        }

        //POST
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new {success = false, message = "An error occured while deleting"});
            }
            else
            {
                _unitOfWork.Category.Remove(obj);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Delete Successful" });
            }
        }
        #endregion
    }
}
