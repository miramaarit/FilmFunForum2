namespace FilmFunForum2.Models
{
    public class PrivateMessage
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string UserId { get; set; } //Ändrat denna

        public int RecipientId { get; set; }

        public DateTime Date { get; set; }
    }
}
