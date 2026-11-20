using Microsoft.AspNetCore.Mvc;
using ShriShriTech.Data;
using ShriShriTech.Services;

namespace ShriShriTech.Controllers
{
    public class TechUserController : Controller
    {

        private readonly ITechUser _obj;

        public TechUserController(ITechUser obj) 
        {
            _obj = obj; 
        }

        [HttpGet]
        public IActionResult TechUserIndex()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TechUserIndex(user user)
        {
            try 
            {
                if (!ModelState.IsValid)
                {

                    return View(user);

                }
                var IsAdded = await _obj.AddUser(user);
                if (!IsAdded)
                {
                    ModelState.AddModelError(string.Empty, "An error occured while registring please try again!");
                    return View(user);
                }

                TempData["SuccessMessage"] = "User Registered Successfully";

                return RedirectToAction(nameof(checkAuth));

            }
            catch (Exception ex) 
            {
                ModelState.AddModelError(string.Empty, "An error occured while registring please try again!");
                return View(user);
            }
            
        }
        [HttpGet]
        public async Task<ActionResult> checkAuth() 
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> checkAuth(CheckAuth usr) 
        {
            try 
            {
                if (!ModelState.IsValid) 
                {
                    TempData["ErrorMessage"] = "Please input valid data";
                    return View();
                }
                var isAuthenticate = await _obj.checkAuth(usr);
                if (!isAuthenticate) 
                {
                    TempData["ErrorMessage"] = "Invalid Credentials";
                    return View();

                }
                TempData["SuccessMessage"] = "Login Successfull";
                return RedirectToAction("Index","Home");
                    
                

            }
            catch (Exception ex) 
            {
                ModelState.AddModelError(string.Empty,"An error occured while login into the system");
                return View();
            }
        }
    }
}
