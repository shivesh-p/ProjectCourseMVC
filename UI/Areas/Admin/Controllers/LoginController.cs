using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserBLL _userBll = new UserBLL();
        public LoginController()
        {
        }

        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserDTO user)
        {
            if (user.Username != null && user.Password != null)
            {
                UserDTO us = _userBll.GetUserWithUsernameAndPassword(user);
                if (us != null)
                {
                    if (us.ID != 0)
                    {
                        UserStatic.UserID = us.ID;
                        UserStatic.Namesurname = us.Name;
                        UserStatic.Imagepath = us.Imagepath;
                        UserStatic.isAdmin = us.isAdmin;
                        //no process id yet hence 12 is hardcoded for now
                        LogBLL.AddLog(General.ProcessType.Login, General.TableName.Login, -111);
                        return RedirectToAction("PostList", "Post");
                    }
                }
                return View(user);
            }
            else
            {
                return View(user);
            }
        }
    }
}