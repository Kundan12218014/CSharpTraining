namespace OnlineLearningPlatform.Entities
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CourseId { get; set; }
        public DateTime Deadline { get; set; }

        public void Submit(DateTime submissionDate)
        {
            if (submissionDate > Deadline)
            {
                throw new Exception($"Submission for assignment '{Title}' rejected. Deadline was {Deadline}.");
            }
            Console.WriteLine($"Assignment '{Title}' submitted successfully on {submissionDate}.");
        }
    }
}
