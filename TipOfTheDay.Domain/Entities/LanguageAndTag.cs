using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TipOfTheDay.Domain.Entities
{
    public class Language
    {
        private List<Tip> tips;

        public int LanguageId { get; set; }
        public string Name { get; set; }

        // This collection in conjunction with the Languages 
        // collection on Tips create a many-to-many relationship
        public List<Tip> Tips               
        {
            get { return tips; }
        }

        public Language()
        {
            tips = new List<Tip>();
        }

        public Language(Tip tip, string n)
        {
            Name = n;
            tips = new List<Tip>();
            tips.Add(tip);
        }
    }



    public class Tag
    {
        private List<Tip> tips;

        public int TagId { get; set; }
        public string Word { get; set; }

        // This collection in conjunction with the Tags 
        // collection on Tips create a many-to-many relationship        
        public List<Tip> Tips 
        {
            get { return tips; }
        }

        public Tag()
        {
            tips = new List<Tip>();
        }

        public Tag(Tip tip, string w)
        {
            Word = w;
            tips = new List<Tip>();
            tips.Add(tip);
        }
    }
}