using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Hostel.Models
{
    public class StuUserService
    {
        private readonly MyDbContext _myDbContext;
        public StuUserService(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;

        }
        public bool StuLogin(StuUser stu)
            {

                var u =_myDbContext.StuUser.FirstOrDefault(s => s.Name==stu.Name&&s.Code == stu.Code && s.Pwd == stu.Pwd);
                bool flag = false;
                if (u != null)
                    flag = true;
                return flag;

            }

    }
    }
