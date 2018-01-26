using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TipOfTheDay.Domain.Entities;

namespace TipOfTheDay.Domain.Concrete
{
    public class TipDbContext : DbContext
    {
        public TipDbContext()
            : base("name=TipDb")
        { }

        public DbSet<Tip> Tips { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
