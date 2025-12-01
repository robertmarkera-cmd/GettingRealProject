using System;

namespace GettingRealProject.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }

        public Customer(string name, string email, int phoneNumber, string userName, string password, double balance)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            UserName = userName;
            Password = password;
            Balance = balance;
        }

        public Customer(string name, string email, int phoneNumber, string userName, string password)
            : this(name, email, phoneNumber, userName, password, 0)
        { }

        public Customer() : this("", "", 0, "", "", 0) { }
    }
}

