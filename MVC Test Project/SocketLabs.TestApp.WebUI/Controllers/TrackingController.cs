using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocketLabs.TestApp.Domain.Abstract;
using SocketLabs.TestApp.Domain.Entities;

namespace SocketLabs.TestApp.WebUI.Controllers
{
    public class TrackingController : Controller
    {
        private readonly IUserRepository _UserRepository;
        public TrackingController(IUserRepository repository)
        {
            _UserRepository = repository;
        }

        public Infrastructure.ImageResult ShowImage(int userid = 0)
        {
            User user = _UserRepository.Users.SingleOrDefault(x => x.UserId == userid);
            user.ImageViews++;
            _UserRepository.SaveUser(user);

            string filePath = Server.MapPath(Url.Content("~/Images/socketpeople.jpg"));
            return new Infrastructure.ImageResult(filePath);
        }


    }
}
