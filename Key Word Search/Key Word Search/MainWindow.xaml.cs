using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Key_Word_Search
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string[] read;
        Dictionary<string, int> words = new Dictionary<string, int>();
        string temp = "";
        string temp1 = "";
        // Initialization of a Hashset that contains keywords to be searching for in a job posting.
        HashSet<string> keywords = new HashSet<string>()
        {
            "software",
            "c#",
            "c++",
            "python",
            "java",
            "javascript",
            "aws",
            "react",
            "bootstrap",
            "wpf",
            "programming",
            "azure",
            "cloud",
            "application",
            "development",
            "scrum",
            "waterfall",
            "remote",
            "agile",
            "asp.net",
            "build",
            "backend",
            "frontend",
            "developer",
            "design",
            "development",
            "environment",
            "knowledge",
            "mobile",
            ".net",
            "product",
            "projects",
            "solution",
            "source",
            "sql",
            "testing",
            "tools",
            "web",
            "html",
            "css", 
            "critical",
            "creativity",
            "communication",
            "algorithm",
            "ruby",
            "perl",
            "node.js",
            "reasoning",
            "project",
            "json",
            "growth mindset",
            "values"


        };
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            temp = "";
            foreach (KeyValuePair<string, int> pair in words)
            {
                if (keywords.Contains(SanitizeString(pair.Key)))
                {
                    temp1 = pair.ToString();
                    temp += temp1 + "\n";
                }

            }
            Output.Text = temp;
            words.Clear();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            words.Clear();
            Output.Text = "";
            string read1 = Input.Text.ToLower();
            read = read1.Split(" ");

            for (int i = 0; i < read.Length; i++)
            {
                // Incrementation of the value for the key if it already exists.
                if (words.TryGetValue(read[i], out int value))
                {
                    words[read[i]] += 1;
                }
                // Else statement to add the key if it does not exist already in the dictionary.
                else
                {
                    read[i] = SanitizeString(read[i]);
                    words.Add(read[i], 1);
                }
            }

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
        // Method to take special characters out of a word for the search. Leaves in '$' and '+'.
        private string SanitizeString(string word)
        {

            if (word.EndsWith(',') || word.EndsWith(')') || word.EndsWith('(') || word.EndsWith(':') || word.EndsWith('!') || word.EndsWith('-') ||
                word.EndsWith('@') || word.EndsWith('%') || word.EndsWith('*'))
            {
                word = word.Substring(0, word.Length-1);
            }

            return word;
        }
    }
}
