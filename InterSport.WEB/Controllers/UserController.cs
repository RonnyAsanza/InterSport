using InterSport.Domain.Entities;
using InterSport.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterSport.WEB.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult GetListUsers()
        {
            var users = _userService.GetListUsers();
            return PartialView("~/Views/User/ListUsers.cshtml", users);
        }
        public ActionResult DeleteUser(int userId)
        {
            _userService.DeleteUserById(userId);
            return GetListUsers();
        }
        public ActionResult SaveUser(User user)
        {
            user.DateRegistration = DateTime.Now;
            if (user.UserId > 0) _userService.UpdateUser(user);
            else _userService.CreateUser(user);
            return GetListUsers();
        }
    }
}