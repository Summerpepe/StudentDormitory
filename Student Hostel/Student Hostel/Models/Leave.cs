using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Hostel.Models
{
    public class Leave
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int DormitoryId { get; set; }
        public DateTime LeaveTime { get; set; }
        public DateTime ReturnTime { get; set; }
        public string Phone { get; set; }
        public string leaveReason { get; set; }
        public string PhotoPath { get; set; }
        public virtual Dormitory dormitory { get; set; }
    }
}
