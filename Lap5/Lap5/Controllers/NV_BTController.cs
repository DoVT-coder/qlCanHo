using Microsoft.AspNetCore.Mvc;
using Lap5.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
namespace Lap5.Controllers
{
    
    public class NV_BTController : Controller
    {
        public IActionResult LietKeLanSua()
        {
            return View();
        }

        public IActionResult ListNhanVienSoLanSua(int SoLan)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(Lap5.Models.DataContext)) as DataContext;
            return View(context.sqlListByTimeNhanVien(SoLan));
        }
        public IActionResult ViewLanSua(int MaNV, int MaTB, int MaCH, int LanThu, DateTime NgayBT)
        {
            NV_BTModel model = new NV_BTModel();
            model.MaNV = MaNV;
            model.MaTB = MaTB;
            model.MaCH = MaCH;
            model.LanThu = LanThu;
            model.NgayBT = NgayBT;
            return View(model);
        }
        public IActionResult UpdateSuaChua(int MaNV, int MaTBC, int MaCHC, int LanThuC, int MaTB, int MaCH, int LanThu, string NgayBT)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(Lap5.Models.DataContext)) as DataContext;
            context.sqlUpdateSuaChua(MaNV, MaTBC, MaCHC, LanThuC, MaTB, MaCH, LanThu, NgayBT);
            return new RedirectResult(url: "/NhanVien/ListNhanVienSua?MaNV=" + MaNV, permanent: true, preserveMethod: true);
        }
    }
}

