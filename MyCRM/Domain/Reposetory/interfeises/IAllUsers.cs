using MyCRM.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRM.Domain.Reposetory.interfeises{
    public interface IAllUsers{
        IQueryable<User> GetUser();
        User GetUserById(int id);
        User GetUserByName(string Name);
        void SaveUser(User entity);
        void DeleteUser(int id);
    }
}
