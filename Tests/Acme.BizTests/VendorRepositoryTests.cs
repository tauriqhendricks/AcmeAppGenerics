using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorRepositoryTests
    {
        [TestMethod()]
        public void RetrieveAllTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>()
            {
                { new Vendor()
                 { VendorId = 22, CompanyName = "Amalgamated Toys", Email = "a@abc.com"}},
                { new Vendor()
                 { VendorId = 35, CompanyName = "Car Toys", Email = "car@abc.com"}},
                { new Vendor()
                 { VendorId = 28, CompanyName = "Toy Blocks Inc", Email = "blocks@abc.com"}},
                { new Vendor()
                 { VendorId = 42, CompanyName = "Toys for Fun", Email = "fun@abc.com"}}
            };

            //Act
            var vendors = repository.RetrieveAll();

            /*var vendorQuery = from v in vendors
                                where v.CompanyName.Contains("Toy")
                                orderby v.CompanyName
                                select v;*/

            var vendorQuery = vendors.Where(v => v.CompanyName.Contains("Toy"))
                                     .OrderBy(v => v.CompanyName);
                 
            //Assert
            CollectionAssert.AreEqual(expected, vendorQuery.ToList());
        }

        [TestMethod()]
        public void RetrieveValueTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = 42;

            //Act
            var actual = repository.RetrieveValue<int>("Select ...", 42);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveValueStringTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = "test";

            //Act
            var actual = repository.RetrieveValue<string>("Select ...", "test");

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveValueObjectTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var vendor = new Vendor();
            var expected = vendor;

            //Act
            var actual = repository.RetrieveValue<Vendor>("Select ...", vendor);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveTest()
        {
            // Arange
            var repo = new VendorRepository();
            var expected = new List<Vendor>
                {
                    new Vendor()
                    {
                        VendorId = 1,
                        CompanyName = "ABC Corp",
                        Email = "abc@gmail.com"
                    },

                    new Vendor()
                    {
                        VendorId = 12,
                        CompanyName = "XYZ Inc",
                        Email = "xyz@gmail.com"
                    }
                };

            // Act
            var actual = repo.Retrieve();

            var vendroQuery = from v in expected
                              where v.CompanyName.Contains("xy")
                              orderby v.CompanyName
                              select v;
            //Console.WriteLine($"Query: {vendroQuery}");
            foreach (var item in vendroQuery)
            {
                Console.WriteLine($"Query: {item}");
            }

            // Assert
            CollectionAssert.AreEqual(expected, actual.ToList());
        }

        [TestMethod()]
        public void RetrieveTestWithIterator()
        {
            // Arange
            var repo = new VendorRepository();
            var expected = new List<Vendor>
                {
                    new Vendor()
                    {
                        VendorId = 1,
                        CompanyName = "ABC Corp",
                        Email = "abc@gmail.com"
                    },

                    new Vendor()
                    {
                        VendorId = 12,
                        CompanyName = "XYZ Inc",
                        Email = "xyz@gmail.com"
                    }
                };

            // Act
            var vendorIterator = repo.RetrieveWithIterator();
            foreach (var vendor in vendorIterator)
            {
                Console.WriteLine(vendor);
            }

            var actual = vendorIterator.ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /*[TestMethod()]
        public void RetrieveWithKeysTest()
        {
            // Arrange
            var repo = new VendorRepository();
            var expected = new Dictionary<string, Vendor>
            {
                {
                    "ABC Corp", new Vendor
                    {
                        VendorId = 5,
                        CompanyName = "ABC Corp",
                         Email = "abc@gmail.com"
                    }
                },
                {
                    "XYX Inc", new Vendor()
                    {
                        VendorId = 12,
                        CompanyName = "XYZ Inc",
                        Email = "xyz@gmail.com"
                    }
                }
            };

            // Act
            var actual = repo.RetrieveWithKeys();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }*/
    }
}