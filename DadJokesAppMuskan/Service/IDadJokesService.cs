using DadJokesAppMuskan.Model;

namespace DadJokesAppMuskan.Service
{
    public interface IDadJokesService
    {
        public Task<JokeModel> GetRandomJokeService();
        public Task<List<List<JokeModel>>> SearchJokesByTermService(string searchText);


    }
}
