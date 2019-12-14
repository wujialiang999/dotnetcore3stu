using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
namespace dotnetcore3stu
{
    public class HomeController : Controller
    {
        private readonly IReposity<Student> _reposity;
        public HomeController(IReposity<Student> reposity)
        {
            _reposity = reposity;
        }
        public IActionResult Index()
        {
            // this.HttpContext.Request;
            // return this.Ok(1);
            // return this.File();
            // Student st = new Student
            // {
            //     Id = 1,
            //     FirstName = "Nick",
            //     LastName = "Tom"
            // };
            IEnumerable<Student> list = _reposity.GetAll();
            var vms = list.Select(x => new StudentViewModel
            {
                Id = x.Id,
                Name = $"{x.FirstName} {x.LastName}",
                Age = System.DateTime.Now.Subtract(x.BirthDate).Days / 365
            });
            var vm = new HomeIndexViewModel
            {
                Students = vms
            };
            return View(vm);
            /*
                /Views/Home/Student.cshtml
                /Views/Shared/Student.cshtml
                /Pages/Shared/Student.cshtml
            */
            // return new ObjectResult(st);
            // return this.Content("文字内容");
            // return "Hello from HomeController";
        }

        public IActionResult Detail(int id)
        {// 首先路由参数查找
            // return Content(id.ToString());
            var student = _reposity.GetById(id);
            if (student == null)
                // return View("Not Found");跳转到not found页面
                // return RedirectToAction("Index");// 跳转到本Controller
                // return RedirectToAction("Index", "Home");//第二个参数为ControllerName，可以跳转到指定Controller
                return RedirectToAction(nameof(Index));
            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]// 防止csrf攻击
        public IActionResult Create(StudentCreateViewModel student)
        {
            if (ModelState.IsValid)
            {
                var newStudent = new Student
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    BirthDate = student.BirthDate,
                    Gender = student.Gender
                };
                var newModel = _reposity.Add(newStudent);

                // return View("Detail",newModel);// 这样会造成重复提交表单
                return RedirectToAction(nameof(Detail), new { id = newModel.Id });
            }
            // ModelState.AddModelError(string.Empty,"Model Level Error");
            return View();//返回CreateView
        }
    }
}