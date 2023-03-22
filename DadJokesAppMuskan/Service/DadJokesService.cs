using DadJokesAppMuskan.Model;
using DadJokesAppMuskan.Repository;
using System.Text.RegularExpressions;

namespace DadJokesAppMuskan.Service
{
    public class DadJokesService : IDadJokesService
    {
        private readonly IDadJokesAppRepository _repo;

        /// Controller Constructor
        public DadJokesService() { _repo = new DadJokesAppRepository(); }

        #region -- Methods --
        public Task<JokeModel> GetRandomJokeService()
        {
            return _repo.GetRandomJokeRepository();
        }

        public async Task<List<List<JokeModel>>> SearchJokesByTermService(string searchText)
        {
            DadJokesResult res1 = await _repo.SearchJokesByTermRespository(searchText);
            foreach (JokeModel joke in res1.Results)
            {
                int numberOfWords = Regex.Matches(joke.joke, searchText).Count;

                if (numberOfWords > 0)
                {
                    joke.joke = Regex.Replace(joke.joke, searchText, match => match.Value.ToUpper());
                    joke.MatchCount = numberOfWords;
                }
            }
            List<List<JokeModel>> countwise_list = new List<List<JokeModel>>();

            countwise_list.Add(res1.Results.FindAll(itm => itm.MatchCount <= 10));
            countwise_list.Add(res1.Results.FindAll(itm => itm.MatchCount > 10 && itm.MatchCount <= 20));
            countwise_list.Add(res1.Results.FindAll(itm => itm.MatchCount > 20 && itm.MatchCount <= 30));

            return countwise_list;


        }

        #endregion
    }
}
