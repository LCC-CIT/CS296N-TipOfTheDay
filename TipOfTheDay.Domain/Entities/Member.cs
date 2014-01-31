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
        public int? Rating { get; set; }        // NUllable so that ratings aren't required
        public List<Tip> Tips { get; set; }

        public Member(string m)
        {
            Name = m;
            Tips = new List<Tip>();
        }
    }
}