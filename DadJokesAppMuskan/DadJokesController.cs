using DadJokesAppMuskan.Model;
using DadJokesAppMuskan.Service;

namespace DadJokesAppMuskan
{
    public class DadJokesController
    {
        private readonly DadJokesService _serv;

        /// Controller Constructor
        public DadJokesController() {

            _serv = new DadJokesService();
        }

        #region -- Methods --
        public Task<JokeModel> GetRandomJoke()
        {
            return _serv.GetRandomJokeService();
        }

        public Task<List<List<JokeModel>>> SearchJokesByTerm(String searchText)
        {
            return _serv.SearchJokesByTermService(searchText);
        }

        public static void Main()
        {

        }
        #endregion
    }
}
