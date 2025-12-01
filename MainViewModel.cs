using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using GettingRealProject.Models;

namespace GettingRealProject.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Customer? _currentCustomer;

        public CustomerRepository CustomerRepo { get; }

        public Customer? CurrentCustomer
        {
            get => _currentCustomer;
            set
            {
                if (_currentCustomer == value) return;
                _currentCustomer = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Balance));
            }
        }

        public double Balance => CurrentCustomer?.Balance ?? 0;

        public MainViewModel()
        {
            CustomerRepo = new CustomerRepository();

            // Use first repository customer if available; otherwise create a default signed-in customer.
            var first = CustomerRepo.GetAll().FirstOrDefault();
            if (first is not null)
            {
                CurrentCustomer = first;
            }
            else
            {
                // Default customer (signed-in scenario)
                CurrentCustomer = CustomerRepo.Add(
                    name: "Default User",
                    email: "default@example.com",
                    phoneNumber: 0,
                    username: "defaultuser",
                    password: "password",
                    balance: 50.0
                );
            }
        }

        // Update current customer's balance and persist via repository
        public void UpdateBalance(double amount)
        {
            if (CurrentCustomer == null) return;

            CurrentCustomer.Balance += amount;
            CustomerRepo.Update(CurrentCustomer);
            OnPropertyChanged(nameof(Balance));
            OnPropertyChanged(nameof(CurrentCustomer));
        }

        // Simple, non-nullable event and public invoker
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
}