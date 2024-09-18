using SciMagazine.Core.Common;

namespace SciMagazine.Core.Entities
{
    public class Researcher : User
    {
        public List<Paper> SubmittedPapers { get; set; } = new();


        public void SubmitPaper(string title, string @abstract)
        {
            var paper = Paper.SubmitPaper(title, @abstract, this);
            SubmittedPapers.Add(paper);
        }
    }
}