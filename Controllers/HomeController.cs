using Microsoft.AspNetCore.Mvc;
namespace dotnetcore3stu
{
    public class HomeController :Controller{
        public IActionResult Index(){
            // this.HttpContext.Request;
            // return this.Ok(1);
            // return this.File();
            return this.Content("文字内容");
            // return "Hello from HomeController";
        }
    }
}