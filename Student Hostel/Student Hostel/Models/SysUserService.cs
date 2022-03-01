using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Student_Hostel.Models
{
    public class SysUserService
    {
        private readonly MyDbContext _myDbContext;

        public SysUserService(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;


        }
        public bool Login(SysUser user)
        {

            var u = _myDbContext.SysUser.FirstOrDefault(s => s.Name == user.Name && s.Pwd == user.Pwd&&s.Code==user.Code);
            bool flag = false;
            if (u != null)
                flag = true;
            return flag;

        }
    }
    }

   

