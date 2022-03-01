using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Hostel.ViewModels
{
    public class RepairIndexModel
    {
        public int Id { get; set; }
        public int DormitoryId { get; set; }
        public string Time { get; set; }
        public string Remark { get; set; }
        public string DormitoryName { get; set; }
    }
}
