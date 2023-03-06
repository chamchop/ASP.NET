using ASP.Net.Models;
using ASP.Net.Models.ViewModels;
using ASP.Net.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP.Net.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> objProductList = _unitOfWork.Product.GetAll();
            return View(objProductList);
        }

        // GET
        public IActionResult Upsert(int? id)
        {

            ProductViewModel productVM = new()
            {
                Product = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(
                category => new SelectListItem
                {
                    Text = category.Name,
                    Value = category.Id.ToString(),
                }),

            CoverTypeList = _unitOfWork.CoverType.GetAll().Select(
                cover => new SelectListItem
                {
                    Text = cover.Name,
                    Value = cover.Id.ToString(),
                }),
            };

            if (id == null || id == 0)
            {
                return View(productVM);
            }
            else
            {

            }

            return View(productVM);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductViewModel obj, IFormFile file)
        {
            if (ModelState.IsValid)
            {
/*                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();*/
                TempData["success"] = "Procuct edited successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var productFromDbFirst = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);

            if (productFromDbFirst == null)
            {
                return NotFound();
            }
            return View(productFromDbFirst);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {

            var obj = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["error"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
