
namespace DadJokesAppMuskan.Model
{
    public class DadJokesResult
    {
        public int Limit { get; set; }
        public List<JokeModel> Results { get; set; }
        public string ?SearchTerm { get; set; }
        public int TotalJokes { get; set; }

    }
}
