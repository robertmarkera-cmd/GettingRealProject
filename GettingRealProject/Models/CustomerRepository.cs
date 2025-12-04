using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace GettingRealProject.Models
{
    public class CustomerRepository
    {
        private readonly List<Customer> customers;
        private readonly string filePath = ("Customers.csv");

        public CustomerRepository()
        {
            customers = new List<Customer>();
            InitializeRepository();
        }

        private void InitializeRepository()
        {
            if (!File.Exists(filePath))
                return;

            try
            {
                using var sr = new StreamReader(filePath);
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    if (parts.Length >= 6 &&
                        int.TryParse(parts[2], out int phone) &&
                        double.TryParse(parts[5], NumberStyles.Any, CultureInfo.InvariantCulture, out double balance))
                    {
                        Add(parts[0], parts[1], phone, parts[3], parts[4], balance, persist: false);
                    }
                }
            }
            catch (IOException)
            {
            }
        }

        public void SaveRepository()
        {
            try
            {
                using var sw = new StreamWriter(filePath, false);
                foreach (var customer in customers)
                {
                    sw.WriteLine($"{customer.Name},{customer.Email},{customer.PhoneNumber},{customer.UserName},{customer.Password},{customer.Balance.ToString(CultureInfo.InvariantCulture)}");
                }
            }
            catch (IOException)
            {
            }
        }

        public Customer Add(string name, string email, int phoneNumber, string username, string password, double balance, bool persist = true)
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

            if (persist)
                SaveRepository();

            return customer;
        }

        public Customer? Get(string userName)
        {
            foreach (var c in customers)
            {
                if (string.Equals(c.UserName, userName, StringComparison.OrdinalIgnoreCase))
                    return c;
            }
            return null;
        }

        public List<Customer> GetAll()
        {
            return new List<Customer>(customers);
        }

        public void Update(Customer customer)
        {
            if (customer == null) return;

            var existing = Get(customer.UserName);
            if (existing == null)
            {
                customers.Add(customer);
            }
            else
            {
                existing.Name = customer.Name;
                existing.Email = customer.Email;
                existing.PhoneNumber = customer.PhoneNumber;
                existing.Password = customer.Password;
                existing.Balance = customer.Balance;
            }

            SaveRepository();
        }
    }
}

