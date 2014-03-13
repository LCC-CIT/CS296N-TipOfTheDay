using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TipOfTheDay.Domain.Concrete;
using TipOfTheDay.Domain.Entities;

namespace TipOfTheDay.Controllers
{
    public class AdminController : Controller
    {
        private ITipRepository tipRepo;

        // Used by the MVC framework
        public AdminController()
        {
            tipRepo = new TipRepository();
        }

        // Just for testing
        public AdminController(ITipRepository repo)
        {
            tipRepo = repo;
        } 
        
        // GET: /Admin/
        public ActionResult Index()
        {
            return View(tipRepo.GetTips());
        }

        public ViewResult Edit(int id)
        {
            Tip tip = tipRepo.GetTips().FirstOrDefault(t => t.TipId == id);

            ViewBag.TagList = new MultiSelectList(tip.Tags, "TagId", "Word");
            return View(tip);
        }

        [HttpPost]
        public ActionResult Edit(Tip tip)
        {
           foreach(SelectListItem item in (MultiSelectList)ViewBag.TagList)    // tags were not persisted as part of tip, need to add them back
              if(item.Selected)
                  tip.Tags.Add(new Tag() { Word = item.Text, TagId = Int32.Parse(item.Value) });      // Warning: These tags just have Id's - the rest of the properties will be restored in the repository
            
            tipRepo.UpdateTip(tip);
            return RedirectToAction("Index");
        }

        public ViewResult AddTip()
        {
            return View("Edit", new Tip());
        }

        [HttpPost]
        public ActionResult AddTip(Tip tip, List<Tag> tags)
        {
            // TODO process tags
            tip.Author = (Member)Session["User"];
            tipRepo.SaveTip(tip);
            return RedirectToAction("Index");
        }


        public ActionResult Init()
        {
            tipRepo.Init();
            return RedirectToAction("Index");
        }
    }
}
