using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using TipOfTheDay.Domain.Entities;

namespace TipOfTheDay.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for testing the Tip model and all the models
    ///it uses. (In DDD terminology, all the objects in an aggregate with Tip.)
    ///</summary>
    [TestClass()]
    public class TipTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for addComment
        ///</summary>

        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page
        // (for example,http://.../Default.aspx). This is necessary for the unit test
        // to be executed on the web server, whether you are testing a page, 
        // web service, or a WCF service.
        /* But, we don't need to get a web page when we're just testing the model */
        /*[HostType("ASP.NET")]
        [TestMethod()]
        [AspNetDevelopmentServerHost("C:\\Users\\Brian\\Dropbox\\LCC\\CS296A\\Examples\\TipOfTheDay\\TipOfTheDay", "/")]
        [UrlToTest("http://localhost:3943/")]
         */
        [TestMethod()]
        public void createTipTest()
        {
            Tip target = new Tip();
            const string TITLE = "Test title.";
            const string TEXT = "Test text.";
            const string EXAMPLE = "Test example.";
            const string CITATION = "Test citation.";
            const string LINK = "Test link.";
            const int SKILL_LEVEL  = 2;
            const int RATING = 4;
            Member author = new Member("Test Author");
            DateTime today = DateTime.Today;

            target.Title = TITLE;
            target.Text = TEXT;
            target.Example = EXAMPLE;
            target.Citation = CITATION;
            target.Link = LINK;
            target.SkillLevel = SKILL_LEVEL;
            target.Rating = RATING;
            target.Author = author;
            target.Date = today;

            Assert.AreEqual(TITLE, target.Title);
            Assert.AreEqual(TEXT, target.Text);
            Assert.AreEqual(EXAMPLE, target.Example);
            Assert.AreEqual(CITATION, target.Citation);
            Assert.AreEqual(LINK, target.Link);
            Assert.AreEqual(SKILL_LEVEL, target.SkillLevel);
            Assert.AreEqual(RATING, target.Rating);
            Assert.AreEqual(today, target.Date);
            Assert.AreEqual(author, target.Author);
        }

        [TestMethod()]
        public void addCommentTest()
        {
            Tip target = new Tip(); 
            const string TEXT1 = "This is a test1.";
            const string TEXT2 = "This is a test2.";
            const string TEXT3 = "This is a test3.";
            string today = DateTime.Today.ToString();
            Member author1 = new Member("Test Author1");
            Member author2 = new Member("Test Author2");
            Member author3 = new Member("Test Author3");
            target.addComment(TEXT1, author1);
            target.addComment(TEXT2, author2);
            target.addComment(TEXT3, author3);
            Assert.AreEqual(TEXT1, target.Comments[0].Text);
            Assert.AreEqual(author1, target.Comments[0].Author);
            Assert.AreEqual(today, target.Comments[0].Date);
            Assert.AreEqual(author2, target.Comments[1].Author);
            Assert.AreEqual(TEXT3, target.Comments[2].Text);
        }

       [TestMethod()]
        public void addTagTest()
        {
            Tip target = new Tip();
            const string TAG1 = "tagTest1";
            const string TAG2 = "tagTest2";
            const string TAG3 = "tagTest3";
            target.Tags.Add(new Tag(target, TAG1));
            target.Tags.Add(new Tag(target, TAG2));
            target.Tags.Add(new Tag(target, TAG3));
            Assert.AreEqual(TAG1, target.Tags[0].Word);
            Assert.AreEqual(TAG2, target.Tags[1].Word);
            Assert.AreEqual(TAG3, target.Tags[2].Word);
        }

       [TestMethod()]
       public void addLanguageTest()
       {
           Tip target = new Tip();
           const string LANG1 = "langTest1";
           const string LANG2 = "langTest2";
           const string LANG3 = "langTest3";
           target.Languages.Add(new Language(target, LANG1));
           target.Languages.Add(new Language(target, LANG2));
           target.Languages.Add(new Language(target, LANG3));
           Assert.AreEqual(LANG1, target.Languages[0].Name);
           Assert.AreEqual(LANG2, target.Languages[1].Name);
           Assert.AreEqual(LANG3, target.Languages[2].Name);
       }

       [TestMethod()]
       public void createMemberTest()
       {
           const string NAME = "test member name";
           const string EMAIL = "test email";
           const int RATING = 3;

           Member target = new Member(NAME);

           target.Email = EMAIL;
           target.Rating = RATING;

           Assert.AreEqual(NAME, target.Name);
           Assert.AreEqual(EMAIL, target.Email);
           Assert.AreEqual(RATING, target.Rating);
       }

        /*
       [TestMethod()]
       public void addTipToMemberTest()
       {
           const string NAME = "test member name";
           Member target = new Member(NAME);
           Tip tip1 = new Tip();
           Tip tip2 = new Tip();
           Tip tip3 = new Tip();

           const string TITLE1 = "Test title 1";
           const string TITLE2 = "Test title 2";
           const string TITLE3 = "Test title 3";

           tip1.Title = TITLE1;
           tip2.Title = TITLE2;
           tip3.Title = TITLE3;

           target.Tips.Add(tip1);
           target.Tips.Add(tip2);
           target.Tips.Add(tip3);

           Assert.AreEqual(TITLE1, target.Tips[0].Title);
           Assert.AreEqual(TITLE2, target.Tips[1].Title);
           Assert.AreEqual(TITLE3, target.Tips[2].Title);
       }
        */

    }
}
