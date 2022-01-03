using Microsoft.AspNetCore.Mvc;
using Lap5.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace Lap5.Controllers
{
    public class NhanVienController : Controller
    {
        
        public IActionResult ListNhanVien()
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(Lap5.Models.DataContext)) as DataContext;
            return View(context.sqlListNhanVien());
        }

        public IActionResult ListNhanVienSua(int MaNV)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(Lap5.Models.DataContext)) as DataContext;
            return View(context.sqlLietKet(MaNV));
        }
        public IActionResult XoaLanSua(int MaNV, int MaTB, int MaCH, int LanThu)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(Lap5.Models.DataContext)) as DataContext;
            context.sqlXoaLanSua(MaNV, MaTB, MaCH, LanThu);
            return new RedirectResult(url: "/NhanVien/ListNhanVienSua?MaNV=" + MaNV, permanent: true, preserveMethod: true);
        }
    }
    
}
