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
        public TipRepository()
        {
            /* 
            // Just do this once!
            // Add a tip to the database for testing
             Tip tip = new Tip() { Author = new Member("Brian"),       // add a Member object
                            Title = "C# Object Initialization",
                            SkillLevel = 3,
                            Date = DateTime.Today,
                            Rating = 5,
                            Text = "Object initializers let you assign values to any accessible fields or properties of an object at creation time without having to explicitly invoke a constructor. The following example shows how to use an object initializer with a named type, Cat.",
                            Example = "Cat cat = new Cat { Age = 10, Name = \"Fluffy\" };",
                            Citation = "MSDN Library, C# Programming Guide, Object and Collection Initializers",
                            Link = "http://msdn.microsoft.com/en-us/library/bb384062.aspx",
                            Languages = {new Language("C#")},
                            Tags = {new Tag("Objects"), new Tag("Initialization")}
                          };


             db.Tips.Add(tip);
             db.SaveChanges();
             */
        }
        
        // Stub
        public IQueryable<Tip> GetTips()
        {
            var db = new TipDbContext();
            return db.Tips.Include("Author");   // Force "eager loading"
        }

        // Stub
        public Tip GetTip(DateTime date)
        {
            var db = new TipDbContext();
            Tip tip = (from t in db.Tips
                    select t).FirstOrDefault();
            return tip;
        }
    }
}