using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Lap5.Models
{
    public class ThietBiModel
    {
        public string MaTB { get; set; }
        public string TenTb { get; set; }
        public ICollection<NV_BTModel> NVBTs { get; set; }
    }
}
