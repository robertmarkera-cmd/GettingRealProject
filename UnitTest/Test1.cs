using GettingRealProject.Models;
using GettingRealProject.ViewModel;

namespace UnitTest

{
    [TestClass]
    public sealed class Test1
    {
        [TestInitialize]
        public void Init()
        {

        }

        [TestMethod]
        public void AddCustomer()
        {
            // Arrange
            var cr = new CustomerRepository();
            // Act
            var customer = cr.Add("Jan", "j@gmail.com", 10101010, "jan12", "password", 0);

            // Assert
            Assert.AreEqual("Jan", customer.Name);
            Assert.AreEqual("j@gmail.com", customer.Email);
            Assert.AreEqual(10101010, customer.PhoneNumber);
            Assert.AreEqual("jan12", customer.UserName);
            Assert.AreEqual("password", customer.Password);
            Assert.AreEqual(0, customer.Balance);
        }

        [TestMethod]
        public void AddMoreCustomers()
        {
            // Arrange
            var cr = new CustomerRepository();
            // Act
            var customer1 = cr.Add("Jan", "j@gmail.com", 10101010, "jan12", "password", 0);
            var customer2 = cr.Add("Sara", "sara@gmail.com", 20202020, "sara22", "password123", 100);
            var customer3 = cr.Add("Ali", "ali@gmail.com", 30303030, "ali33", "mypassword", 50);


            // Assert customer1
            Assert.AreEqual("Jan", customer1.Name);
            Assert.AreEqual("j@gmail.com", customer1.Email);
            Assert.AreEqual(10101010, customer1.PhoneNumber);
            Assert.AreEqual("jan12", customer1.UserName);
            Assert.AreEqual("password", customer1.Password);
            Assert.AreEqual(0, customer1.Balance);


            // Assert for customer2
            Assert.AreEqual("Sara", customer2.Name);
            Assert.AreEqual("sara@gmail.com", customer2.Email);
            Assert.AreEqual(20202020, customer2.PhoneNumber);
            Assert.AreEqual("sara22", customer2.UserName);
            Assert.AreEqual("password123", customer2.Password);
            Assert.AreEqual(100, customer2.Balance);

            // Assert for customer3
            Assert.AreEqual("Ali", customer3.Name);
            Assert.AreEqual("ali@gmail.com", customer3.Email);
            Assert.AreEqual(30303030, customer3.PhoneNumber);
            Assert.AreEqual("ali33", customer3.UserName);
            Assert.AreEqual("mypassword", customer3.Password);
            Assert.AreEqual(50, customer3.Balance);

        }

        [TestMethod]
        public void GetCustomerBalance()
        {
            // Arrange
            var cr = new CustomerRepository();
            var vm = new MainViewModel();

            var customer1 = cr.Add("Jan", "j@gmail.com", 10101010, "jan12", "password", 0);

            vm.CurrentCustomer = customer1;

            // Assert
            Assert.AreEqual(0, customer1.Balance);
        }

        [TestMethod]
        public void UpdateCustomerBalance()
        {
            // Arrange
            var cr = new CustomerRepository();
            var vm = new MainViewModel();

            var customer1 = cr.Add("Jan", "j@gmail.com", 10101010, "jan12", "password", 0);

            vm.CurrentCustomer = customer1;

            // Act
            vm.UpdateBalance(200);

            // Assert
            Assert.AreEqual(200, customer1.Balance);

        }


    }
}
