using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorTests
    {
        [TestMethod()]
        public void SendWelcomeEmail_ValidCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "ABC Corp";
            var expected = "Message sent: Hello ABC Corp";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_EmptyCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "";
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_NullCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = null;
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PlaceOrderTest()
        {
            // Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult<bool>(true,
                "Order from Acme, Inc\r\nProduct: Saw\r\nQuantity: 12" +
                                     "\r\nInstructions: standard delivery");

            // Act
            var actual = vendor.PlaceOrder(product, 12);

            // Assert
            Assert.AreEqual(expected.Result, actual.Result);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void PlaceOrder_3Parameters()
        {
            // Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult<bool>(true,
                "Order from Acme, Inc\r\nProduct: Saw\r\nQuantity: 12" +
                "\r\nDeliver By: 2020/10/25" +
                "\r\nInstructions: standard delivery");

            // Act
            var actual = vendor.PlaceOrder(product, 12,
                new DateTimeOffset(2020, 10, 25, 0, 0, 0, new TimeSpan(-7, 0, 0)));

            // Assert
            Assert.AreEqual(expected.Result, actual.Result);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlaceOrder_NullProduct_Exception()
        {
            // Arrange
            var vendor = new Vendor();

            // Act
            var actual = vendor.PlaceOrder(null, 12);

            // Assert
            // Expected exception
        }

        [TestMethod()]
        public void PlaceOrder_NoDeliveryDate()
        {
            // Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult<bool>(true,
                        "Order from Acme, Inc\r\nProduct: Saw\r\nQuantity: 12" +
                        "\r\nInstructions: Deliver to Suite 42");

            // Act
            var actual = vendor.PlaceOrder(product, 12,
                                instructions: "Deliver to Suite 42");

            // Assert
            Assert.AreEqual(expected.Result, actual.Result);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.VendorId = 1;
            vendor.CompanyName = "ABC Corp";
            var expected = "Vendor: ABC Corp (1)";

            // Act
            var actual = vendor.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendEmailTest()
        {
            // Arange
            var repo = new VendorRepository();
            var vendorsCollection = repo.Retrieve();
            var expected = new List<string>
                {
                    "Message sent: Important message for: ABC Corp",
                    "Message sent: Important message for: XYZ Inc"
                };

            var vendors = vendorsCollection.ToList();

            // Act
            var actual = Vendor.SendEmail(vendors, "Test Message");

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /*[TestMethod()]
        public void SendEmailTestAdd()
        {
            // Arange
            var repo = new VendorRepository();
            var vendorsCollection = repo.Retrieve();
            vendorsCollection.Add(new Vendor()
            {
                VendorId = 7,
                CompanyName = "EFG Ltd",
                Email = "efg@efg.com"
            });

            var vendorsMaster = repo.Retrieve();

            var expected = new List<string>
                {
                    "Message sent: Important message for: ABC Corp",
                    "Message sent: Important message for: XYZ Inc"
                };

            var vendors = vendorsCollection.ToList();

            // Act
            var actual = Vendor.SendEmail(vendors, "Test Message");

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }*/

        [TestMethod()]
        public void SendEmailTest_Array()
        {
            // Arange
            var repo = new VendorRepository();
            var vendorsCollection = repo.Retrieve();
            var expected = new List<string>
                {
                    "Message sent: Important message for: ABC Corp",
                    "Message sent: Important message for: XYZ Inc"
                };

            var vendors = vendorsCollection.ToArray();
            Console.WriteLine(vendors.Length);

            // Act
            var actual = Vendor.SendEmail(vendors, "Test Message");

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendEmailTest_Dictionary()
        {
            // Arange
            var repo = new VendorRepository();
            var vendorsCollection = repo.Retrieve();
            var expected = new List<string>
                {
                    "Message sent: Important message for: ABC Corp",
                    "Message sent: Important message for: XYZ Inc"
                };

            // what to use as a key,  company name
            var vendors = vendorsCollection.ToDictionary(v => v.CompanyName);

            // Act
            var actual = Vendor.SendEmail(vendors.Values, "Test Message");

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}