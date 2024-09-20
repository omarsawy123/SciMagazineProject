using SciMagazine.Core.Enums;

namespace SciMagazine.Core.Entities
{
    public class Paper
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Abstract { get; private set; }
        public PaperStatus PaperStatus { get; private set; }
        public Researcher Author { get; private set; }
        public Academic Reviewer { get; private set; }
        public List<Review> Reviews { get; set; } = new();

        private Paper(string title, string @abstract, Researcher researcher, Academic reviewer)
        {
            Title = title;
            Abstract = @abstract;
            Author = researcher;
            Reviewer = reviewer;
            PaperStatus = PaperStatus.Submitted;
        }

        public void AddReview(Review review)
        {
            Reviews.Add(review);
            UpdatePaperStatus();
            NotifyUser();
        }

        public static Paper SubmitPaper(string title, string @abstract, Researcher researcher, Academic academic)
        {
            var paper = new Paper(title, @abstract, researcher, academic);
            academic.AssignPaper(paper);
            return paper;
        }


        private void UpdatePaperStatus()
        {
            var lastReview = Reviews[^1];

            PaperStatus = lastReview.Decision switch
            {
                ReviewDecision.Accepted => PaperStatus.Accepted,
                ReviewDecision.Rejected => PaperStatus.Rejected,
                ReviewDecision.RevisionRequired => PaperStatus.UnderRevision,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private void NotifyUser()
        {
            // logic for notify
        }


    }
}