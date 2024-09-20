using SciMagazine.Core.Common.Classes;

namespace SciMagazine.Core.Entities
{
    public class Researcher : User
    {
        public List<Paper> SubmittedPapers { get; set; } = new();


        public void SubmitPaper(string title, string @abstract, Academic academic)
        {
            var paper = Paper.SubmitPaper(title, @abstract, this, academic);
            SubmittedPapers.Add(paper);
        }
    }
}