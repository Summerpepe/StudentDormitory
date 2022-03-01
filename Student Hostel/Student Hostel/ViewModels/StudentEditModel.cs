using Student_Hostel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Hostel.ViewModels
{
    public class StudentEditModel
    {
        public List<Dormitory> Dormitories { get; set; }
        public Student student { get; set; }
        public string PhotoPath { get; set; }

    }
}
