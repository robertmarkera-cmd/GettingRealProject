using GettingRealProject.Models;
using System.Windows;


namespace GettingRealProject.Views
{
   
    public partial class Payment : Window
    {
        private readonly CustomerRepository customerRepository;
        public Payment()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            double.TryParse(AmountBox.Text, out double amount);

            customerRepository.UpdateBalance(amount);

            this.Close();

        }
    }
}
