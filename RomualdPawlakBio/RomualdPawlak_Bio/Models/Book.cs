using System;

namespace RomualdPawlak_Bio.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string CoverMini { get; set; }
        public DateTime? PublishDate { get; set; }
        public int PublishYear { get; set; }
        public string PublisherLink { get; set; }
        public BookCategory Category { get; set; }
        public Adaptation[] Adaptations { get; set; }
        public Award[] Awards { get; set; }
    }

    public enum BookCategory
    {
        Adult = 1,
        Kids = 2,
        Anthology = 3
    }

    public class Adaptation
    {
        public AdaptationType AdaptationType { get; set; }
        public string Contribution { get; set; }
        public string Link { get; set; }
    }

    public enum AdaptationType
    {
        Animated = 1
    }

    public class Award
    {
        public AwardType AwardType { get; set; }
        public string AwardName { get; set; }
        public string Category { get; set; }
        public string Link { get; set; }
    }

    public enum AwardType
    {
        Nominated = 1,
        Awarded = 2
    }
}
