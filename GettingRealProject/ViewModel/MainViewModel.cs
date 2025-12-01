using GettingRealProject.Models;

namespace GettingRealProject.ViewModel
{
    public class MainViewModel
    {
        private Customer _currentCustomer;
        public CustomerRepository CustomerRepo;
        public MainViewModel()
        {
            CustomerRepo = new CustomerRepository();
        }
        public void AddCustomer()
        {

        }
        public void UpdateBalance()
        {

        }
    }
}
