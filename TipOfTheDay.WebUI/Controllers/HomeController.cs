using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TipOfTheDay.Domain.Concrete;
using TipOfTheDay.Domain.Entities;

// Written by Brian Bird, 2/16/2012
// MVC web site example

namespace TipOfTheDay.WebUI.Controllers
{
    public class HomeController : Controller
    {
        ITipRepository tipRepo;

        // The default constructor is called by the framework
        public HomeController()
        {
            // Choose the fake or real repository below: 
            tipRepo = new Domain.Concrete.TipRepository();
            //tipRepo = new Domain.Concrete.FakeTipRepository();
        }

        // Use this for dependency injection
        public HomeController(ITipRepository repo)
        {
            tipRepo = repo;
        }

        public int PageSize = 1;    // Number of items per page

        public ViewResult Index()
        {
            if (tipRepo.GetTips().Count() == 0) // Just do this the first time the db is created
                tipRepo.Init();

            Tip todaysTip = tipRepo.GetTip(new DateTime(2012, 3, 1));   // TODO use today's day and month
            return View(todaysTip);
        }

        public ViewResult TipList()
        {
            return View(tipRepo.GetTips() );
        }

    }
}
