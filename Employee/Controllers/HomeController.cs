using Employee.Dao;
using Employee.Interfeices;
using Employee.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserDao _userDao;

        public HomeController(IUserDao userDao)
        {
            _userDao = userDao;
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Employee()
        {
            var users = _userDao.Get();
            return View(users);
        }

        [HttpGet]
        public ActionResult CreateDialog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(UserModel user)
        {
            var id = _userDao.Save(user);
            return RedirectToAction("Details", new {id = (int?) id});
        }

        [HttpPost]
        public ActionResult Edit(UserModel user)
        {
            _userDao.Update(user);
            return RedirectToAction("Details", new {id = user.Id});
        }

        public ActionResult Details(int id)
        {
            var user = _userDao.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = _userDao.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var user = _userDao.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _userDao.Delete(id);
            return RedirectToAction("Employee");
        }

        [HttpPost]
        public ActionResult Search(int id)
        {
            var user = _userDao.GetByCompanyId(id);
            return View(user);
        }
    }
}