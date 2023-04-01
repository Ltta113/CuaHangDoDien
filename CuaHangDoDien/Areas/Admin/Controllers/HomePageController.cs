using CuaHangDoDien.Models.DBConection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CuaHangDoDien.DAO;
using CuaHangDoDien.Models;
using System.Xml.Linq;


namespace CuaHangDoDien.Areas.Admin.Controllers
{
    public class HomePageController : Controller
    {
        // GET: Admin/HomePage
        Account_DAO account_DAO = new Account_DAO();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            string name = username;
            string pass = password;
            Account acc = account_DAO.getAcc(name);
            string err = "";
            if (acc != null)
            {
                if (acc.Password.Replace(" ","") == pass)
                {
                    Session["UserName"] = name;
                    Session["Password"] = pass;
                    Session["Quyen"] = "0";
                    Session["ID_Account"] = acc.ID_Account.ToString();
                    Response.Redirect("~/Admin/HomePage");
                }
                else err = "Mật khẩu không hợp lệ";
            }
            else
            {
                err = "Tên đăng nhập không hợp lệ";
            }
            ViewBag.Error = "<p class='text-danger'> "+err +"</p>";
            return View();
        }
        public ActionResult Logout()
        {
            Session["UserName"] = "";
            Session["Password"] = "";
            Session["Quyen"] = "";
            Session["ID_Account"] = "";
            Response.Redirect("~/Admin/HomePage/Login");
            return null;
        }
    }
}