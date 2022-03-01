using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Hostel.ViewModels
{
    public class StudentAddModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Sex { get; set; }
        public int DormitoryId { get; set; }
        public DateTime Birth { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
        public string Remark { get; set; }
    }
}
