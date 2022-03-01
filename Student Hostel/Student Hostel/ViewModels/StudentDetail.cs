using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Hostel.ViewModels
{
    public class StudentDetail
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Birth { get; set; }
        public string Phone { get; set; }
        public string DepartmentName { get; set; }
        public string DormitoryName { get; set; }
        public string PhotoPath { get; set; }
        public int DormitoryId { get; set; }
        public string Remark { get; set; }

    }
}
