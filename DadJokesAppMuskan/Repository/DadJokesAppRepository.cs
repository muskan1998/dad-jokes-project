using System.Net.Http.Headers;
using DadJokesAppMuskan.Model;
using System.Web;

namespace DadJokesAppMuskan.Repository
{
    public class DadJokesAppRepository : IDadJokesAppRepository
    {
        public static HttpClient ApiClient;

        public DadJokesAppRepository()
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("https://icanhazdadjoke.com/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ApiClient.DefaultRequestHeaders.Add("User-Agent", @"Muskan");
        }

        #region -- Methods --
        public async Task<JokeModel> GetRandomJokeRepository()
        {
            using (HttpResponseMessage response = await ApiClient.GetAsync(ApiClient.BaseAddress))
            {
                if (response.IsSuccessStatusCode)
                {
                    JokeModel joke = await response.Content.ReadAsAsync<JokeModel>();

                    return joke;
                }
                else
                {
                    throw new Exception(response.Content.ToString());
                }
            }
        }

        public async Task<DadJokesResult> SearchJokesByTermRespository(string searchText)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["limit"] = "30";

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                query["term"] = searchText;

            }
            string queryString = ApiClient.BaseAddress +"search?"+ query.ToString();

            using (HttpResponseMessage response = await ApiClient.GetAsync(queryString))
            {
                if (response.IsSuccessStatusCode)
                {
                    DadJokesResult jokes = await response.Content.ReadAsAsync<DadJokesResult>();

                    return jokes;
                }
                else
                {
                    throw new Exception(response.Content.ToString());
                }
            }
        }

        #endregion
    }
}
