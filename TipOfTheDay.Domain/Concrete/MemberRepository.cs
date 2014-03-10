using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipOfTheDay.Domain.Concrete
{
    public class MemberRepository : IMemberRepository
    {

        public IQueryable<Entities.Member> GetMembers()
        {
            var db = new TipDbContext();
            return db.Members;
        }

        public bool UpdateMember(Entities.Member member)
        {
            bool success = false;

            var db = new TipDbContext();
            var dbMember = db.Members.FirstOrDefault(m => m.MemberId == member.MemberId);
            if (null != dbMember)
            {
                dbMember.Email = member.Email;
                dbMember.Name = member.Name;
                dbMember.Rating = member.Rating;
                db.SaveChanges();
                success = true;
            }

            return success;
        }

        public bool SaveMember(Entities.Member member)
        {
            bool success = false;

            var db = new TipDbContext();
            if (null == db.Members.FirstOrDefault(m => m.Email == member.Email))
            {
                db.Members.Add(member);
                db.SaveChanges();
                success = true;
            }

            return success;
        }
    }
}
