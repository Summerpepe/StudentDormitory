using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Hostel.Models
{
    public class Dormitory
    {
        public int Id { get; set; }
        public string DorName { get; set; }
        public string NumPeople { get; set; }
        public string PeopleName { get; set; }
        public string Remark { get; set; }
        public  List<Student> Students { get; set; }

    }
}
