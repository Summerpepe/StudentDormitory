using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Hostel.ViewModels
{
    public class leaveIndexModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int DormitoryId { get; set; }
        public string LeaveTime { get; set; }
        public string ReturnTime { get; set; }
        public string DormitoryName { get; set; }
        public string Phone { get; set; }
        public string leaveReason { get; set; }
        public string PhotoPath { get; set; }
    }
}
