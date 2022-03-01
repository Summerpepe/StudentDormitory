using Student_Hostel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Hostel.Models
{
    public interface IStudentService
    {
        public int Add(Student student,string code);
        public int Delete(int id);
        public int RepairDelete(int id);
        public int AbsenDelete(int id);
        public int LeaveDelete(int id);
        public int HygieneDelete(int id);


        public List<StudentDetail> Search(string code);
        public List<DormitoryHygieneModels> HygieneSearch(string code);
        public int Update(Student student);
        public int SysUpdate(SysUser sysUser);
        public int StuUpdate(StuUser stuUser);
        public List<StudentDetail > GetAllStudents();
        public List<StudentDetail> GetAllStudents(int pageIndex, int pageSize, out int totalPage);
        public List<AbsenceDetailModels> GetAllAbsence(int pageIndex, int pageSize, out int totalPage);
        public List<DormitoryHygieneModels> GetAllHygiene(int pageIndex, int pageSize, out int totalPage);
        public List<leaveIndexModel> GetAllLeave(int pageIndex, int pageSize, out int totalPage);
        public List<RepairIndexModel> GetAllRepairs(int pageIndex, int pageSize, out int totalPage);
        public List<AbsenceDetailModels> GetStuAbsence(string code, int pageIndex, int pageSize, out int totalPage);
        public List<leaveIndexModel> GetOneLeave(string code, int pageIndex, int pageSize, out int totalPage);

       public List<AbsenceDetailModels> GetAllAbsence();
        public List<AbsenceDetailModels> GetStuAbsence(string code);
        public List<DormitoryHygieneModels> GetAllHygiene();
        public List<RepairIndexModel> GetAllRepairs();
        public List<leaveIndexModel> GetAllLeave();
        public RepairIndexModel GetRepair(int id);
        public leaveIndexModel GetLeave(int id);

        public Student GetStudentById(int id);
        public StudentDetail GetStudent(int id);
        public SysUserDetail GetSys(string code);
        public List<leaveIndexModel> GetOneLeave(string code);
        public StuUser GetStu(string code);
        public StudentDetail GetOneStudent(string code);
        public leaveIndexModel GetLeaveCode(string Code);
        public SysUser GetSysEdit(string code);
        public StuUser GetStuEdit(string code);
        public int AddAbsence(Absence absence);
        public int AddRepair(Repair repair);
        public int AddLeave(Leave leave,string name,string code);
        public int AddHygiene(DormitoryHygiene dormitoryHygiene);


    }
}
