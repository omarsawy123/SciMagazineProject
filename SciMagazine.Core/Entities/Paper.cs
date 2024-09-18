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
        public List<Review> Reviews { get; set; } = new();

        private Paper(string title, string @abstract, Researcher researcher)
        {
            Title = title;
            Abstract = @abstract;
            Author = researcher;
            PaperStatus = PaperStatus.Submitted;
        }

        public void AddReview(Review review)
        {
            Reviews.Add(review);
            UpdatePaperStatus();
            NotifyUser();
        }

        public static Paper SubmitPaper(string title, string @abstract, Researcher researcher)
        {
            return new Paper(title, @abstract, researcher);
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

        }


    }
}