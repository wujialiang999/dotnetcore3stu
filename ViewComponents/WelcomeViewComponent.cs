using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace dotnetcore3stu{
    public class WelcomeViewComponent:ViewComponent{
        private readonly IReposity<Student> reposity;

        public WelcomeViewComponent(IReposity<Student> reposity){
            this.reposity = reposity;
        }

        public IViewComponentResult Invoke(){
            var count  = reposity.GetAll().Count().ToString();
            return View("Default",count);
        }
    }
}