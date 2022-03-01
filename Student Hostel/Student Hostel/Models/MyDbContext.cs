using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Hostel.Models
{
    public class MyDbContext : DbContext //数据库上下文类
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)//创造这个类的构造函数
        {

        }
        public DbSet<Student> Student { get; set; }//与数据库表明一致
        public DbSet<Dormitory> Dormitory { get; set; }
        public DbSet<SysUser> SysUser { get; set; }
        public DbSet<StuUser> StuUser { get; set; }
        public DbSet<Absence> Absence { get; set; }
        public DbSet<Repair> Repair { get; set; }
        public DbSet<Leave> Leave { get; set; }
        public DbSet<DormitoryHygiene> DormitoryHygiene { get; set; }
    }
}
