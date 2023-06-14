using TodoApp.Models;

namespace WebDemo.Services
{
    public interface IVendorRepository
    {
        Vendor Add(Vendor vendor);
        void Delete(int id);
        Vendor Get(int id);
        IEnumerable<Vendor> GetAll();
        void Update(Vendor req);
    }
}