using Microsoft.EntityFrameworkCore;
using Student_Hostel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student_Hostel.Models;
using MySqlX.XDevAPI;

namespace Student_Hostel.Models
{
    public class StudentService : IStudentService
    {
        private readonly MyDbContext _myDbContext;

        public StudentService(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public int Add(Student student, string code)
        {
            //var entity= _myDbContext.Student.Add(student);
            //student = entity.Entity;//id的值,因为ID的值是自动生成的
            int count = 0;
            if (_myDbContext.Student.FirstOrDefault(s => s.Code == code) == null)
            {

                _myDbContext.Student.Add(student);
                count = _myDbContext.SaveChanges();
            }//SaveChanges()方法更新到数据库里面，返回值是整型，对数据库有影响的行数
            return count;

        }

        public int Delete(int id)
        {
            Student student = _myDbContext.Student.FirstOrDefault(s => s.Id == id);
            int count = 0;
            if (student != null)
            {
                _myDbContext.Student.Remove(student);
                count = _myDbContext.SaveChanges();
            }
            return count;
        }

        public List<StudentDetail> GetAllStudents(int pageIndex, int pageSize, out int totalPage)
        {
            //方法一：join方法

            var students = _myDbContext.Student.Join(_myDbContext.Dormitory, //添加外键
                      a => a.DormitoryId,
                      b => b.Id,
                     (a, b) => new
                     {
                         a.Id,
                         a.Code,
                         a.Name,
                         a.Sex,
                         a.DormitoryId,
                         a.Birth,
                         a.Phone,
                         a.DepartmentName,
                         a.Remark,
                         DormitoryName = b.DorName  //结果集里面要哪些字段
                     }).ToList(); //转化为集合
            if (pageIndex <= 0)
                pageIndex = 1;
            int totalCount = students.Count();
            totalPage = (int)Math.Ceiling(totalCount / (double)pageSize);//获得最小页数
            if (pageIndex > totalPage)
                pageIndex = totalPage;

            var pageList = students.OrderBy(s => s.Id).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();//排序，得到一页的数据

            List<StudentDetail> list = new List<StudentDetail>();
            foreach (var item in pageList)
            {
                list.Add(new StudentDetail
                {
                    Id = item.Id,
                    Code = item.Code,
                    Name = item.Name,
                    Sex = item.Sex ? "男" : "女",
                    Birth = item.Birth.Year + "-" + item.Birth.Month + "-" + item.Birth.Day,
                    Phone = item.Phone,
                    DormitoryId = item.DormitoryId,
                    Remark = item.Remark,
                    DepartmentName = item.DepartmentName,
                    DormitoryName = item.DormitoryName
                });
            };
            return list;

        }
        public List<StudentDetail> GetAllStudents()
        {
            //方法一：join方法

            var students = _myDbContext.Student.Join(_myDbContext.Dormitory, //添加外键
                      a => a.DormitoryId,
                      b => b.Id,
                     (a, b) => new
                     {
                         a.Id,
                         a.Code,
                         a.Name,
                         a.Sex,
                         a.DormitoryId,
                         a.Birth,
                         a.Phone,
                         a.DepartmentName,
                         a.Remark,
                         DormitoryName = b.DorName  //结果集里面要哪些字段
                     }).ToList(); //转化为集合


            List<StudentDetail> list = new List<StudentDetail>();
            foreach (var item in students)
            {
                list.Add(new StudentDetail
                {
                    Id = item.Id,
                    Code = item.Code,
                    Name = item.Name,
                    Sex = item.Sex ? "男" : "女",
                    Birth = item.Birth.Year + "-" + item.Birth.Month + "-" + item.Birth.Day,
                    Phone = item.Phone,
                    DormitoryId = item.DormitoryId,
                    Remark = item.Remark,
                    DepartmentName = item.DepartmentName,
                    DormitoryName = item.DormitoryName
                });
            };
            return list;

        }


        public StudentDetail GetStudent(int id)
        {

            //创建了外键关系用include，没有创建外键关系用join

            var student = _myDbContext.Student.Join(_myDbContext.Dormitory, //添加外键
                a => a.DormitoryId,
                b => b.Id,
               (a, b) => new
               {
                   a.Id,
                   a.Code,
                   a.Name,
                   a.PhotoPath,
                   a.Sex,
                   a.DormitoryId,
                   a.Birth,
                   a.Phone,
                   a.DepartmentName,
                   a.Remark,
                   DormitoryName = b.DorName
                   //结果集里面要哪些字段
               }).Where(s => s.Id == id).FirstOrDefault(); //满足条件的第一条记录
            StudentDetail model = null;
            if (student != null)
            {
                model = new StudentDetail  //赋值
                {
                    Id = student.Id,
                    Code = student.Code,
                    Name = student.Name,
                    Sex = student.Sex ? "男" : "女",
                    Birth = student.Birth.Year + "-" + student.Birth.Month + "-" + student.Birth.Day,
                    Phone = student.Phone,
                    DormitoryId = student.DormitoryId,
                    DormitoryName = student.DormitoryName,
                    DepartmentName = student.DepartmentName,
                    Remark = student.Remark,
                    PhotoPath = student.PhotoPath
                };
            }
            return model;

        }
        public Student GetStudentById(int id)
        {
            Student student = _myDbContext.Student.FirstOrDefault(s => s.Id == id);
            return student;

        }


        //修改
        public int Update(Student student)
        {
            Student updatestudent = _myDbContext.Student.FirstOrDefault(s => s.Id == student.Id);
            int count = 0;
            if (updatestudent != null)
            {
                updatestudent.Name = student.Name;
                updatestudent.Phone = student.Phone;
                updatestudent.DormitoryId = student.DormitoryId;
                updatestudent.Sex = student.Sex;
                updatestudent.Code = student.Code;
                updatestudent.Birth = student.Birth;
                updatestudent.DepartmentName = student.DepartmentName;
                updatestudent.Remark = student.Remark;
                _myDbContext.Update(updatestudent);
                count = _myDbContext.SaveChanges();
            }
            return count;
        }

        //搜索
        public List<StudentDetail> Search(string code)
        {

            // return _myDbContext.Student.Include("Dormitory").Where(a => a.Name.Contains(name)).ToList();
            //where筛选集合中的项
            var student = _myDbContext.Student.Join(_myDbContext.Dormitory, //添加外键
               a => a.DormitoryId,
               b => b.Id,
              (a, b) => new
              {
                  a.Id,
                  a.Code,
                  a.Name,
                  a.PhotoPath,
                  a.Sex,
                  a.DormitoryId,
                  a.Birth,
                  a.Phone,
                  a.DepartmentName,
                  a.Remark,
                  DormitoryName = b.DorName
                  //结果集里面要哪些字段
              }).Where(s => s.Code.Contains(code)).ToList();



            List<StudentDetail> list = new List<StudentDetail>();
            foreach (var item in student)
            {
                list.Add(new StudentDetail
                {
                    Id = item.Id,
                    Code = item.Code,
                    Name = item.Name,
                    Sex = item.Sex ? "男" : "女",
                    Birth = item.Birth.Year + "-" + item.Birth.Month + "-" + item.Birth.Day,
                    Phone = item.Phone,
                    DormitoryId = item.DormitoryId,
                    Remark = item.Remark,
                    DepartmentName = item.DepartmentName,
                    DormitoryName = item.DormitoryName

                });
            };
            return list;

        }

        //缺勤登记
        public int AddAbsence(Absence absence)
        {
            int count = 0;
            string code = absence.Code;
            string name = absence.Name;
            
            if (_myDbContext.Student.FirstOrDefault(s => s.Code == code) != null)
            {
                var student = _myDbContext.Student.FirstOrDefault(s => s.Code == code);
                string stuname = student.Name;
                if (stuname == name)
                {
                    _myDbContext.Absence.Add(absence);
                    count = _myDbContext.SaveChanges();//SaveChanges()方法更新到数据库里面，返回值是整型，对数据库有影响的行数
                }
            }

            return count;
        }

        //获得全部缺勤记录
        public List<AbsenceDetailModels> GetAllAbsence()
        {
            //方法一：join方法

            var absence = _myDbContext.Absence.Join(_myDbContext.Dormitory, //添加外键
                      a => a.DormitoryId,
                      b => b.Id,
                     (a, b) => new
                     {
                         a.Id,
                         a.Code,
                         a.Name,
                         a.DormitoryId,
                         a.Time,
                         a.Remark,
                         DormitoryName = b.DorName  //结果集里面要哪些字段
                     }).ToList(); //转化为集合

            List<AbsenceDetailModels> list = new List<AbsenceDetailModels>();
            foreach (var item in absence)
            {
                list.Add(new AbsenceDetailModels
                {
                    Id = item.Id,
                    Name = item.Name,
                    Code = item.Code,
                    Time = item.Time.Month + "月" + item.Time.Day + "日" + item.Time.Hour + "时" + item.Time.Minute + "分",
                    DormitoryId = item.DormitoryId,
                    Remark = item.Remark,
                    DormitoryName = item.DormitoryName

                });
            };
            return list;
        }

        //分页----缺勤Index
        public List<AbsenceDetailModels> GetAllAbsence(int pageIndex, int pageSize, out int totalPage)
        {
            //方法一：join方法

            var absence = _myDbContext.Absence.Join(_myDbContext.Dormitory, //添加外键
                    a => a.DormitoryId,
                    b => b.Id,
                   (a, b) => new
                   {
                       a.Id,
                       a.Code,
                       a.Name,
                       a.DormitoryId,
                       a.Time,
                       a.Remark,
                       DormitoryName = b.DorName  //结果集里面要哪些字段
                   }).ToList(); //转化为集合
            if (pageIndex <= 0)
                pageIndex = 1;
            int totalCount = absence.Count();
            totalPage = (int)Math.Ceiling(totalCount / (double)pageSize);//获得最小页数
            if (pageIndex > totalPage)
                pageIndex = totalPage;

            var pageList = absence.OrderBy(s => s.Id).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();//排序，得到一页的数据

            List<AbsenceDetailModels> list = new List<AbsenceDetailModels>();
            foreach (var item in pageList)
            {
                list.Add(new AbsenceDetailModels
                {
                    Id = item.Id,
                    Name = item.Name,
                    Code = item.Code,
                    Time = item.Time.Month + "月" + item.Time.Day + "日" + item.Time.Hour + "时" + item.Time.Minute + "分",
                    DormitoryId = item.DormitoryId,
                    Remark = item.Remark,
                    DormitoryName = item.DormitoryName
                });
            }
            return list;
        }


        //删除缺勤记录
        public int AbsenDelete(int id)

        {
            Absence absence = _myDbContext.Absence.FirstOrDefault(s => s.Id == id);
            int count = 0;
            if (absence != null)
            {
                _myDbContext.Absence.Remove(absence);
                count = _myDbContext.SaveChanges();
            }
            return count;
        }

        //宿舍卫生查看
        public List<DormitoryHygieneModels> GetAllHygiene()
        {

            var hygiene = _myDbContext.DormitoryHygiene.Join(_myDbContext.Dormitory, //添加外键
                      a => a.DormitoryId,
                      b => b.Id,
                     (a, b) => new
                     {
                         a.Id,
                         a.Code,
                         a.Time,
                         a.DormitoryId,
                         a.Remark,
                         DormitoryName = b.DorName  //结果集里面要哪些字段
                     }).ToList(); //转化为集合

            List<DormitoryHygieneModels> list = new List<DormitoryHygieneModels>();
            foreach (var item in hygiene)
            {
                list.Add(new DormitoryHygieneModels
                {
                    Id = item.Id,
                    Code = item.Code,
                    Time = item.Time.Month + "月" + item.Time.Day + "日" + item.Time.Hour + "时" + item.Time.Minute + "分",
                    DormitoryId = item.DormitoryId,
                    DormitoryName = item.DormitoryName,
                    Remark = item.Remark

                });
            };
            return list;
        }

            //分页----宿舍卫生Index
       public List<DormitoryHygieneModels> GetAllHygiene(int pageIndex, int pageSize, out int totalPage)
        {
            var hygiene = _myDbContext.DormitoryHygiene.Join(_myDbContext.Dormitory, //添加外键
                         a => a.DormitoryId,
                         b => b.Id,
                        (a, b) => new
                        {
                            a.Id,
                            a.Code,
                            a.Time,
                            a.DormitoryId,
                            a.Remark,
                            DormitoryName = b.DorName  //结果集里面要哪些字段
                        }).ToList(); //转化为集合
            if (pageIndex <= 0)
                pageIndex = 1;
            int totalCount = hygiene.Count();
            totalPage = (int)Math.Ceiling(totalCount / (double)pageSize);//获得最小页数
            if (pageIndex > totalPage)
                pageIndex = totalPage;

            var pageList = hygiene.OrderBy(s => s.Id).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();//排序，得到一页的数据

            List<DormitoryHygieneModels> list = new List<DormitoryHygieneModels>();
            foreach (var item in pageList)
            {
                list.Add(new DormitoryHygieneModels
                {
                    Id = item.Id,
                    Code = item.Code,
                    Time = item.Time.Month + "月" + item.Time.Day + "日" + item.Time.Hour + "时" + item.Time.Minute + "分",
                    DormitoryId = item.DormitoryId,
                    DormitoryName = item.DormitoryName,
                    Remark = item.Remark

                });
            };
            return list;
        }

      //宿舍卫生增加
        public int AddHygiene(DormitoryHygiene dormitoryHygiene)
        {

            _myDbContext.DormitoryHygiene.Add(dormitoryHygiene);
            int count = _myDbContext.SaveChanges();//SaveChanges()方法更新到数据库里面，返回值是整型，对数据库有影响的行数
            return count;

        }
        //查看管理员信息
        public SysUserDetail GetSys(string code)
        {

            var sysUser = _myDbContext.SysUser.FirstOrDefault(s => s.Code == code);
            SysUserDetail model = new SysUserDetail  //赋值
            {
                Id = sysUser.Id,
                Code = sysUser.Code,
                Name = sysUser.Name,
                Sex = sysUser.Sex ? "男" : "女",
                Phone = sysUser.Phone,
                //PhotoPath = sysUser.PhotoPath,
                Pwd = sysUser.Pwd
            };
            return model;
        }

        //通过用户名查找管理员信息
        public SysUser GetSysEdit(string code)
        {

            SysUser sysUser = _myDbContext.SysUser.FirstOrDefault(s => s.Code == code);
            return sysUser;
        }
        //修改管理员信息
        public int SysUpdate(SysUser sysUser)
        {
            SysUser updatesys = _myDbContext.SysUser.FirstOrDefault(s => s.Code == sysUser.Code);
            int count = 0;
            if (updatesys != null)
            {
                updatesys.Phone = sysUser.Phone;
                updatesys.Pwd = sysUser.Pwd;
                updatesys.Sex = sysUser.Sex;
                updatesys.PasswordConfirm = sysUser.PasswordConfirm;
                updatesys.Name = sysUser.Name;
                _myDbContext.Update(updatesys);
                count = _myDbContext.SaveChanges();
            }
            return count;
        }
        //查看学生全部信息
        public StudentDetail GetOneStudent(string Code)
        {
            var student = _myDbContext.Student.Join(_myDbContext.Dormitory, //添加外键
               a => a.DormitoryId,
               b => b.Id,
              (a, b) => new
              {
                  a.Id,
                  a.Code,
                  a.Name,
                  a.PhotoPath,
                  a.Sex,
                  a.DormitoryId,
                  a.Birth,
                  a.Phone,
                  a.DepartmentName,
                  a.Remark,
                  DormitoryName = b.DorName
                  //结果集里面要哪些字段
              }).Where(s => s.Code == Code).FirstOrDefault(); //满足条件的第一条记录
            StudentDetail model = null;
            if (student != null)
            {
                model = new StudentDetail  //赋值
                {
                    Id = student.Id,
                    Code = student.Code,
                    Name = student.Name,
                    Sex = student.Sex ? "男" : "女",
                    Birth = student.Birth.Year + "-" + student.Birth.Month + "-" + student.Birth.Day,
                    Phone = student.Phone,
                    DormitoryId = student.DormitoryId,
                    DormitoryName = student.DormitoryName,
                    DepartmentName = student.DepartmentName,
                    Remark = student.Remark,
                    PhotoPath = student.PhotoPath
                };
            }
            return model;
        }
        //保修增加
        public int AddRepair(Repair repair)
        {
            int count = 0;
                _myDbContext.Repair.Add(repair);
                count = _myDbContext.SaveChanges();//SaveChanges()方法更新到数据库里面，返回值是整型，对数据库有影响的行数           
            return count;

        }

        //获得全部保修信息
        public List<RepairIndexModel> GetAllRepairs()
        {
            //方法一：join方法

            var repair = _myDbContext.Repair.Join(_myDbContext.Dormitory, //添加外键
                      a => a.DormitoryId,
                      b => b.Id,
                     (a, b) => new
                     {
                         a.Id,
                         a.Time,
                         a.DormitoryId,
                         a.Remark,
                         DormitoryName = b.DorName  //结果集里面要哪些字段
                     }).ToList(); //转化为集合

            List<RepairIndexModel> list = new List<RepairIndexModel>();
            foreach (var item in repair)
            {
                list.Add(new RepairIndexModel
                {
                    Id = item.Id,
                    Time = item.Time.Year + "-" + item.Time.Month + "-" + item.Time.Day + " " + item.Time.Hour + ":" + item.Time.Minute,
                    DormitoryId = item.DormitoryId,
                    Remark = item.Remark,
                    DormitoryName = item.DormitoryName
                });
            };
            return list;

        }

        //分页--报修Index
        public List<RepairIndexModel> GetAllRepairs(int pageIndex, int pageSize, out int totalPage)
        {
            //方法一：join方法

            var repair = _myDbContext.Repair.Join(_myDbContext.Dormitory, //添加外键
                     a => a.DormitoryId,
                     b => b.Id,
                    (a, b) => new
                    {
                        a.Id,
                        a.Time,
                        a.DormitoryId,
                        a.Remark,
                        DormitoryName = b.DorName  //结果集里面要哪些字段
                     }).ToList(); //转化为集合
            if (pageIndex <= 0)
                pageIndex = 1;
            int totalCount = repair.Count();
            totalPage = (int)Math.Ceiling(totalCount / (double)pageSize);//获得最小页数
            if (pageIndex > totalPage)
                pageIndex = totalPage;

            var pageList = repair.OrderBy(s => s.Id).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();//排序，得到一页的数据

            List<RepairIndexModel> list = new List<RepairIndexModel>();
            foreach (var item in pageList)
            {
                list.Add(new RepairIndexModel
                {
                    Id = item.Id,
                    Time = item.Time.Year + "-" + item.Time.Month + "-" + item.Time.Day + " " + item.Time.Hour + ":" + item.Time.Minute,
                    DormitoryId = item.DormitoryId,
                    Remark = item.Remark,
                    DormitoryName = item.DormitoryName
                });
            };
            return list;
        }
        public RepairIndexModel GetRepair(int id)
        {

            var repair = _myDbContext.Repair.Join(_myDbContext.Dormitory, //添加外键
                     a => a.DormitoryId,
                     b => b.Id,
                    (a, b) => new
                    {
                        a.Id,
                        a.Time,
                        a.DormitoryId,
                        a.Remark,
                        DormitoryName = b.DorName  //结果集里面要哪些字段
                    }).Where(s => s.Id == id).FirstOrDefault(); //转化为集合
            RepairIndexModel model = new RepairIndexModel
            {
                Id = repair.Id,
                Time = repair.Time.Year + "-" + repair.Time.Month + "-" + repair.Time.Day + " " + repair.Time.Hour + ":" + repair.Time.Minute,
                DormitoryId = repair.DormitoryId,
                Remark = repair.Remark,
                DormitoryName = repair.DormitoryName
            };
            return model;

        }
        public int AddLeave(Leave leave, string name, string code)
        {
            int count = 0;
            var student = _myDbContext.Student.FirstOrDefault(s => s.Code == code);
            string strname = student.Name;
            if (strname == name)
            {
                _myDbContext.Leave.Add(leave);
                count = _myDbContext.SaveChanges();
            }
            return count;
        }

        //学生个人账户信息
        public StuUser GetStu(string code)
        {

            var stuuser = _myDbContext.StuUser.FirstOrDefault(s => s.Code == code);
            StuUser model = new StuUser  //赋值
            {

                Code = stuuser.Code,
                Name = stuuser.Name,
                Pwd = stuuser.Pwd
            };
            return model;
        }

        //通过用户名查找管理员信息
        public StuUser GetStuEdit(string code)
        {

            StuUser stuUser = _myDbContext.StuUser.FirstOrDefault(s => s.Code == code);
            return stuUser;
        }
        //修改学生用户信息
        public int StuUpdate(StuUser stuUser)
        {
            StuUser updatestu = _myDbContext.StuUser.FirstOrDefault(s => s.Code == stuUser.Code);
            int count = 0;
            if (updatestu != null)
            {
                updatestu.PasswordConfirm = stuUser.PasswordConfirm;
                updatestu.Name = stuUser.Name;
                updatestu.Pwd = stuUser.Pwd;
                _myDbContext.Update(updatestu);
                count = _myDbContext.SaveChanges();
            }
            return count;
        }
        public int RepairDelete(int id)
        {
            Repair repair = _myDbContext.Repair.FirstOrDefault(s => s.Id == id);
            int count = 0;
            if (repair != null)
            {
                _myDbContext.Repair.Remove(repair);
                count = _myDbContext.SaveChanges();
            }
            return count;
        }
        //得到全部的请假记录
        public List<leaveIndexModel> GetAllLeave()
        {
            //方法一：join方法

            var leave = _myDbContext.Leave.Join(_myDbContext.Dormitory, //添加外键
                      a => a.DormitoryId,
                      b => b.Id,
                     (a, b) => new
                     {
                         a.Id,
                         a.Code,
                         a.Name,
                         a.DormitoryId,
                         a.LeaveTime,
                         a.ReturnTime,
                         a.Phone,
                         a.leaveReason,
                         a.PhotoPath,
                         DormitoryName = b.DorName
                     }).ToList(); //转化为集合

            List<leaveIndexModel> list = new List<leaveIndexModel>();
            foreach (var item in leave)
            {
                list.Add(new leaveIndexModel
                {
                    Id = item.Id,
                    Code = item.Code,
                    Name = item.Name,
                    Phone = item.Phone,
                    leaveReason = item.leaveReason,
                    PhotoPath = item.PhotoPath,
                    LeaveTime = item.LeaveTime.Year + "-" + item.LeaveTime.Month + "-" + item.LeaveTime.Day + " " + item.LeaveTime.Hour + ":" + item.LeaveTime.Minute,
                    ReturnTime = item.ReturnTime.Year + "-" + item.ReturnTime.Month + "-" + item.ReturnTime.Day + " " + item.ReturnTime.Hour + ":" + item.ReturnTime.Minute,
                    DormitoryId = item.DormitoryId,
                    DormitoryName = item.DormitoryName
                });
            };
            return list;

        }

        //分页--请假Index
        public List<leaveIndexModel> GetAllLeave(int pageIndex, int pageSize, out int totalPage)
        {
            //方法一：join方法

            var leave = _myDbContext.Leave.Join(_myDbContext.Dormitory, //添加外键
                    a => a.DormitoryId,
                    b => b.Id,
                   (a, b) => new
                   {
                       a.Id,
                       a.Code,
                       a.Name,
                       a.DormitoryId,
                       a.LeaveTime,
                       a.ReturnTime,
                       a.Phone,
                       a.leaveReason,
                       a.PhotoPath,
                       DormitoryName = b.DorName
                   }).ToList(); //转化为集合
            if (pageIndex <= 0)
                pageIndex = 1;
            int totalCount = leave.Count();
            totalPage = (int)Math.Ceiling(totalCount / (double)pageSize);//获得最小页数
            if (pageIndex > totalPage)
                pageIndex = totalPage;

            var pageList = leave.OrderBy(s => s.Id).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();//排序，得到一页的数据

            List<leaveIndexModel> list = new List<leaveIndexModel>();
            foreach (var item in pageList)
            {
                list.Add(new leaveIndexModel
                {
                    Id = item.Id,
                    Code = item.Code,
                    Name = item.Name,
                    Phone = item.Phone,
                    leaveReason = item.leaveReason,
                    PhotoPath = item.PhotoPath,
                    LeaveTime = item.LeaveTime.Year + "-" + item.LeaveTime.Month + "-" + item.LeaveTime.Day + " " + item.LeaveTime.Hour + ":" + item.LeaveTime.Minute,
                    ReturnTime = item.ReturnTime.Year + "-" + item.ReturnTime.Month + "-" + item.ReturnTime.Day + " " + item.ReturnTime.Hour + ":" + item.ReturnTime.Minute,
                    DormitoryId = item.DormitoryId,
                    DormitoryName = item.DormitoryName
                });
            }
            return list;
        }
        public leaveIndexModel GetLeave(int id)
        {

            var leave = _myDbContext.Leave.Join(_myDbContext.Dormitory, //添加外键
                      a => a.DormitoryId,
                      b => b.Id,
                     (a, b) => new
                     {
                         a.Id,
                         a.Code,
                         a.Name,
                         a.DormitoryId,
                         a.LeaveTime,
                         a.ReturnTime,
                         a.Phone,
                         a.leaveReason,
                         a.PhotoPath,
                         DormitoryName = b.DorName
                     }).Where(s => s.Id == id).FirstOrDefault(); //转化为集合
            leaveIndexModel model = new leaveIndexModel
            {
                Id = leave.Id,
                Code = leave.Code,
                Name = leave.Name,
                Phone = leave.Phone,
                leaveReason = leave.leaveReason,
                PhotoPath = leave.PhotoPath,
                LeaveTime = leave.LeaveTime.Year + "-" + leave.LeaveTime.Month + "-" + leave.LeaveTime.Day + " " + leave.LeaveTime.Hour + ":" + leave.LeaveTime.Minute,
                ReturnTime = leave.ReturnTime.Year + "-" + leave.ReturnTime.Month + "-" + leave.ReturnTime.Day + " " + leave.ReturnTime.Hour + ":" + leave.ReturnTime.Minute,
                DormitoryId = leave.DormitoryId,
                DormitoryName = leave.DormitoryName

            };
            return model;

        }
        public int LeaveDelete(int id)
        {
            Leave leave = _myDbContext.Leave.FirstOrDefault(s => s.Id == id);
            int count = 0;
            if (leave != null)
            {
                _myDbContext.Leave.Remove(leave);
                count = _myDbContext.SaveChanges();
            }
            return count;
        }

        public leaveIndexModel GetLeaveCode(string Code)
        {

            var leave = _myDbContext.Leave.Join(_myDbContext.Dormitory, //添加外键
                      a => a.DormitoryId,
                      b => b.Id,
                     (a, b) => new
                     {
                         a.Id,
                         a.Code,
                         a.Name,
                         a.DormitoryId,
                         a.LeaveTime,
                         a.ReturnTime,
                         a.Phone,
                         a.leaveReason,
                         a.PhotoPath,
                         DormitoryName = b.DorName
                     }).Where(s => s.Code == Code).FirstOrDefault(); //转化为集合
            leaveIndexModel model = new leaveIndexModel
            {
                Id = leave.Id,
                Code = leave.Code,
                Name = leave.Name,
                Phone = leave.Phone,
                leaveReason = leave.leaveReason,
                PhotoPath = leave.PhotoPath,
                LeaveTime = leave.LeaveTime.Year + "-" + leave.LeaveTime.Month + "-" + leave.LeaveTime.Day + " " + leave.LeaveTime.Hour + ":" + leave.LeaveTime.Minute,
                ReturnTime = leave.LeaveTime.Year + "-" + leave.LeaveTime.Month + "-" + leave.LeaveTime.Day + " " + leave.LeaveTime.Hour + ":" + leave.LeaveTime.Minute,
                DormitoryId = leave.DormitoryId,
                DormitoryName = leave.DormitoryName

            };
            return model;

        }
        public int HygieneDelete(int id)
        {
            DormitoryHygiene dormitoryHygiene = _myDbContext.DormitoryHygiene.FirstOrDefault(s => s.Id == id);
            int count = 0;
            if (dormitoryHygiene != null)
            {
                _myDbContext.DormitoryHygiene.Remove(dormitoryHygiene);
                count = _myDbContext.SaveChanges();
            }
            return count;
        }
        //获得全部缺勤记录

        //分页---学生缺勤index
        public List<AbsenceDetailModels> GetStuAbsence(string code, int pageIndex, int pageSize, out int totalPage)
        {
            //方法一：join方法
            var absence = _myDbContext.Absence.Join(_myDbContext.Dormitory, //添加外键
                      a => a.DormitoryId,
                      b => b.Id,
                     (a, b) => new
                     {
                         a.Id,
                         a.Code,
                         a.Name,
                         a.DormitoryId,
                         a.Time,
                         a.Remark,
                         DormitoryName = b.DorName  //结果集里面要哪些字段
                     }).Where(s => s.Code == code).ToList(); //转化为集合
            if (pageIndex <= 0)
                pageIndex = 1;
            int totalCount = absence.Count();
            totalPage = (int)Math.Ceiling(totalCount / (double)pageSize);//获得最小页数
            if (pageIndex > totalPage)
                pageIndex = totalPage;

            var pageList =absence.OrderBy(s => s.Id).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();//排序，得到一页的数据
            List<AbsenceDetailModels> list = new List<AbsenceDetailModels>();
            foreach (var item in pageList)
            {
                list.Add(new AbsenceDetailModels
                {
                    Id = item.Id,
                    Name = item.Name,
                    Code = item.Code,
                    Time = item.Time.Month + "月" + item.Time.Day + "日" + item.Time.Hour + "时" + item.Time.Minute + "分",
                    DormitoryId = item.DormitoryId,
                    Remark = item.Remark,
                    DormitoryName = item.DormitoryName

                });
            };
            return list;
        }
        public List<AbsenceDetailModels> GetStuAbsence(string code)
        {
            //方法一：join方法

            var absence = _myDbContext.Absence.Join(_myDbContext.Dormitory, //添加外键
                      a => a.DormitoryId,
                      b => b.Id,
                     (a, b) => new
                     {
                         a.Id,
                         a.Code,
                         a.Name,
                         a.DormitoryId,
                         a.Time,
                         a.Remark,
                         DormitoryName = b.DorName  //结果集里面要哪些字段
                     }).Where(s => s.Code == code).ToList(); //转化为集合

            List<AbsenceDetailModels> list = new List<AbsenceDetailModels>();
            foreach (var item in absence)
            {
                list.Add(new AbsenceDetailModels
                {
                    Id = item.Id,
                    Name = item.Name,
                    Code = item.Code,
                    Time = item.Time.Month + "月" + item.Time.Day + "日" + item.Time.Hour + "时" + item.Time.Minute + "分",
                    DormitoryId = item.DormitoryId,
                    Remark = item.Remark,
                    DormitoryName = item.DormitoryName

                });
            };
            return list;
        }
        public List<leaveIndexModel> GetOneLeave(string code)
        {
            var leave = _myDbContext.Leave.Join(_myDbContext.Dormitory, //添加外键
                    a => a.DormitoryId,
                    b => b.Id,
                   (a, b) => new
                   {
                       a.Id,
                       a.Code,
                       a.Name,
                       a.DormitoryId,
                       a.LeaveTime,
                       a.ReturnTime,
                       a.Phone,
                       a.leaveReason,
                       a.PhotoPath,
                       DormitoryName = b.DorName
                   }).Where(s => s.Code == code).ToList(); //转化为集合

            List<leaveIndexModel> list = new List<leaveIndexModel>();
            foreach (var item in leave)
            {
                list.Add(new leaveIndexModel
                {
                    Id = item.Id,
                    Code = item.Code,
                    Name = item.Name,
                    Phone = item.Phone,
                    leaveReason = item.leaveReason,
                    PhotoPath = item.PhotoPath,
                    LeaveTime = item.LeaveTime.Year + "-" + item.LeaveTime.Month + "-" + item.LeaveTime.Day + " " + item.LeaveTime.Hour + ":" + item.LeaveTime.Minute,
                    ReturnTime = item.LeaveTime.Year + "-" + item.LeaveTime.Month + "-" + item.LeaveTime.Day + " " + item.LeaveTime.Hour + ":" + item.LeaveTime.Minute,
                    DormitoryId = item.DormitoryId,
                    DormitoryName = item.DormitoryName

                });
            };
            return list;
        }

        //分页--StuleaveIndex
        public List<leaveIndexModel> GetOneLeave(string code, int pageIndex, int pageSize, out int totalPage)
        {
            var leave = _myDbContext.Leave.Join(_myDbContext.Dormitory, //添加外键
                    a => a.DormitoryId,
                    b => b.Id,
                   (a, b) => new
                   {
                       a.Id,
                       a.Code,
                       a.Name,
                       a.DormitoryId,
                       a.LeaveTime,
                       a.ReturnTime,
                       a.Phone,
                       a.leaveReason,
                       a.PhotoPath,
                       DormitoryName = b.DorName
                   }).Where(s => s.Code == code).ToList(); //转化为集合
            if (pageIndex <= 0)
                pageIndex = 1;
            int totalCount = leave.Count();
            totalPage = (int)Math.Ceiling(totalCount / (double)pageSize);//获得最小页数
            if (pageIndex > totalPage)
                pageIndex = totalPage;

            var pageList = leave.OrderBy(s => s.Id).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();//排序，得到一页的数据
            List<leaveIndexModel> list = new List<leaveIndexModel>();
            foreach (var item in pageList)
            {
                list.Add(new leaveIndexModel
                {
                    Id = item.Id,
                    Code = item.Code,
                    Name = item.Name,
                    Phone = item.Phone,
                    leaveReason = item.leaveReason,
                    PhotoPath = item.PhotoPath,
                    LeaveTime = item.LeaveTime.Year + "-" + item.LeaveTime.Month + "-" + item.LeaveTime.Day + " " + item.LeaveTime.Hour + ":" + item.LeaveTime.Minute,
                    ReturnTime = item.LeaveTime.Year + "-" + item.LeaveTime.Month + "-" + item.LeaveTime.Day + " " + item.LeaveTime.Hour + ":" + item.LeaveTime.Minute,
                    DormitoryId = item.DormitoryId,
                    DormitoryName = item.DormitoryName

                });
            };
            return list;
        }
        public List<DormitoryHygieneModels> HygieneSearch(string code)
        {
            var dor = _myDbContext.DormitoryHygiene.Join(_myDbContext.Dormitory, //添加外键
            a => a.DormitoryId,
            b => b.Id,
           (a, b) => new
           {
               a.Id,
               a.Code,
               a.Time,
               a.DormitoryId,
               a.Remark,
               DormitoryName = b.DorName
               //结果集里面要哪些字段
           }).Where(s => s.Code == code).ToList(); //满足条件的第一条记录

            List<DormitoryHygieneModels> list = new List<DormitoryHygieneModels>();
            foreach (var item in dor)
            {
                list.Add(new DormitoryHygieneModels
                {
                    Id = item.Id,
                    Code = item.Code,
                    Time = item.Time.Month + "月" + item.Time.Day + "日" + item.Time.Hour + "时" + item.Time.Minute + "分",
                    DormitoryId = item.DormitoryId,
                    DormitoryName = item.DormitoryName,
                    Remark = item.Remark
                });              
            }
            return list;


        }
    }
}
    

       
