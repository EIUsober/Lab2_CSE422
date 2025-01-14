using Lab2_NguyenTruongGiang_CSE422.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab2_NguyenTruongGiang_CSE422.Controllers
{
    public class DeviceCategoryController : Controller
    {
        private static List<DeviceCategory> _categories = new List<DeviceCategory>();

        public IActionResult Index()
        {
            return View(_categories);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(DeviceCategory category)
        {
            if (ModelState.IsValid)
            {
                category.Id = _categories.Count + 1;
                _categories.Add(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Edit(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(DeviceCategory category)
        {
            var existingCategory = _categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory != null && ModelState.IsValid)
            {
                existingCategory.Name = category.Name;
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                _categories.Remove(category);
            }
            return RedirectToAction("Index");
        }
    }
}
