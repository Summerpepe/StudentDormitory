using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Hostel.ViewModels
{
    public class AbsenceDetailModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int DormitoryId { get; set; }
        public string DormitoryName { get; set; }
        public string Time { get; set; }
        public string Remark { get; set; }
    }
}
