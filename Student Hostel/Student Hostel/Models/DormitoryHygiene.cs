using System;

namespace Student_Hostel.Models
{
    public class DormitoryHygiene
    {
        public string Code { get; set; }
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int DormitoryId { get; set; }
        public string Remark { get; set; }
        public virtual Dormitory dormitory { get; set; }

    }
}