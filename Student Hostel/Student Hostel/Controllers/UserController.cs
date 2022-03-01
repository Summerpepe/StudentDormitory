using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Hostel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace Student_Hostel.Controllers
{
    public class UserController : Controller
    {
        private readonly SysUserService _sysUserService;
        private readonly StuUserService _stuUserService;
        private readonly RegisterService _registerService;
        private readonly IWebHostEnvironment _webHostEnvironment;



        public UserController(SysUserService sysUserService, StuUserService stuUserService, RegisterService registerService, IWebHostEnvironment webHostEnvironment)
        {
            _sysUserService = sysUserService;
            _stuUserService = stuUserService;
            _registerService = registerService;
            _webHostEnvironment = webHostEnvironment;//获取环境变量


        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            SysUser user = new SysUser
            {
                //有用户名显示，没有用户名显示空
                Name = Request.Cookies["UserName"] != null ? Request.Cookies["UserName"] : "",
                Pwd = Request.Cookies["UserPwd"] != null ? Request.Cookies["UserPwd"] : "",
                Code = Request.Cookies["UserCode"] != null ? Request.Cookies["UserCode"] : "",

            };
            return View(user);
        }
        [HttpPost]
        public IActionResult Login(SysUser model)
        {
            string code = Request.Form["validateCode"].ToString().ToLower();
            string verifyCode = HttpContext.Session.GetString("ValidateCode").ToLower();
            //如果用户名和密码正确

            if (code == verifyCode)//用户输入的和系统自动生成的是否一样
            {
                if (_sysUserService.Login(model))
                {
                    //保存用户信息
                    HttpContext.Session.SetString("UserName", model.Name);
                    HttpContext.Session.SetString("UserPwd", model.Pwd);
                    HttpContext.Session.SetString("UserCode", model.Code);


                    //   HttpContext.Session.SetString("Code", model.Code);
                    //写到客户端机器上
                    Response.Cookies.Append("UserName", model.Name);
                    Response.Cookies.Append("UserPwd", model.Pwd);
                    Response.Cookies.Append("UserCode", model.Code);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Msg = "登录失败，用户名或密码不正确";
                }
            }
            else {
                ViewBag.Msg = "验证码错误!";
            }

            return View(model);
        }

        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        public IActionResult ValidateCode()
        {
            VerifyCodeServices _verifyCodeServices = new VerifyCodeServices();
            string code = "";
            MemoryStream ms = _verifyCodeServices.Create(out code);//把验证码写在session中保存下来，在登录界面中调取即可
            HttpContext.Session.SetString("ValidateCode", code);
            Request.Body.Dispose();
            return File(ms.ToArray(), @"images/png");
        }

        //学生登陆
        public IActionResult StuLogin()
        {
            StuUser user = new StuUser
            {
                //有用户名显示，没有用户名显示空
                Name = Request.Cookies["UserName"] != null ? Request.Cookies["UserName"] : "",
                Code = Request.Cookies["UserCode"] != null ? Request.Cookies["UserCode"] : "",
                Pwd = Request.Cookies["UserPwd"] != null ? Request.Cookies["UserPwd"] : "",

            };
            return View(user);
        }
        [HttpPost]
        public IActionResult StuLogin(StuUser model)
        {
            string code = Request.Form["validateCode"].ToString().ToLower();
            string verifyCode = HttpContext.Session.GetString("ValidateCode").ToLower();
            //如果用户名和密码正确
                if (code == verifyCode)//用户输入的和系统自动生成的是否一样
                {
                    //如果用户名和密码正确
                    if (_stuUserService.StuLogin(model))
                    {
                        //保存用户信息
                        HttpContext.Session.SetString("UserName", model.Name);
                        HttpContext.Session.SetString("UserCode", model.Code);
                        HttpContext.Session.SetString("UserPwd", model.Pwd);

                        //写到客户端机器上
                        Response.Cookies.Append("UserName", model.Name);
                        Response.Cookies.Append("UserCode", model.Code);
                        Response.Cookies.Append("UserPwd", model.Pwd);
                        return RedirectToAction("Index", "StuHome");
                    }
                    else
                    {
                        ViewBag.Msg = "登录失败，用户名或密码不正确!";
                    }
                }
                else
                {
                    ViewBag.Msg = "验证码错误!";

                }
           

            return View(model);
        }

        public IActionResult logout1()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("StuLogin");
        }



        //管理员注册
        public IActionResult ManRegister()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ManRegister(SysUser sysUser, IFormCollection collection)
        {
             int count = 0;
              string code = "";
            if (ModelState.IsValid)
            { 
                code = sysUser.Code;
                count = _registerService.ManRegister(sysUser, code);
            }
            else
                ViewBag.Msg = "注册失败！！";

            if (count > 0)
                ViewBag.Msg = "注册成功";
            else
                ViewBag.Msg = "注册失败,用户已存在";
            return View();
            
        }

        public IActionResult StuRegister()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StuRegister(StuUser stuUser)
        {
            int count = 0;
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("UserCode", stuUser.Code);
                string code = HttpContext.Session.GetString("UserCode");
                count = _registerService.StuRegister(stuUser, code);
            }
            else
                   ViewBag.Msg = "注册失败！";

            if (count > 0)
                ViewBag.Msg = "注册成功";
            else
                ViewBag.Msg = "用户名已存在或没有住宿信息";
            return View();

        }

        

    }
}

    


