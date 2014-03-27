using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;

using Voltran.Web.Helpers;
using Voltran.Web.Data.Entities;
using Voltran.Web.Models;

namespace Voltran.Web.Services
{
    public class UserService : BaseService, IUserService
    { 
        public Task<PagedList<User>> GetUsers(int pageNumber)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            var query = Context.Users.Where(x => !x.IsDeleted);

            var count = query.Count();
            var items = query.OrderByDescending(x => x.Id).Skip(ConstHelper.PageSize * (pageNumber - 1)).Take(ConstHelper.PageSize).ToList();

            return Task.FromResult(new PagedList<User>(pageNumber, ConstHelper.PageSize, count, items));
        }

        public Task<bool> Authenticate(string email, string password)
        {
            if (!email.IsEmail() || string.IsNullOrEmpty(password)) return Task.FromResult(false);

            var user = Context.Users.FirstOrDefault(x => x.Email == email && x.IsActive && !x.IsDeleted);
            if (user == null) return Task.FromResult(false);

            var result = false;

            if (BCrypt.Net.BCrypt.Verify(password, user.PasswordHash)
                && user.LoginTryCount < 5)
            {
                user.LastLoginAt = DateTime.Now;
                user.LoginTryCount = 0;
                result = true;
            }
            else
            {
                user.LoginTryCount += 1;
            }

            Context.SaveChanges();

            return Task.FromResult(result);
        }

        public Task<User> GetByEmail(string email)
        {
            if (!email.IsEmail()) return null;

            var user = Context.Users.FirstOrDefault(x => x.Email == email && !x.IsDeleted);
            return Task.FromResult(user);
        }
    }

    public interface IUserService
    { 
        Task<PagedList<User>> GetUsers(int pageNumber); 
        Task<bool> Authenticate(string email, string password);
        Task<User> GetByEmail(string email); 
    } 
}