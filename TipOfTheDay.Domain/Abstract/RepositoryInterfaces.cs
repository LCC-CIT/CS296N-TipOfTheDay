using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TipOfTheDay.Domain.Entities;

namespace TipOfTheDay.Domain.Concrete
{
    // defines a repository through which we will obtain and update root entity objects.
    public interface ITipRepository
    {
        // IQueryable<Tip> Tips { get; }
        IQueryable<Tip> GetTips();          // Gets all the tips
        Tip GetTip(DateTime date);          // Gets the tip for a specific day
    }

    public interface IMemberRepository
    {
        List<Member> GetMembers();
        void UpdateProduct(Member member);
    }

    public interface ITagRepository
    {
        List<Tag> GetTags();
        void UpdateProduct(Tag tag);
    }

    public interface ILanguageRepository
    {
        List<Language> GetLanguages();
        void UpdateProduct(Language language);
    }

}
