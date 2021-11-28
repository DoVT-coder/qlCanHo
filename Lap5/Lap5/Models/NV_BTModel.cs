using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Lap5.Models
{
    public class NV_BTModel
    {
        public int MaCH { get; set; }
        public int MaNV { get; set; }
        public int MaTB { get; set; }
        public int LanThu { get; set; }
        public DateTime NgayBT { get; set; }

        public CanHoModel CanHo { get; set; }
        public NhanVienModel NhanVien { get; set; }
        public ThietBiModel ThietBi { get; set; }

    }
}
