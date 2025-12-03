using System.Windows;
using GettingRealProject.ViewModels;

namespace GettingRealProject.Views
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel vm;

        public MainWindow()
        {
            InitializeComponent();
            vm = new MainViewModel();
            DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var dialog = new Payment(vm);
            dialog.ShowDialog();
        }
    }
}