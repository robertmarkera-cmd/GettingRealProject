using GettingRealProject.Models;
using System.Windows;

namespace GettingRealProject.Views
{
   
    public partial class Payment : Window
    {
        public Payment()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            double.TryParse(AmountBox.Text, out double amount);
            

            this.Close();


            //if (DataContext is ViewModel vm)
            //{
            //    if (double.TryParse(AmountBox.Text, out double amount))
            //    {
            //        vm.CurrentCustomer.UpdateBalance(amount);
            //    }
            //}
        }
    }
}
