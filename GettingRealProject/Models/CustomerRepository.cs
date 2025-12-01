using System;
using System.ComponentModel;
using System.IO;
using System.Xml.Linq;

namespace GettingRealProject.Models
{
    public class CustomerRepository 
    {
        private List<Customer> customers;

        public CustomerRepository()
        {
            customers = new List<Customer>();
            InitializeRepository();
        }

        private void InitializeRepository()
        {
            try
            {  
                using (StreamReader sr = new StreamReader("Customers.csv"))
                {
                  
                    string line = sr.ReadLine();

                    while (line != null)
                    {
                        string[] parts = line.Split(',');

                        this.Add(parts[0], parts[1], int.Parse(parts[2]), parts[3], parts[4], double.Parse(parts[5]));

                        line = sr.ReadLine();
                    }
                }
            }
            catch (IOException)
            {
                throw;
            }
        }

        public Customer Add(string name, string email, int phoneNumber, string username, string password, double balance)
        {


            Customer result = null;

            if (!string.IsNullOrEmpty(name) &&
                !string.IsNullOrEmpty(email) &&
                phoneNumber >= 0 &&
                !string.IsNullOrEmpty(username) &&
                !string.IsNullOrEmpty(password) &&
                balance >= 0)

            {
                //result = new Customer();
                //{
                //    Name = name,
                //    Email = email,
                //    PhoneNumber = phoneNumber,
                //    Username = username,
                //    Password = password,
                //    Balance = balance;

                //}
                
                customers.Add(result);
            }
            else
                throw (new ArgumentException("Not all arguments are valid"));

            return result;
        }
        public void UpdateBalance(double amount)
        {
            
        }

    }
}

