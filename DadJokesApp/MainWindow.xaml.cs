using DadJokesAppMuskan;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DadJokesApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DadJokesController _dadJokesController = new DadJokesController();

        public MainWindow()
        {
            InitializeComponent();
        }

        public async Task LoadRandomJoke()
        {
            var joke = await _dadJokesController.GetRandomJoke();

            displayRandomJoke.Visibility = Visibility.Visible;
            displaySearchedJokes.Visibility = Visibility.Hidden;        

            displayRandomJoke.Content = joke.joke;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadRandomJoke();            
        }

        private async Task SearchJokes()
        {
            var searchTerm = searchTextBox.Text;

            var jokes = await _dadJokesController.SearchJokesByTerm(searchTerm);            

            displayRandomJoke.Visibility = Visibility.Hidden;
            displaySearchedJokes.Visibility = Visibility.Visible;

            StringBuilder contents = new StringBuilder();

            contents.AppendLine("<10 words matches: #" + jokes[0].Count);
            foreach(var joke in jokes[0])
            {
                contents.AppendLine(joke.joke);
            }
            contents.AppendLine("\n");



            contents.AppendLine("<20 words matches: #" + jokes[1].Count);
            foreach (var joke in jokes[1])
            {
                contents.AppendLine(joke.joke);
            }
            contents.AppendLine("\n");


            contents.AppendLine("<30 words matches: #" + jokes[2].Count);
            foreach (var joke in jokes[2])
            {
                contents.AppendLine(joke.joke);
            }
            displaySearchedJokes.Content = contents ;   
                                          
        }

        private async void searchJokesButton_Click(object sender, RoutedEventArgs e)
        {            
            await SearchJokes();
        }        
    }
}
