using Microsoft.AspNetCore.Mvc;

namespace dotnetcore3stu{
    // [Route("about")]
    // [Route("[controller]")] //使用Controller的名字
    [Route("[controller]/[action]")]
    // [Route("v2/[controller]/[action]")] //http://loalhost:5000/v2/about/me
    public class AboutController{
        // [Route("me")]
        // [Route("[action]")]
        public string Me(){
            return "wjl";
        }
        // [Route("")]//默认返回
        public string Company(){
            return "没公司";
        }
    }
}