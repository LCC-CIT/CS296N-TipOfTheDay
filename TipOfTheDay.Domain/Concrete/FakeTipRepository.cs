using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TipOfTheDay.Domain.Entities;

namespace TipOfTheDay.Domain.Concrete
{
    public class FakeTipRepository : ITipRepository
    {

        Tip currentTip = null;
        public Tip CurrentTip { get { return currentTip; } }

        // Note: Only the fourth tip has all the fields populated, but that's OK since none of the fields are manditory.
        private List<Tip> tips = new List<Tip> {
        new Tip() { Title = "Tip 1", Text = "This is the first tip", Date = DateTime.Parse("3/1/2012")},
        new Tip() { Title = "Tip 2", Text = "This is the second tip", Date = DateTime.Parse("3/2/2012")},
        new Tip() { Title = "Tip 3", Text = "This is the third  tip", Date = DateTime.Parse("3/3/2012")},
        new Tip() { Author = new Member("Brian"),       // add a Member object
                            Title = "C# Object Initialization",
                            SkillLevel = 3,
                            Date = DateTime.Today,
                            Rating = 5,
                            Text = "Object initializers let you assign values to any accessible fields or properties of an object at creation time without having to explicitly invoke a constructor. The following example shows how to use an object initializer with a named type, Cat.",
                            Example = "Cat cat = new Cat { Age = 10, Name = \"Fluffy\" };",
                            Citation = "MSDN Library, C# Programming Guide, Object and Collection Initializers",
                            Link = "http://msdn.microsoft.com/en-us/library/bb384062.aspx",
                            Languages = {new Language(null, "C#")},
                            Tags = {new Tag(null, "Objects"), new Tag(null, "Initialization")}      // TODO: test with references to Tip objects
                          }
        };


        public IQueryable<Tip> GetTips()
        {
            return tips.AsQueryable<Tip>();
        }

        public Tip GetTip(DateTime date)
        {
            currentTip = tips.Find(x => x.Date == date);
            return currentTip;
        }

        public void SaveTip(Tip tip)
        {
            throw new NotImplementedException();
        }


        bool ITipRepository.SaveTip(Tip tip)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTip(Tip tip)
        {
            throw new NotImplementedException();
        }

        public void Init()
        {
            throw new NotImplementedException();
        }
    }
}