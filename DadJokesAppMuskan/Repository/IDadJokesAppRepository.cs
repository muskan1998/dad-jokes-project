using DadJokesAppMuskan.Model;

namespace DadJokesAppMuskan.Repository
{
    public interface IDadJokesAppRepository
    {
        public Task<JokeModel> GetRandomJokeRepository();

        public Task<DadJokesResult> SearchJokesByTermRespository(string searchText);
    }
}
