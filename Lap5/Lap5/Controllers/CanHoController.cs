using Lap5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
namespace Lap5.Controllers
{
    public class CanHoController : Controller
    {
        public IActionResult ThemCanHo()
        {
            return View();
        }

        public IActionResult AddCH(CanHoModel canho)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(Lap5.Models.DataContext)) as DataContext;
            context.sqlInsertCanHo(canho);
            return new RedirectResult(url: "/CanHo/ThemCanHo", permanent: true, preserveMethod: true);
        }
    }
}
