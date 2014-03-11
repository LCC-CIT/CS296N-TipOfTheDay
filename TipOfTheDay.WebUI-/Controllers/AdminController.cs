using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TipOfTheDay.Domain.Abstract;
using TipOfTheDay.Domain.Concrete;
using TipOfTheDay.Domain.Entities;

namespace TipOfTheDay.Controllers
{
    public class AdminController : Controller
    {
        ITipRepository tipRepo;

        public AdminController()
        {
            tipRepo = new TipRepository();
        }

        // Overloaded constructor for unit testing this controller
        public AdminController(ITipRepository repo)
        {
            tipRepo = repo;
        }

        public ViewResult AddTip()
        {

            return View(Tip);
        }

    }
}