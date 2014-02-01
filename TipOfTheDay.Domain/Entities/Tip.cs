﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TipOfTheDay.Domain.Entities
{
    public class Tip
    {
        public int TipId { get; set; }
        public string Title { get; set; }
        public int SkillLevel { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public string Example { get; set; }
        public string Citation { get; set; }
        public string Link { get; set; }
        public int? Rating { get; set; }        // Nullable so that reatings can be omitted
        public Member Author { get; set; }

        // The rest of these properties are lists
        // They are read only since we don't want
        // to add lists, just add to lists
        public List<Tag> Tags 
        {
            get
            {
                return tags;
            }
        }

        public List<Language> Languages    
        {
            get
            {
                return languages;
            }
        }


        public List<Comment> Comments     
        {
            get
            {
                return comments;
            }
        }

        // Backing variables for the lists
        private List<Comment> comments;
        private List<Tag> tags;
        private List<Language> languages;

        // Comments are special. They live and die with a Tip so we create them here.
        public void addComment(string text, Member author) // add a single comment to the list of comments
        {
            Comment com = new Comment(text);
            com.Date = DateTime.Today.ToString();
            com.Author = author;
            comments.Add(com);
        }


        // Constructor
        public Tip()
        {
            // We need to create the list objects. They're just empty lists.
            comments = new List<Comment>();
            languages = new List<Language>();
            tags = new List<Tag>();
        }
    }
}