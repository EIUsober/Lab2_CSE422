using Lab2_NguyenTruongGiang_CSE422.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab2_NguyenTruongGiang_CSE422.Controllers
{
    public class UserController : Controller
    {
        private static List<User> _users = new List<User>();

        public IActionResult Index()
        {
            return View(_users);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = _users.Count + 1;
                _users.Add(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public IActionResult Edit(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null && ModelState.IsValid)
            {
                existingUser.FullName = user.FullName;
                existingUser.Email = user.Email;
                existingUser.PhoneNumber = user.PhoneNumber;
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public IActionResult Delete(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
            }
            return RedirectToAction("Index");
        }
    }
}
