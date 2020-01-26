using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Core;
using ToDoList.Models.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
            TaskRepository _repo = new TaskRepository();

        public ActionResult Index()
        {
            var q = _repo.SelectAll().OrderByDescending(x => x.Priorty);
            return View(q);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Task Task)
        {
            _repo.Insert(Task);
            return RedirectToAction("Index");
        }
        public ActionResult Modify(int id)
        {
            return View(_repo.getSingle(id));
        }
        [HttpPost]
        public ActionResult Modify(Task Task)
        {
            _repo.Update(Task);
            return RedirectToAction("Index");
        }
        public ActionResult CompleteTask(int id)
        {
            Task Ts = _repo.getSingle(id);
            _repo.completeTask(Ts);
            return RedirectToAction("Index");
        }
        public ActionResult TaskDelete(int id)
        {
            Task Ts = _repo.getSingle(id);
            _repo.Delete(Ts);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult Timer()
        {
            var q = from t in _repo.SelectAll()
                    where t.Status==false && t.TaskDate<DateTime.Now
                    select t   ;

            

            return Json(q);
        }
    }
}