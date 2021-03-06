using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Hostel.Models
{
    public class StuUser
    {
        public int Id { get; set; }
        [MaxLength(12, ErrorMessage = "学号的长度不能超过12个字符")]
        [Required(ErrorMessage = "学号不能为空")]
        [Display(Name = "学号")]
        public string Code { get; set; }
        [Required(ErrorMessage = "请输入名字")]
        [MaxLength(15, ErrorMessage = "名字的长度不能超过15个字符")]
        [Display(Name = "名字(昵称 )")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "密码不能为空")]
        [RegularExpression(@"(?=.*([a-zA-Z].*))(?=.*[0-9].*)[a-zA-Z0-9-*/+.~!@#$%^&*()]{6,20}$", ErrorMessage = "密码由字母、数字、字符组成，长度为6-20")]
        [Display(Name = "密码")]
        public string Pwd { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "确认密码不能为空")]
        [Compare("Pwd", ErrorMessage = "两次密码输入不一致")]
        [Display(Name = "确认密码")]
        public virtual string PasswordConfirm { get; set; }


    }
}
