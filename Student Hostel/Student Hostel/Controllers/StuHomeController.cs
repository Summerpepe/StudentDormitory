using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Hostel.Models;
using Student_Hostel.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Hostel.Controllers
{
    public class StuHomeController : BaseController2
    {
        private readonly IStudentService _studentService;
        private readonly DormitoryService _dormitoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StuHomeController(IStudentService studentService, DormitoryService dormitoryService, IWebHostEnvironment webHostEnvironment)
        {
            _studentService = studentService;
            _dormitoryService = dormitoryService;
            _webHostEnvironment = webHostEnvironment;//获取环境变量
        }

        //查看学生全部信息

        public IActionResult Index()
        {
            string code = HttpContext.Session.GetString("UserCode");
            StudentDetail model = _studentService.GetOneStudent(code);
            return View(model);

        }


        //查看学生考勤情况
        public IActionResult AbsenceIndex(int pageIndex)
        {
            string code = HttpContext.Session.GetString("UserCode");
            if (pageIndex <= 0)
                pageIndex = 1;
            int pageSize = 5;
            int totalPage;
            List<AbsenceDetailModels> list = _studentService.GetStuAbsence(code,pageIndex,pageSize, out totalPage);
            
            ViewBag.PageIndex = pageIndex;
            ViewBag.totalPage = totalPage;

            return View(list);
        }
        //查看宿舍信息
        public IActionResult DorIndex(int pageIndex)
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
        //宿舍报修
        public IActionResult AddRepair()
        {
            List<Dormitory> list = _dormitoryService.GetAllDormitories();
            return View(list);

        }
        [HttpPost]
        public IActionResult AddRepair(Repair repair)
        {

            int count = _studentService.AddRepair(repair);
            List<Dormitory> list = _dormitoryService.GetAllDormitories();
            if (count > 0)
                ViewBag.Msg = "报修成功";
            else
                ViewBag.Msg = "报修失败";
            return View(list);

        }
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
        public IActionResult Addleave()
        {
            ViewData["UserCode"] = HttpContext.Session.GetString("UserCode");
            List<Dormitory> list = _dormitoryService.GetAllDormitories();
            return View(list);

        }
        //public IActionResult AddLeave()
        //{
        //    List<Dormitory> list = _dormitoryService.GetAllDormitories();
        //    return View(list);
        //    //string code = HttpContext.Session.GetString("UserCode");
        //    //leaveIndexModel model = _studentService.GetLeaveCode(code);
        //    //return View(model);

        //}
        [HttpPost]
        public async Task<IActionResult> Addleave(Leave leave, IFormCollection collection)
        {
            ViewData["UserCode"] = HttpContext.Session.GetString("UserCode");
            int count = 0;
            HttpContext.Session.SetString("UserName", leave.Name);
            string name = HttpContext.Session.GetString("UserName");
            string code = HttpContext.Session.GetString("UserCode");
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
                    leave.PhotoPath = fileName;
                    count = _studentService.AddLeave(leave,name,code);
                }
            }
            List<Dormitory> list = _dormitoryService.GetAllDormitories();
            if (count > 0)
                ViewBag.Msg = "提交成功";
            else
                ViewBag.Msg = "提交失败!姓名不正确！";
            return View(list);

        }

        //查看个人信息
        public IActionResult StuDetails()
        {
            string code = HttpContext.Session.GetString("UserCode");
            StuUser model = _studentService.GetStu(code);
            return View(model);
        }
        //修改个人信息
        public IActionResult StuEdit()
        {
            string code = HttpContext.Session.GetString("UserCode");
            StuUser model = _studentService.GetStuEdit(code);
            return View(model);
           
        }
        [HttpPost] 
        public IActionResult StuEdit(StuUser stuUser)
        {
            string code = HttpContext.Session.GetString("UserCode");
            int count = 0;
            if (ModelState.IsValid)
            {

                count = _studentService.StuUpdate(stuUser);
            }
            if (count == 0)
            {
                StuUser model = _studentService.GetStuEdit(code);
                return View(model);
            }

            return RedirectToAction("StuDetails");

        }
        //查看宿舍卫生
        public IActionResult Search(string SearchString, int pageIndex)
        {
            // string search = Request.Form["SearchString"];
            if (pageIndex <= 0)
                pageIndex = 1;
            int pageSize = 5;
            int totalPage;
            List<DormitoryHygieneModels> list1 = _studentService.GetAllHygiene(pageIndex, pageSize, out totalPage);
            ViewBag.PageIndex = pageIndex;
            ViewBag.totalPage = totalPage;
            List<DormitoryHygieneModels> list = _dormitoryService.HygieneSearch(SearchString);
            if (list==null)
            {
                ViewBag.Msg = "没有该宿舍！";
                return View("DorIndex",list1);
            }
           else               
            return View("DorIndex", list);
        }
       
        public IActionResult HygieneDetails(int id)
        {
            DormitoryHygieneModels model = _dormitoryService.HygieneDetails(id);
            return View(model);
        }
        //搜索报修信息
        public IActionResult RepairSearch(string SearchString,int pageIndex)
        {
            if (pageIndex <= 0)
                pageIndex = 1;
            int pageSize = 5;
            int totalPage;
            List<RepairIndexModel> list1 = _studentService.GetAllRepairs(pageIndex, pageSize, out totalPage);
            ViewBag.PageIndex = pageIndex;
            ViewBag.totalPage = totalPage;
           List<RepairIndexModel>list = _dormitoryService.RepairSearch(SearchString);
            if (list ==null)
            {
                ViewBag.Msg = "没有该宿舍！";
                return View("RepairIndex", list1);
            }
            else
            return View("RepairIndex", list);
        }
        public IActionResult MyLeave(int pageIndex)
        {
            string code = HttpContext.Session.GetString("UserCode");
            if (pageIndex <= 0)
                pageIndex = 1;
            int pageSize = 5;
            int totalPage;
            List<leaveIndexModel> list = _studentService.GetOneLeave(code, pageIndex, pageSize, out totalPage);
            ViewBag.PageIndex = pageIndex;
            ViewBag.totalPage = totalPage;
            return View(list);

        }
        public IActionResult LeaveDelete(int id)
        {
            int count = _studentService.LeaveDelete(id);
            if (count > 0)
                ViewBag.Msg = "成功撤回";
            else
                ViewBag.Msg = "撤回失败";
            return RedirectToAction("MyLeave");

        }
    }


    }

