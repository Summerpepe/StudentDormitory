using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Hostel.Models
{
    public class Absence
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Code { get; set; }
        public int DormitoryId { get; set; }
        public DateTime Time { get; set; }
        public string Remark { get; set; }
        public virtual Dormitory dormitory { get; set; }

    }
}
