using JatraApplication.Models;
using JatraApplication.Models.DatabaseModels;
using JatraApplication.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JatraApplication.Controllers
{
    
    public class UserAuthController : Controller
    {
        const string SessionUser = "_Name";
        const string SessionUserId = "_Age";
        public IActionResult Index()
        {
            //HttpContext.Session.SetString(SessionUser,"");
            //HttpContext.Session.SetString(SessionUserId, "");
            return View();
        }
        [HttpPost]
        public JsonResult LogOn(string userName, string password)
         {

            Userrepo users = new Userrepo();

            var getUser = users.getUsername(userName);

            if (getUser != null)
            {
                var hashCode = getUser.VCode;
                var encodingPasswordString = LoginHelper.EncodePassword(password, hashCode);


                var data = users.ValidateUser(userName, encodingPasswordString);
                if (data == true)
                {
                    //HttpContext.Session.SetString(SessionUser, getUser.UserName.ToString());
                    //HttpContext.Session.SetString(SessionUserId, getUser.UserId.ToString());
                   
                    return Json(getUser.Id);
                }
                else
                {
                    var msg = ViewBag.ErrorMessage = "Invallid Password!!!";
                    return Json(msg);
                }
            }
            else
            {
                var msg = ViewBag.ErrorMessage = "Invallid User Name!! please Try again";
                return Json(msg);
            }

        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SignUp(LoginModel users)
        {
            User entity = new User();
            Userrepo _userRepo = new Userrepo();

            var getUser = _userRepo.getUsername(users.UserName);
            if (getUser != null)
            {
                return Json("User is already registerd the email address:" + users.UserName);
            }

            try
            {

                var keyNew = LoginHelper.GeneratePassword(10);
                var password = LoginHelper.EncodePassword(users.Password, keyNew);
                _userRepo.VCode = keyNew;
                _userRepo.Password = password;
                _userRepo.Email = users.UserName;
                _userRepo.FirstName = users.FirstName;
                _userRepo.LastName = users.LastName;
                _userRepo.Roles = 1;
                int userId = _userRepo.AddUpdateUser();
                //HttpContext.Session.SetString(SessionUser, _userRepo.UserName);
                //HttpContext.Session.SetString(SessionUserId, userId.ToString());
                return Json(userId);
            }
            catch
            {
                return Json("Unable to register!!! Please Try Again");
            }
        }

    }
}
