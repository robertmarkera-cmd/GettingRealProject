using GettingRealProject.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GettingRealProject.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Customer currentCustomer;
            
        public CustomerRepository CustomerRepo { get; }

        public Customer? CurrentCustomer
        {
            get => currentCustomer;
            set
            {
                if (currentCustomer == value) return;
                currentCustomer = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Balance));
                OnPropertyChanged(nameof(BalanceText));
            }
        }

        public double Balance => CurrentCustomer.Balance;
        public string BalanceText => $"Saldo {Balance} kr";

        public MainViewModel()
        {
            CustomerRepo = new CustomerRepository();

            var first = CustomerRepo.GetAll().FirstOrDefault();
            if (first is not null)
            {
                CurrentCustomer = first;
            }
            else
            {
                CurrentCustomer = CustomerRepo.Add(
                    name: "Jørgen",
                    email: "Jørgen@gmail.com",
                    phoneNumber: 50502030,
                    username: "JørgenPeter2",
                    password: "password",
                    balance: 0d
                );
            }
        }

        public void UpdateBalance(double amount)
        {
            if (CurrentCustomer == null) return;

            CurrentCustomer.Balance += amount;
            CustomerRepo.Update(CurrentCustomer);
            OnPropertyChanged(nameof(Balance));
            OnPropertyChanged(nameof(BalanceText));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
}
