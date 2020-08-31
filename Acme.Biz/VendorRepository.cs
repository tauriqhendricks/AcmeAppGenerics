using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    public class VendorRepository
    {
        private List<Vendor> vendors;

        /// <summary>
        /// Retrieve one vendor.
        /// </summary>
        /// <param name="vendorId">Id of the vendor to retrieve.</param>
        public Vendor Retrieve(int vendorId)
        {
            // Create the instance of the Vendor class
            Vendor vendor = new Vendor();

            // Code that retrieves the defined customer

            // Temporary hard coded values to return 
            if (vendorId == 1)
            {
                vendor.VendorId = 1;
                vendor.CompanyName = "ABC Corp";
                vendor.Email = "abc@abc.com";
            }
            return vendor;
        }

        public IEnumerable<Vendor> Retrieve()
        {
            if (vendors == null)
            {
                vendors = new List<Vendor>
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
            }

            foreach (var vendor in vendors)
            {
                Console.WriteLine(vendor);
                var states = new Dictionary<string, string>();
                states.Add("CA", "California");
                
            }
            return vendors;
        }

        /// <summary>
        /// Retrieves all the aproved vendors, one at a time
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Vendor> RetrieveWithIterator()
        {
            // Get the data from the database
            var vendors = Retrieve();

            foreach (var vendor in vendors)
            {
                Console.WriteLine($"vendor id: {vendor.VendorId}");
                yield return vendor;
            }
        }

        /// <summary>
        /// Retrieves all of the approved vendors
        /// </summary>
        /// <returns></returns>
        /*public Dictionary<string, Vendor> RetrieveWithKeys()
        {
            var vendors = new Dictionary<string, Vendor>
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


            foreach (var element in vendors)
            {
                var key = element.Key;
                var vendor = element.Value;
                Console.WriteLine($"key: {key} value: {vendor}");
            }

            /*foreach (var vendor in vendors.Values)
            {
                Console.WriteLine(vendor);
            }*/

            /*foreach (var companyName in vendors.Keys)
            {
                Console.WriteLine(vendors[companyName]);
            }*/

            /*if (vendors.ContainsKey("ABCc"))
            {
                Console.WriteLine(vendors["ABCc"]);
            }

            if (vendors.TryGetValue("XYZ", out Vendor vendor))
            {
                Console.WriteLine(vendor);
            }

            return vendors;
        }*/

        public T RetrieveValue<T>(string sql, T defaultValue)
        {
            // Call the database to retrieve the value
            // If no value is returned, return the default value
            T value = defaultValue;

            return value;
        }









        /// <summary>
        /// Save data for one vendor.
        /// </summary>
        /// <param name="vendor">Instance of the vendor to save.</param>
        /// <returns></returns>
        public bool Save(Vendor vendor)
        {
            var success = true;

            // Code that saves the vendor

            return success;
        }
    }
}
