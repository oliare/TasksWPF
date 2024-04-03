using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TasksWPF
{
    /* FOR TEST */

    //Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem
    // Ipsum has been the industry's standard dummy text ever since the 1500s, when an 
    // unknown printer took a galley of type and scrambled it to make a type specimen
    // book.It has survived not only five centuries, but also the leap into electronic
    // typesetting, remaining essentially unchanged.It was popularised in the 1960s
    // with the release of Letraset sheets containing Lorem Ipsum passages, and more
    // recently with desktop publishing software like Aldus PageMaker including versions
    // of Lorem Ipsum.
    public partial class MainWindow : Window
    {
        private Stat statistics;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Go_Click(object sender, RoutedEventArgs e)
        {
            statistics = await AnalyzeText(textBox.Text);
            OutcomeWin win = new OutcomeWin(statistics);
            win.DisplayInfo();
            win.Show();
        }
        public class Stat
        {
            public int SntncCount { get; set; }
            public int CharCount { get; set; }
            public int WordCount { get; set; }
            public int QuestionSntncCount { get; set; }
            public int ExclamationSntncCount { get; set; }
        }

        private async Task<Stat> AnalyzeText(string text)
        {
            return await Task.Run(() =>
            {
                Stat statistics = new Stat();

                statistics.CharCount = text.Replace(" ", "").Length;

                var pattern = new Regex(@"\b\w+\b");
                var matches = pattern.Matches(text);
                statistics.WordCount = matches.Count;

                statistics.SntncCount = text.Count(c => c == '.' || c == '?' || c == '!');
                statistics.QuestionSntncCount = text.Count(c => c == '?');
                statistics.ExclamationSntncCount = text.Count(c => c == '!');

                return statistics;
            });
        }

    }
}