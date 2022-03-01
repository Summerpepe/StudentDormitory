using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Hostel.Models
{
    public class RegisterService
    {
        private readonly MyDbContext _myDbContext;

        public RegisterService(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        //学生注册
        public int StuRegister(StuUser stuUser,string code)
        {
            int count = 0;
            var student = _myDbContext.Student.ToList(); //转化为集合
            if (_myDbContext.StuUser.FirstOrDefault(s => s.Code == code) == null)
            {
                foreach(var item in student)
                {
                    if (stuUser.Code == item.Code)
                    {
                        _myDbContext.StuUser.Add(stuUser);
                         count = _myDbContext.SaveChanges();
                    }
                }
            }
            return count;       
           
                    }
        //管理员注册
        public int ManRegister(SysUser sysUser,string code)
        {
            int count = 0;
            if (_myDbContext.SysUser.FirstOrDefault(s => s.Code == code) == null)
            {
                _myDbContext.SysUser.Add(sysUser);
                 count = _myDbContext.SaveChanges();
            }
            return count;
        }
    }             
            };

                

