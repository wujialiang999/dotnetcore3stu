using Microsoft.AspNetCore.Mvc;
namespace dotnetcore3stu
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // this.HttpContext.Request;
            // return this.Ok(1);
            // return this.File();
            Student st = new Student
            {
                Id = 1,
                FirstName = "Nick",
                LastName = "Tom"
            };
            return new ObjectResult(st);
            // return this.Content("文字内容");
            // return "Hello from HomeController";
        }
    }
}