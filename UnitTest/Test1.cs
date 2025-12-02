using Microsoft.VisualStudio.TestTools.UnitTesting;
using GettingRealProject;
using GettingRealProject.Models;

namespace UnitTest

{
    [TestClass]
    public sealed class Test1
    {

        

        //Customer c1, c2, c3;


        [TestInitialize]
        public void Init()
        {
            

        }


        [TestMethod]
        public void AddCustomerTrue()
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
        public void GettingCustomerDetail()
        {

        }

        [TestMethod]
        public void GettingCustomerBalance()
        {

        }
        [TestMethod]
        public void UpdatingCustomerBalance()
        {

        }
        [TestMethod]
        public void ReadToStreamrider()
        {

        }

        [TestMethod]
        public void WriteToStreamrider()
        {

        }

    }
}
