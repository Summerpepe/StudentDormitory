using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Hostel.Models
{
    public class Repair
    {
        public int Id { get; set; }
        public int DormitoryId { get; set; }

        [Range(typeof(DateTime), "2000-01-01", "2099-12-31", ErrorMessage = "日期范围{0}-{1}")]
        public DateTime Time { get; set; }
        public string Remark { get; set; }
        public virtual Dormitory dormitory { get; set; }
    }
}
