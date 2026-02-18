namespace OnlineLearningPlatform.Entities
{
    public class Course : IComparable<Course>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Capacity { get; set; }
        public double Rating { get; set; }
        public int InstructorId { get; set; }

        public int CompareTo(Course? other)
        {
            if (other == null) return 1;
            return string.Compare(Title, other.Title, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString() => $"{Id}: {Title} (Rating: {Rating}, Capacity: {Capacity})";
    }
}
