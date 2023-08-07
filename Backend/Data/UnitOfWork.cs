using HSPA.Data.Repo;
using HSPA.Interfaces;

namespace HSPA.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;
        public UnitOfWork(DataContext dc) {
        
            this.dc = dc;
        }

        public ICityRepository CityRepository => new CityRepository(dc);
        public IUserRepository UserRepository => new UserRepository(dc);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}
