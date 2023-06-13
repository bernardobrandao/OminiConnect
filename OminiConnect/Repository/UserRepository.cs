using Microsoft.EntityFrameworkCore;
using OminiConnect.Models;

namespace OminiConnect.Repository
{
    public class UserRepository
    {
        private readonly DbContext _dbContext;

        public UserRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateUser(User user)
        {
            _dbContext.Add(user);
            _dbContext.SaveChanges();
        }
    }
}
