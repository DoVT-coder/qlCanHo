using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Lap5.Models
{
    public class CanHoModel
    {
        public int MaCH { get; set; }
        public string TenCH { get; set; }
        public ICollection<NV_BTModel> NVBTs { get; set; }

    }
}

