using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TipOfTheDay.Domain.Entities
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }

        public Language()
        {
        }

        public Language(string n)
        {
            Name = n;
        }
    }

    public class Tag
    {
        public int TagId { get; set; }
        public string Word { get; set; }

        public Tag()
        {
        }

        public Tag(string w)
        {
            Word = w;
        }
    }
}