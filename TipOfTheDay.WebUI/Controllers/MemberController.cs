using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TipOfTheDay.Domain.Concrete;
using TipOfTheDay.Domain.Entities;

namespace TipOfTheDay.Controllers
{
    public class MemberController : Controller
    {
        IMemberRepository memberRepo;

        // The default constructor is called by the framework
        public MemberController()
        {
            // Choose the fake or real repository below: 
            memberRepo = new MemberRepository();
        }

        // Use this for dependency injection
        public MemberController(IMemberRepository repo)
        {
            memberRepo = repo;
        }        //
        // GET: /User/
        const string USER = "User";


        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Member user)
        {
            if (user.Name == null) // This is a log-in
            {
                user = memberRepo.GetMembers().FirstOrDefault(m => m.Email == user.Email);
                if (null == user)
                    RedirectToAction("Index");  //User not found, try again
            }
            else     // This is a registration
            {
                memberRepo.SaveMember(user);
            }

            Session[USER] = user;

            return RedirectToAction("Index", "Home");
        }

    }
}
