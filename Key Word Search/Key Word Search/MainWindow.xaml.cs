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
            "project"
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
                if (words.TryGetValue(read[i], out int value))
                {
                    words[read[i]] += 1;
                }
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
