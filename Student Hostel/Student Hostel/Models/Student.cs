using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Hostel.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Code { get; set; }

        [Required(ErrorMessage = "请输入名字"),MaxLength(50,ErrorMessage ="名字的长度不能超过50个字符")]
        [Display(Name ="名字")]
         public string Name { get; set; }
        public bool Sex { get; set; }
        public int DormitoryId { get; set; }
        public DateTime Birth { get; set; }
        public string Phone { get; set; }
        public string DepartmentName { get; set; }
        public string Remark { get; set; }
        public string PhotoPath { get; set; }
        public virtual Dormitory dormitory { get; set; }
       

 




    }
}
