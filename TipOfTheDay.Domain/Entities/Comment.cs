using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TipOfTheDay.Domain.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
        public Member Author { get; set; }
        public Tip TheTip { get; set; }

        public Comment()
        {
            Date = System.DateTime.Today.ToString();
        }

        public Comment(string t)
        {
            Text = t;
            Date = System.DateTime.Today.ToString();
        }

    }
}