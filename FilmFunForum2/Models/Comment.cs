namespace FilmFunForum2.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int ForumPostId { get; set; } //Ändrat

        public string? Image { get; set; }

        public string? ForumPostTitle { get; set; } //Ändrat, ändrat igen

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; } //Ändrat denna

        public string? UserImage { get; set; }

        public bool Flagged { get; set; }
    }
}
