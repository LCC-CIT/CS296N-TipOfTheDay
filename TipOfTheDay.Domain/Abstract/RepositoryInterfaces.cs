using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TipOfTheDay.Domain.Entities;

namespace TipOfTheDay.Domain.Abstract
{
    // defines a repository through which we will obtain and update root entity objects.
    public interface ITipRepository
    {
        void Init();                        // Put test data in the database
        IQueryable<Tip> GetTips();          // Gets all the tips
        Tip GetTip(DateTime date);          // Gets the tip for a specific day
        bool SaveTip(Tip tip);
        bool UpdateTip(Tip tip);
    }

    public interface IMemberRepository
    {
        IQueryable<Member> GetMembers();
        bool UpdateMember(Member member);
        bool SaveMember(Member member);
    }

    public interface ITagRepository
    {
        List<Tag> GetTags();
        void UpdateTag(Tag tag);
    }

    public interface ILanguageRepository
    {
        List<Language> GetLanguages();
        void UpdateLanguage(Language language);
    }

}
