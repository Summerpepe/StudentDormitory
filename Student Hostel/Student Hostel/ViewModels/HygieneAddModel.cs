using Student_Hostel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Hostel.ViewModels
{
    public class HygieneAddModel
    {
        public List<Dormitory> Dormitories { get; set; }
        public SysUserDetail sysUserDetail { get; set; }

    }
}
