using Student_Hostel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Hostel.Models
{
    public class DormitoryService
    {
        private readonly MyDbContext _myDbContext;

        public DormitoryService(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public int Add(Dormitory dormitory, string dorname)
        {
            int count = 0;
            if (_myDbContext.Dormitory.FirstOrDefault(s => s.DorName == dorname) == null)
            {

                _myDbContext.Dormitory.Add(dormitory);
                count = _myDbContext.SaveChanges();//SaveChanges()方法更新到数据库里面，返回值是整型，对数据库有影响的行数
            }//SaveChanges()方法更新到数据库里面，返回值是整型，对数据库有影响的行数
            return count;

        }
        public List<Dormitory> GetAllDormitories(int pageIndex, int pageSize, out int totalPage)
        {

            var dormitories = _myDbContext.Dormitory.ToList();
            if (pageIndex <= 0)
                pageIndex = 1;
            int totalCount = dormitories.Count();
            totalPage = (int)Math.Ceiling(totalCount / (double)pageSize);//获得最小页数
            if (pageIndex > totalPage)
                pageIndex = totalPage;


            List<Dormitory> pageList = dormitories.OrderBy(s => s.Id).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();//排序，得到一页的数据
            return pageList;
        }
        public List<Dormitory> GetAllDormitories()
        {

            List<Dormitory> list = _myDbContext.Dormitory.ToList<Dormitory>();
            return list;
        }
        public Dormitory GetDormitoryByName(int id)
        {

            Dormitory dormitory = _myDbContext.Dormitory.FirstOrDefault(s => s.Id == id);
            return dormitory;
        }
        public Dormitory GetDor(int id)
        {
            var dormitory = _myDbContext.Dormitory.FirstOrDefault(s => s.Id == id);
            Dormitory model = new Dormitory  //赋值
            {
                Id = dormitory.Id,
                DorName = dormitory.DorName,
                NumPeople = dormitory.NumPeople,
                PeopleName = dormitory.PeopleName,
                Remark = dormitory.Remark

            };
            return model;
        }
        public int Update(Dormitory dormitory)
        {
            Dormitory updatedormitory = _myDbContext.Dormitory.FirstOrDefault(s => s.Id == dormitory.Id);
            int count = 0;
            if (updatedormitory != null)
            {
                updatedormitory.DorName = dormitory.DorName;
                updatedormitory.NumPeople = dormitory.NumPeople;
                updatedormitory.PeopleName = dormitory.PeopleName;
                updatedormitory.Remark = dormitory.Remark;
                _myDbContext.Update(updatedormitory);
                count = _myDbContext.SaveChanges();
            }
            return count;
        }
        public int Delete(int id)
        {
            Dormitory dormitory = _myDbContext.Dormitory.FirstOrDefault(s => s.Id == id);
            int count = 0;
            if (dormitory != null)
            {
                _myDbContext.Dormitory.Remove(dormitory);
                count = _myDbContext.SaveChanges();
            }
            return count;
        }
        //搜索
        public List<Dormitory> Search(string dorname)
        {

            // return _myDbContext.Student.Include("Dormitory").Where(a => a.Name.Contains(name)).ToList();
            //where筛选集合中的项
            List<Dormitory> list = _myDbContext.Dormitory.Where(s => s.DorName.Contains(dorname)).ToList();
            return list;

        }
        public List<DormitoryHygieneModels> HygieneSearch(string dorname)
        {

            var dormitory = _myDbContext.Dormitory.FirstOrDefault(s => s.DorName == dorname);

            List<DormitoryHygieneModels> list = null;
            if (dormitory != null)
            {
                int dormitortid = dormitory.Id;
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
                  }).Where(s => s.DormitoryId == dormitortid).ToList(); //满足条件的第一条记录


                list = new List<DormitoryHygieneModels>();
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
            }
            return list;

        }
        public DormitoryHygieneModels HygieneDetails(int id)
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
                  }).Where(s => s.Id == id).FirstOrDefault(); //满足条件的第一条记录
            DormitoryHygieneModels model = new DormitoryHygieneModels  //赋值
            {
                Id = dor.Id,
                Code = dor.Code,
                Time = dor.Time.Month + "月" + dor.Time.Day + "日" + dor.Time.Hour + "时" + dor.Time.Minute + "分",
                DormitoryId = dor.DormitoryId,
                DormitoryName = dor.DormitoryName,
                Remark = dor.Remark
            };
            return model;
        }

        //搜索报修信息
        public List<RepairIndexModel> RepairSearch(string dorname)
        {
            List<RepairIndexModel> list = null;
            var dormitory = _myDbContext.Dormitory.FirstOrDefault(s => s.DorName == dorname);
            if (dormitory != null)
            {
                int dormitortid = dormitory.Id;
                var dor = _myDbContext.Repair.Join(_myDbContext.Dormitory, //添加外键
                   a => a.DormitoryId,
                   b => b.Id,
                  (a, b) => new
                  {
                      a.Id,
                      a.Time,
                      a.DormitoryId,
                      a.Remark,
                      DormitoryName = b.DorName
                      //结果集里面要哪些字段
                  }).Where(s => s.DormitoryId == dormitortid).ToList(); //满足条件的第一条记录

                list = new List<RepairIndexModel>();//赋值
                foreach (var item in dor)
                {
                    list.Add(new RepairIndexModel
                    {
                        Id = item.Id,
                        Time = item.Time.Month + "月" + item.Time.Day + "日" + item.Time.Hour + "时" + item.Time.Minute + "分",
                        DormitoryId = item.DormitoryId,
                        DormitoryName = item.DormitoryName,
                        Remark = item.Remark
                    });
                }
            }
                return list;



            }
        }
    }

