﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TipOfTheDay.Domain.Abstract;
using TipOfTheDay.Domain.Concrete;
using TipOfTheDay.Domain.Entities;

namespace TipOfTheDay.Controllers
{
    public class SearchController : Controller
    {

       private ITipRepository tipRepo;
       private IMemberRepository memberRepo;

        // Used by the MVC framework
        public SearchController()
        {
            tipRepo = new TipRepository();
            memberRepo = new MemberRepository();
        }

        // Just for testing
        public SearchController(ITipRepository tRepo, IMemberRepository mRepo)
        {
            tipRepo = tRepo;
            memberRepo = mRepo;
        } 
        
        // GET: /Admin/
        public ActionResult FindTipByAuthor()
        {
            return View(memberRepo.GetMembers());
        }

        [HttpPost]
        public ActionResult FindTipByAuthor(int memberId)
        {
            int num = memberId;
            IEnumerable<Tip> tips = from t in tipRepo.GetTips()
                       where t.Author.MemberId == memberId
                       select t;
            return View("TipList", tips);
        }

    }
}