﻿using ASP.Net.Models;
using ASP.Net.Models.ViewModels;
using ASP.Net.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Packaging.Signing;

namespace ASP.Net.Areas.Admin.Controllers
{
        [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
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
                productVM.Product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
                return View(productVM);
            }
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductViewModel obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\products");
                    var extension = Path.GetExtension(file.FileName);

                    if (obj.Product.ImageURL != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.Product.ImageURL.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.Product.ImageURL = @"\images\products\" + fileName + extension;
                }

                if (obj.Product.Id == 0)
                {
                    _unitOfWork.Product.Add(obj.Product);
                }
                else
                {
                    _unitOfWork.Product.Update(obj.Product);
                }
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _unitOfWork.Product.GetAll(includeProperties: "Category,CoverType");
            return Json(new { data = productList });
        }

        // POST
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.ImageURL.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });
        }
    
        #endregion
        
    }
}