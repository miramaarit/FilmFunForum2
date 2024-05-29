using System.Text.Json;

namespace FilmFunForum2.DAL
{
    public class CategoryManagerAPI
    {
        private static Uri BaseAddress = new Uri("https://localhost:44302/");

        public static async Task<List<Models.Category>> GetAllCategories()
        {
            List<Models.Category> categories = new List<Models.Category>();
            

            using(var client = new HttpClient())
            {
                client.BaseAddress = BaseAddress;
                HttpResponseMessage response = await client.GetAsync("api/Category");
                if(response.IsSuccessStatusCode)
                {
                    string responsestring = await response.Content.ReadAsStringAsync();
                    categories = JsonSerializer.Deserialize<List<Models.Category>>(responsestring);
                }
                return categories;
            }
        }
    }
}
