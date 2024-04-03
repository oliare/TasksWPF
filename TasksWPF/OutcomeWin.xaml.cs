using System.IO;
using System.Windows;
using static TasksWPF.MainWindow;

namespace TasksWPF
{
    public partial class OutcomeWin : Window
    {
        private Stat stat;
        public OutcomeWin(Stat stat)
        {
            InitializeComponent();
            this.stat = stat;
            DisplayInfo(); 
        }

        public void DisplayInfo()
        {
            textBox.Text = $"\n\n Sentences: {stat.SntncCount}\n\n Chars: {stat.CharCount}\n\n Words: {stat.WordCount}\n\n" +
                $" Question Sentences: {stat.QuestionSntncCount}\n\n Exclamation Sentences: {stat.ExclamationSntncCount}";
        }

        private void saveReport_Click(object sender, RoutedEventArgs e)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktop, "Report.txt");

            try
            {
                File.WriteAllText(filePath, textBox.Text);
                MessageBox.Show("Report saved successfully to Desktop!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the report:\n{ex.Message}");
            }
        }
    }

}
