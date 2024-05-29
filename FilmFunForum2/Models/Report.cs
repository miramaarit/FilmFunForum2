namespace FilmFunForum2.Models
{
    public class Report
    {
        public int Id { get; set; }

        public int? ForumPostId { get; set; } //Ändrat 27/5

        public int? CommentId { get; set; }

        public string Reason { get; set; }

        public string UserId { get; set; } //Ändrat denna

        public DateTime Date { get; set; }
    }
}
