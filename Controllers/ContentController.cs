using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cms.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace cms.Controllers
{
    /// <summary>
    /// 控制器
    /// </summary>
    public class ContentController : Controller
    {
        private readonly Content contents;
        public ContentController(IOptions<Content> option) {
            contents = option.Value;
        }
        /// <summary>
        /// 首页的显示
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
  
            return View(new ContentViewModel { contents=new List<Content> { contents} });
        }
    }
}