using Microsoft.AspNetCore.Mvc;
using Student_Hostel.ViewModels;
using Student_Hostel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Student_Hostel.Controllers
{
    public class HomeController :BaseController1
    {
        private readonly IStudentService _studentService;
        private readonly DormitoryService _dormitoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IStudentService studentService,DormitoryService dormitoryService,IWebHostEnvironment webHostEnvironment)
        {
            _studentService = studentService;
            _dormitoryService = dormitoryService;
            _webHostEnvironment = webHostEnvironment;//获取环境变量
        }
        
        public IActionResult Index(int pageIndex)
        {
            if (pageIndex <= 0)
                pageIndex = 1;
            int pageSize = 5;
            int totalPage;
            List<StudentDetail> list = _studentService.GetAllStudents(pageIndex,pageSize,out totalPage);
            ViewBag.PageIndex = pageIndex;
            ViewBag.totalPage = totalPage;

            return View(list);
        }
        public IActionResult Add()
        {
            List<Dormitory> list = _dormitoryService.GetAllDormitories();
            return View(list);

        }
        [HttpPost]
        public async Task<IActionResult> Add(Student student,IFormCollection collection)
        {
            //bool sex = false;
            //if (student.Sex > 0)
            //    sex = true;
            //Student s = new Student
            //{
            //    Code = student.Code,
            //    Name = student.Name,
            //    Sex = sex,
            //    DormitoryId = student.DepartmentId,
            //    Birth = student.Birth,
            //    Phone = student.Phone,
            //    DepartmentId = student.DepartmentId,
            //    Remark = student.Remark
            //};
            //_studentService.Add(s);
            // return View();
            int count = 0;
            List<Dormitory> list = _dormitoryService.GetAllDormitories();
            if (student.Code != null)
            {
                string code = student.Code;
                var files = collection.Files;
                if (files.Count > 0)
                {
                    string webPath = _webHostEnvironment.WebRootPath;//获取程序根目录
                    string absolutePath = webPath + "\\images";
                    string[] fileType = new string[] { ".gif", ".jpg", ".jpeg", ".png" };//规定上传文件的类型
                    string extension = Path.GetExtension(files[0].FileName);//获取上传文件的扩展名
                    if (fileType.Contains(extension))
                    {
                        if (!Directory.Exists(absolutePath))
                        {
                            Directory.CreateDirectory(absolutePath);
                        }
                        string fileName = DateTime.Now.ToString("yyyyMMDDhhmmss") + extension;
                        //利用时间保存保存在服务器上的文件名
                        string filePath = absolutePath + "\\" + fileName;
                        using (var stream = new FileStream(filePath, FileMode.Create))//以文件流的形式保存
                        {
                            await files[0].CopyToAsync(stream);//异步拷贝

                        }
                        student.PhotoPath = fileName;
                        count = _studentService.Add(student, code);
                    }
                    else
                        ViewBag.Msg = "上传文件的类型为  .gif, .jpg, .jpeg, .png ";
                    //提示上传文件类型错误
                }
                            
            if (count > 0)
                ViewBag.Msg = "添加成功";
            else
                ViewBag.Msg = "添加失败!该学生已存在";
                }
            else

                ViewBag.Msg = "学号不可为空！！";

            return View(list);

        }
        public IActionResult Details(int id)
        {
            StudentDetail model = _studentService.GetStudent(id);
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            int count = _studentService.Delete(id);
            if (count > 0)
                ViewBag.Msg = "成功删除学生信息";
            else
                ViewBag.Msg = "删除失败";
            return RedirectToAction("Index");

        }
        //向视图传递学生信息和学院列表信息
        public IActionResult Edit(int id)
        {
            StudentEditModel model = new StudentEditModel();
            Student student= _studentService.GetStudentById(id);
            model.student = student;
            List<Dormitory> list = _dormitoryService.GetAllDormitories();
            model.Dormitories = list;
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            int count = _studentService.Update(student);
            return RedirectToAction("Index");

        }
        public IActionResult Search(string  SearchString )
        {
           // string search = Request.Form["SearchString"];
            List<StudentDetail> list=_studentService.Search(SearchString);
            return View("index", list);
        }

        //添加学生的缺勤情况
        public IActionResult AddAbsence()
        {
            List<Dormitory> list = _dormitoryService.GetAllDormitories();
            return View(list);

        }
        [HttpPost]
        public IActionResult AddAbsence(Absence absence)
        {
            int count = 0;
            List<Dormitory> list = _dormitoryService.GetAllDormitories();
            count = _studentService.AddAbsence(absence);
           
            if (count > 0)
                ViewBag.Msg = "提交成功";
            else
                ViewBag.Msg = "提交失败！没有该学生！";
            return View(list);

        }
        //查看学生考勤情况
        public IActionResult AbsenceIndex(int pageIndex)
        {
           
                if (pageIndex <= 0)
                    pageIndex = 1;
                int pageSize = 5;
                int totalPage;
                List<AbsenceDetailModels> list = _studentService.GetAllAbsence(pageIndex, pageSize, out totalPage);
                ViewBag.PageIndex = pageIndex;
                ViewBag.totalPage = totalPage;

                return View(list);
            }
           
       
        public IActionResult AbsenceDelete(int id)
        {
            int count = _studentService.AbsenDelete(id);
            if (count > 0)
                ViewBag.Msg = "删除成功";
            else
                ViewBag.Msg = "删除失败";
            return RedirectToAction("AbsenceIndex");

        }
        //添加宿舍卫生情况
        public IActionResult AddHygiene()
        {
            ViewData["UserCode"] = HttpContext.Session.GetString("UserCode");
            List<Dormitory> list = _dormitoryService.GetAllDormitories();
            return View(list);

        }
        [HttpPost]
        public IActionResult AddHygiene(DormitoryHygiene dormitoryHygiene)
        {
            ViewData["UserCode"] = HttpContext.Session.GetString("UserCode");
            List<Dormitory> list = _dormitoryService.GetAllDormitories();
            int count = _studentService.AddHygiene(dormitoryHygiene);
            if (count > 0)
                ViewBag.Msg = "提交成功";
            else
                ViewBag.Msg = "提交失败";
            return View(list);
           
        }
        //查看宿舍情况
        public IActionResult HygieneIndex(int pageIndex)
        {
            if (pageIndex <= 0)
                pageIndex = 1;
            int pageSize = 5;
            int totalPage;
            List<DormitoryHygieneModels> list = _studentService.GetAllHygiene(pageIndex, pageSize, out totalPage);
            ViewBag.PageIndex = pageIndex;
            ViewBag.totalPage = totalPage;

            return View(list);
          
        }
        //查看个人信息
        public IActionResult SysDetails()
        {
            string code= HttpContext.Session.GetString("UserCode");
            SysUserDetail model = _studentService.GetSys(code);
            return View(model);
        }
        public IActionResult SysEdit()
        {
      
            string code = HttpContext.Session.GetString("UserCode");
            SysUser model = _studentService.GetSysEdit(code);
            return View(model);
        }
        [HttpPost]
        public IActionResult SysEdit(SysUser  sysUser)
        {
            string code = HttpContext.Session.GetString("UserCode");
            int count = 0;
            if (ModelState.IsValid)
            {

                count=_studentService.SysUpdate(sysUser);
            }
            if (count==0)
            {
                SysUser model = _studentService.GetSysEdit(code);
                return View(model);
            }
            
            return RedirectToAction("SysDetails");

        }

        //查看报修情况
        public IActionResult RepairIndex(int pageIndex)
        {
            if (pageIndex <= 0)
                pageIndex = 1;
            int pageSize = 5;
            int totalPage;
            List<RepairIndexModel> list = _studentService.GetAllRepairs(pageIndex, pageSize, out totalPage);
            ViewBag.PageIndex = pageIndex;
            ViewBag.totalPage = totalPage;
            return View(list);
        }
        public IActionResult RepairDetails(int id)
        {
            RepairIndexModel model = _studentService.GetRepair(id);
            return View(model);
        }
        public IActionResult RepairDelete(int id)
        {
            int count = _studentService.RepairDelete(id);
            if (count > 0)
                ViewBag.Msg = "成功删除";
            else
                ViewBag.Msg = "删除失败";
            return RedirectToAction("RepairIndex");

        }
        public IActionResult LeaveIndex(int pageIndex)
        {
            if (pageIndex <= 0)
                pageIndex = 1;
            int pageSize = 5;
            int totalPage;
            List<leaveIndexModel> list = _studentService.GetAllLeave(pageIndex, pageSize, out totalPage);
            ViewBag.PageIndex = pageIndex;
            ViewBag.totalPage = totalPage;

            return View(list);
           
        }
        public IActionResult LeaveDetails(int id)
        {
            leaveIndexModel model = _studentService.GetLeave(id);
            return View(model);
        }
        public IActionResult LeaveDelete(int id)
        {
            int count = _studentService.LeaveDelete(id);
            if (count > 0)
                ViewBag.Msg = "成功删除";
            else
                ViewBag.Msg = "删除失败";
            return RedirectToAction("LeaveIndex");

        }
        public IActionResult HygieneDelete(int id)
        {
            int count = _studentService.HygieneDelete(id);
            if (count > 0)
                ViewBag.Msg = "成功删除";
            else
                ViewBag.Msg = "删除失败";
            return RedirectToAction("HygieneIndex");

        }
        //查找宿舍报修
        public IActionResult RepairSearch(string SearchString,int pageIndex)
        {
            if (pageIndex <= 0)
                pageIndex = 1;
            int pageSize = 5;
            int totalPage;
            List<RepairIndexModel> list1 = _studentService.GetAllRepairs(pageIndex, pageSize, out totalPage);
            ViewBag.PageIndex = pageIndex;
            ViewBag.totalPage = totalPage;
            List<RepairIndexModel> list = _dormitoryService.RepairSearch(SearchString);
            if (list == null)
            {
                ViewBag.Msg = "没有该宿舍！";
                return View("RepairIndex", list1);
            }
            else
                return View("RepairIndex", list);
        }


    public IActionResult LeaveSearch(string SearchString)
        { 
            // string search = Request.Form["SearchString"];
           List<leaveIndexModel> list=_studentService.GetOneLeave(SearchString);
            return View("LeaveIndex", list);
        }
        public IActionResult AbsenceSearch(string SearchString)
        {
            // string search = Request.Form["SearchString"];
            List<AbsenceDetailModels> list = _studentService.GetStuAbsence(SearchString);
         
            return View("AbsenceIndex", list);
        }
        public IActionResult HygieneSearch(string SearchString,int pageIndex)
        {
            if (pageIndex <= 0)
                pageIndex = 1;
            int pageSize = 5;
            int totalPage;
            List<DormitoryHygieneModels> list1 = _studentService.GetAllHygiene(pageIndex, pageSize, out totalPage);
            ViewBag.PageIndex = pageIndex;
            ViewBag.totalPage = totalPage;
            List<DormitoryHygieneModels> list = _dormitoryService.HygieneSearch(SearchString);
            if (list == null)
            {
                ViewBag.Msg = "没有该宿舍！";
                return View("HygieneIndex", list1);
            }
            else
                return View("HygieneIndex", list);
        }
        




    }
}
