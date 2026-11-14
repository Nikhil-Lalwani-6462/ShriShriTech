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
                
            return View();

        }
    }
}
