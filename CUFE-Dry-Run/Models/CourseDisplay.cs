namespace MRK.Models
{
    public readonly struct CourseDisplay
    {
        public Course Course { get; init; }
        public string Code => Course.Code;
        public string Name => Course.Name;
        public int Lectures => Course.LectureCount;
        public int Tutorials => Course.TutorialCount;
        public string Flags { get; init; }
    }
}
