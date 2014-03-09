using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TipOfTheDay.Domain.Entities;

namespace TipOfTheDay.Domain.Concrete
{

    // These are just stubs that return empty collections or objects for now
    public class TipRepository : ITipRepository
    {

        public void Init()
        {
            // Just do this once!
            // Add a tip to the database for testing
            Tip tip = new Tip()
            {
                Author = new Member("Brian"),       // add a Member object
                Title = "C# Object Initialization",
                SkillLevel = 3,
                Date = DateTime.Today,
                Rating = 5,
                Text = "Object initializers let you assign values to any accessible fields or properties of an object at creation time without having to explicitly invoke a constructor. The following example shows how to use an object initializer with a named type, Cat.",
                Example = "Cat cat = new Cat { Age = 10, Name = \"Fluffy\" };",
                Citation = "MSDN Library, C# Programming Guide, Object and Collection Initializers",
                Link = "http://msdn.microsoft.com/en-us/library/bb384062.aspx"
            };

            tip.addComment("Wow, these make initialization so easy!", new Member("John") );
            tip.addComment("Why doesn't Java have this feature?", new Member("Harold") );
            tip.Languages.Add(new Language(tip, "C#"));
            tip.Tags.Add(new Tag(tip, "Object"));
            tip.Tags.Add(new Tag(tip, "Initialization"));

            SaveTip(tip);
        }
        

        public IQueryable<Tip> GetTips()
        {
            var db = new TipDbContext();
            return db.Tips.Include("Author");   // Force "eager loading"
        }

        
        public Tip GetTip(DateTime date)
        {
            var db = new TipDbContext();
            Tip tip = (from t in db.Tips
                    select t).Include(t => t.Comments.Select(c => c.Author)).FirstOrDefault();
            return tip;
        }


        public bool SaveTip(Tip tip)
        {
            var db = new TipDbContext();
            if (tip != null && tip.TipId == 0)
            {
                db.Tips.Add(tip);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool UpdateTip(Tip tip)
        {
            bool success = false;
            var db = new TipDbContext();
            if (tip != null && tip.TipId > 0)
            {
                Tip tipFromDb = db.Tips.Find(tip.TipId);
                if (tipFromDb != null)
                {
                    // Shallow copy of simple properties
                    tipFromDb.Citation = tip.Citation;
                    tipFromDb.Date = tip.Date;
                    tipFromDb.Example = tip.Example;
                    tipFromDb.Link = tip.Link;
                    tipFromDb.Text = tip.Text;
                    tipFromDb.Title = tip.Title;

                    // Copy collection properties
                    CopyTagsToDbTip(tip.Tags, tipFromDb.Tags);
                    // Save the changes to the database
                    db.SaveChanges();

                    success = true;
                }
            }
            return success;
        }

        // Make a copy of the tag objects. The copies need to come from the db
        private void CopyTagsToDbTip(IEnumerable<Tag> sourceTags, List<Tag> dbTags )
        {
           var db = new TipDbContext();
            foreach(Tag tag in sourceTags)
            {
                if(null == dbTags.Find(t => t.TagId == tag.TagId))  // Add any tags that aren't already on the tip
                    dbTags.Add(db.Tags.Find(tag.TagId));
            }
        }
    }
}