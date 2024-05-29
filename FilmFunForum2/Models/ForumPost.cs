namespace FilmFunForum2.Models
{
    public class ForumPost
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; } //Ändrat detta från  int

        public string? Image { get; set; }

        public string?UserImage { get; set; } //Lagt tillnr4

        public bool Flagged { get; set; }

        public List<Comment>? Comments { get; set; }  //Lagt till ändrat igen
    }
}
