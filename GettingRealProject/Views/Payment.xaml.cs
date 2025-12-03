using GettingRealProject.ViewModels;
using System.Windows;

namespace GettingRealProject.Views
{
    public partial class Payment : Window
    {
        private readonly MainViewModel vm;

        public Payment(MainViewModel viewModel)
        {
            InitializeComponent();
            vm = viewModel;
            DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double.TryParse(AmountBox.Text, out double amount);
           
            vm.UpdateBalance(amount);

            DialogResult = true;
            Close();
        }
    }
}
