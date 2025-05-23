using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace day_23
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Student> students = new List<Student>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void openFileButton_Click(object sender, RoutedEventArgs e)
        {
            var filePath = string.Empty;

            OpenFileDialog dialog = new()
            {
                InitialDirectory = "c:\\",
                Filter = "CSV File (*.csv)|*.csv",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                filePath = dialog.FileName;

                if (File.Exists(filePath))
                {
                    filePathLabel.Content = filePath;
                }
            }
        }

        private void getDataButton_Click(object sender, RoutedEventArgs e)
        {
            if (filePathLabel.Content is string filePath && File.Exists(filePath))
            {
                using(StreamReader sr = new StreamReader(filePath))
                {
                    string headerLine = sr.ReadLine();
                    while(!sr.EndOfStream)
                    {
                        if (sr.ReadLine() is string line)
                        {
                            string[] data = line.Split(',');
                            students.Add(new Student() { Name = data[0], Age = int.Parse(data[1]), Description = data[2] });
                        }
                    }
                }
                csvDataGrid.ItemsSource = students;
            }
            else
            {
                MessageBox.Show("경로가 잘못되었거나 파일이 존재하지 않습니다", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
    }
}