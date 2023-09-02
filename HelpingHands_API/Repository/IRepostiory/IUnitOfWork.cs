
using HelpingHands_API.Models;
using HelpingHands_API.Repository.IRepostiory;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository.IRepostiory{    public interface IUnitOfWork    {
		IApplicationUserRepository ApplicationUser { get; }
		IApplicationRoleRepository ApplicationRole { get; }
		IApplicationUserRoleRepository ApplicationUserRole { get; }
		IUserRepository User { get; }

        void Save();    }}
