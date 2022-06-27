using Microsoft.AspNetCore.Mvc;
using RestfulDemo.ViewModels;
using System.Collections.Generic;

namespace RestfulDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<string> Skill = new List<string> { "C#", "Java", "MS SQL", "AJAX", "Word", "Excel","Html" ,".Net Core"};
        private readonly List<string> Area = new List<string> { "台南", "新竹", "台中", "台北" ,"澎湖"};
        private readonly List<string> Sexs = new List<string> { "男", "女" };
        private readonly List<string> Status = new List<string> { "儲存", "追蹤" };
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.Data = new DataList
            {
                Area = this.Area,
                Sexs = this.Sexs,
                Skills = this.Skill,
                Status = this.Status
            };
            return View();
        }
        public IActionResult Edit()
        {
            ViewBag.Data = new DataList
            {
                Area = this.Area,
                Sexs = this.Sexs,
                Skills = this.Skill,
                Status = this.Status
            };
            return View();
        }
    
    }
}
