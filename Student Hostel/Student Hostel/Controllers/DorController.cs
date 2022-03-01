using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Hostel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Hostel.Controllers
{
    public class DorController : Controller  //控制器从模型中获取数据，把获取的数据传递给视图
    {
        private DormitoryService _dormitoryService;
     
        public DorController(DormitoryService dormitoryService)
        {
            _dormitoryService = dormitoryService;

        }
        public IActionResult Index(int pageIndex)
        {
            if (pageIndex <= 0)
                pageIndex = 1;
            int pageSize = 5;
            int totalPage;
            List<Dormitory> list = _dormitoryService.GetAllDormitories(pageIndex, pageSize, out totalPage);
            ViewBag.PageIndex = pageIndex;
            ViewBag.totalPage = totalPage;
            return View(list);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Dormitory dormitory)
        {
            int count = 0;
            HttpContext.Session.SetString("DorName",dormitory.DorName);
            string dorname = HttpContext.Session.GetString("DorName");
             count = _dormitoryService.Add(dormitory,dorname);
            //根据执行结果给用户一个反馈
            if (count > 0)
                ViewBag.Msg = "添加成功";
            else
                ViewBag.Msg = "添加失败!该宿舍已添加";
            return View();
        }
        public IActionResult Details(int id)
        {
           Dormitory model = _dormitoryService.GetDor(id);
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            Dormitory dormitory= _dormitoryService.GetDormitoryByName(id);
            return View(dormitory);
        }
        [HttpPost]
        public IActionResult Edit(Dormitory dormitory)
        {
            int count = _dormitoryService.Update(dormitory);
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            int count =_dormitoryService.Delete(id);
            if (count > 0)
                ViewBag.Msg = "成功删除学生信息";
            else
                ViewBag.Msg = "删除失败";
            return RedirectToAction("Index");

        }
        public IActionResult Search(string SearchString)
        {
            // string search = Request.Form["SearchString"];
            List<Dormitory> list = _dormitoryService.Search(SearchString);
            return View("index", list);
        }
    }
}
