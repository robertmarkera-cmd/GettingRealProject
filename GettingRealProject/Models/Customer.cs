using System.ComponentModel;
using System.Security.RightsManagement;
using System.Xml.Linq;

namespace GettingRealProject.Models
{
    public class Customer 
    {
        public string name { get; set; }
        public string email { get; set; }
        public int phoneNumber { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public double balance { get; set; }


        public Customer(string Name, string Email, int PhoneNumber, string Username, string Password, double Balance)
        {
            name = Name;
            email = Email;
            phoneNumber = PhoneNumber;
            username = Username;
            password = Password;
            balance = Balance;
        }

        public Customer(string Name, string Email, int PhoneNumber, string Username, string Password) : this(Name, Email, PhoneNumber, Username, Password, 0)
        {

        }

        public Customer() : this("", "", 0, "", "", 0)
        {

        }
    }
}

