using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;
using WebDemo.Controllers;

namespace WebDemo.Services
{
    public class VendorRepository : IVendorRepository
    {

        public IEnumerable<Vendor> GetAll()
        {
            return DataStore.vendors;
        }

        public Vendor Get(int id)
        {
            var vendor = DataStore.vendors.Find(x => x.Id == id);
            if (vendor == null)
            {
                throw new Exception("Vendor not found");
            }
            return vendor;
        }

        public Vendor Add(Vendor vendor)
        {
            DataStore.vendors.Add(vendor);
            return vendor;
        }


        public void Update(Vendor req)
        {
            var vendor = DataStore.vendors.Find(x => x.Id == req.Id);
            if (vendor == null)
            {
                throw new Exception("Todo not found");
            }

            vendor.Id = req.Id;
            vendor.FirstName = req.FirstName;
            vendor.LastName = req.LastName;
            vendor.HourlyRate = req.HourlyRate;
            vendor.Status = req.Status;
            // vendor.AccountNumber = req.AccountNumber;
        }

        public void Delete(int id)
        {
            var vendor = DataStore.vendors.Find(x => x.Id == id);
            if (vendor == null)
            {
                throw new Exception("Todo not found");
            }

            //if (vendor.Status != Status.Deleted)
            //{
            //    throw new InvalidOperationException("Cant delete....");
            //}

            DataStore.vendors.Remove(vendor);
        }
    }
}
