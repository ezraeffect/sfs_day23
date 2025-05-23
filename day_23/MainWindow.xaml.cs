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

/*
 * 실습. 이미지 버튼
 * - 이미지 파일을 불러오면 버튼이 불러온 이미지로 바뀌는 프로그램 제작
 * - OpenFileDialog를 구현
 * - 파일 경로는 URI를 사용하여 가져오기
 * - 버튼의 크기도 이미지 크기와 같게 변경되도록 하기
 */
namespace day_23
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var filePath = string.Empty;

            OpenFileDialog dialog = new()
            {
                InitialDirectory = "c:\\",
                Filter = "JPEG File (*.jpg)|*.jpg|PNG File (*.png)|*.png|All files (*.*)|*.*",
                FilterIndex = 2,
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
                    var fileUri = new Uri(filePath, UriKind.Absolute);
                    var bitmapImg = new BitmapImage(fileUri);

                    imageBox.Source = bitmapImg;

                    imageBox.Height = bitmapImg.Height;
                    imageBox.Width = bitmapImg.Width;

                    button.Height = bitmapImg.Height;
                    button.Width = bitmapImg.Width;

                    
                }
            }
        }
    }
}