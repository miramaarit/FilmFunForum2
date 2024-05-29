using System.Text.Json.Serialization;

namespace FilmFunForum2.Models
{
    public class Category
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Name { get; set; }
    }
}
