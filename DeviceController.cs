using Lab2_NguyenTruongGiang_CSE422.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Lab2_NguyenTruongGiang_CSE422.Controllers
{
    public class DeviceController : Controller
    {
        private static List<Device> _devices = new List<Device>();
        private static List<DeviceCategory> _categories = new List<DeviceCategory>
        {
            new DeviceCategory { Id = 1, Name = "Computer" },
            new DeviceCategory { Id = 2, Name = "Printer" },
            new DeviceCategory { Id = 3, Name = "Phone" }
        };

        private readonly ILogger<DeviceController> _logger;
        public DeviceController(ILogger<DeviceController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_devices);
        }

        public IActionResult Add()
        {
            ViewBag.Categories = _categories.Select(c => c.Name).ToList();
            var model = new Device();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Device device)
        {
            _logger.LogInformation("Add action called.");
            if (ModelState.IsValid)
            {
                device.Id = _devices.Count + 1;
                _devices.Add(device);
                return RedirectToAction("Index");
            }
            else
            {
                _logger.LogWarning("ModelState is not valid.");
            }
            ViewBag.Categories = _categories.Select(c => c.Name).ToList();
            return View(device);
        }

        public IActionResult Edit(int id)
        {
            var device = _devices.FirstOrDefault(d => d.Id == id);
            if (device == null)
            {
                return NotFound();
            }

            ViewBag.Categories = _categories.Select(c => c.Name).ToList();
            return View(device);
        }

        [HttpPost]
        public IActionResult Edit(Device device)
        {
            var existingDevice = _devices.FirstOrDefault(d => d.Id == device.Id);
            if (existingDevice != null && ModelState.IsValid)
            {
                existingDevice.DeviceName = device.DeviceName;
                existingDevice.DeviceCode = device.DeviceCode;
                existingDevice.DeviceCategory = device.DeviceCategory;
                existingDevice.Status = device.Status;
                existingDevice.DateOfEntry = device.DateOfEntry;
                return RedirectToAction("Index");
            }
            ViewBag.Categories = _categories.Select(c => c.Name).ToList();
            return View(device);
        }

        public IActionResult Delete(int id)
        {
            var device = _devices.FirstOrDefault(d => d.Id == id);
            if (device != null)
            {
                _devices.Remove(device);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Search(string query) 
        { 
            var results = _devices.Where(d => 
            string.IsNullOrEmpty(query) || d.DeviceName.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList(); 
            return View("Index", results); 
        }
    }
}
