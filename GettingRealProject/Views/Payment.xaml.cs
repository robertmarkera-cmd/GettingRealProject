using GettingRealProject.ViewModel;
using System.Windows;

namespace GettingRealProject.Views
{
    public partial class Payment : Window
    {
        private readonly MainViewModel _viewModel;

        public Payment(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double.TryParse(AmountBox.Text, out double amount);
           
            _viewModel.UpdateBalance(amount);

            DialogResult = true;
            Close();
        }
    }
}
