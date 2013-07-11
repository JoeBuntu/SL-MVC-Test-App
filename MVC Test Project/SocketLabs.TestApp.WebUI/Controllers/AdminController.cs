using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocketLabs.TestApp.Domain.Abstract;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using SocketLabs.TestApp.Domain.Entities;

namespace SocketLabs.TestApp.WebUI.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        private readonly IUserRepository _UserRepository;
        public AdminController(IUserRepository repository)
        {
            _UserRepository = repository;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Customer image statistics";
            return View();
        }

        public ActionResult ReadStatistics([DataSourceRequest] DataSourceRequest request)
        {
            IQueryable<User> users = _UserRepository.Users;
            DataSourceResult result = users.ToDataSourceResult(request);
            return Json(result);
        }

    }
}
