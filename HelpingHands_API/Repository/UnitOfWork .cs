using HelpingHands_API.Data;
using HelpingHands_API.Models;
using HelpingHands_API.Repository;
using HelpingHands_API.Repository.IRepostiory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IApplicationRoleRepository ApplicationRole { get; private set; }
        public IApplicationUserRoleRepository ApplicationUserRole { get; private set; }
        public IUserRepository User { get; private set; }



        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ApplicationUser = new ApplicationUserRepository(_db);
            ApplicationRole = new ApplicationRoleRepository(_db);
            ApplicationUserRole = new ApplicationUserRoleRepository(_db);
            //User = new UserRepository();

        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

