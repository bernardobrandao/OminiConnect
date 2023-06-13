using Microsoft.EntityFrameworkCore;
using OminiConnect.Models;

namespace OminiConnect.Repository
{
    public class AddressRepository
    {
        private readonly DbContext _dbContext;

        public AddressRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateAddress(Address address)
        {
            _dbContext.Add(address);
            _dbContext.SaveChanges();
        }
    }
}
