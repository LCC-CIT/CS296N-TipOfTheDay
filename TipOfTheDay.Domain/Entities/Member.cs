using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TipOfTheDay.Domain.Entities
{
    public class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? Rating { get; set; }        // Nullable so that ratings aren't required
//        public virtual List<Tip> Tips { get; set; }     // virtual to enable lazy loading

        public Member()                         // If you add an overloaded constructor,
        {                                       // you also have to add a parameterless constructor
//            Tips = new List<Tip>();              // since a default constructor is no longer supplied automatically
        }                                      

        public Member(string n)
        {
            Name = n;
 //           Tips = new List<Tip>();
        }
    }
}