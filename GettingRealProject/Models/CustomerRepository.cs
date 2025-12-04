using System.IO;

namespace GettingRealProject.Models
{
    public class CustomerRepository
    {
        private readonly List<Customer> customers;

        public CustomerRepository()
        {
            customers = new List<Customer>();
            InitializeRepository();
        }

        private void InitializeRepository()
        {
            if(!File.Exists("Customers.csv"))
                return;

                using var sr = new StreamReader("Customers.csv");
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    if (parts.Length >= 6 &&
                        int.TryParse(parts[2], out int phone) &&
                        double.TryParse(parts[5], out double balance))
                    {
                        Add(parts[0], parts[1], phone, parts[3], parts[4], balance);
                    }
                }
            
        }

        public void SaveRepository()
        {
           
                using var sw = new StreamWriter("Customers.csv");
                foreach (var customer in customers)
                {
                    sw.WriteLine($"{customer.Name},{customer.Email},{customer.PhoneNumber},{customer.UserName},{customer.Password},{customer.Balance}");
                }
            
        }

        public Customer Add(string name, string email, int phoneNumber, string username, string password, double balance)
        {
            if (string.IsNullOrWhiteSpace(name)
                || string.IsNullOrWhiteSpace(email)
                || phoneNumber < 0
                || string.IsNullOrWhiteSpace(username)
                || string.IsNullOrWhiteSpace(password)
                || balance < 0)
            {
                throw new ArgumentException("Not all arguments are valid");
            }

            var customer = new Customer(name, email, phoneNumber, username, password, balance);
            customers.Add(customer);
            return customer;
        }

        public Customer Get(string userName)
        {
            foreach (var c in customers)
            {
                if (c.UserName == userName)
                    return c;
            }
            return null;
        }

        public List<Customer> GetAll()
        {
            return customers;
        }


        public void Update(Customer customer)
        {
            if (customer == null) return;

            var existing = Get(customer.UserName);
            if (existing == null)
            {
                customers.Add(customer);
                return;
            }

            existing.Name = customer.Name;
            existing.Email = customer.Email;
            existing.PhoneNumber = customer.PhoneNumber;
            existing.Password = customer.Password;
            existing.Balance = customer.Balance;
        }
    }
}

