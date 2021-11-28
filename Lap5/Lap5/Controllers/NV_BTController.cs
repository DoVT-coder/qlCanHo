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
        [HttpPost]
        public IActionResult ListNhanVienSoLanSua(int SoLan)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(Lap5.Models.DataContext)) as DataContext;
            return View(context.sqlListByTimeNhanVien(SoLan));
        }
        public object a;
        static NV_BTModel b = new NV_BTModel();
        public IActionResult ViewLanSua(int MaNV, int MaTB, int MaCH, int LanThu, DateTime NgayBT)
        {

            //Chuyển từ 11/19/2021 12:00:00 AM sang 2021-11-19T12:00 
            //6/28/2022 10:10:00 AM
            string Ngay = NgayBT.ToString();
            string Temp = Ngay.Substring(6, 4) + "-" + Ngay.Substring(0, 2) + "-" + Ngay.Substring(3, 2) + "T" + Ngay.Substring(11,8);
            a = (new
            {
                MaNV = MaNV,
                MaTB = MaTB,
                MaCH = MaCH,
                LanThu = LanThu,
                NgayBT = NgayBT
            });
            b.MaNV = MaNV;
            b.MaTB = MaTB;
            b.MaCH = MaCH;
            b.LanThu = LanThu;
            b.NgayBT = NgayBT;
            
            return View(a);
        }
        [HttpPost]
        public String UpdateSuaChua(int MaTB, int MaCH, int LanThu, string NgayBT)
        {
            int count;
            DataContext context = HttpContext.RequestServices.GetService(typeof(Lap5.Models.DataContext)) as DataContext;
            count = context.sqlUpdateSuaChua(MaTB, MaCH, LanThu, NgayBT, b);
            if (count == 1)
                return "Cập nhập Thành Công";
            return "Cập nhập Thất Bại" + b.MaNV;
        }
    }
}

