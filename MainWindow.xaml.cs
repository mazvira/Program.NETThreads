using System.Windows;
using FontAwesome.WPF;

namespace Lab5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ImageAwesome _loader;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(ShowLoader);
        }

        public void ShowLoader(bool isShow)
        {
            LoaderHelper.OnRequestLoader(MainGrid, ref _loader, isShow);
        }
    }
}
