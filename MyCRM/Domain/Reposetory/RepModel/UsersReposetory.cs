using MyCRM.Domain.Entity;
using MyCRM.Domain.Reposetory.interfeises;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRM.Domain.Reposetory.RepModel{
    public class UsersReposetory : IAllUsers{
        public AppDbContext context;

        public UsersReposetory(AppDbContext context){
            this.context = context;
        }

        public IQueryable<User>GetUser(){
            return context.Users;
        }

        public User GetUserById(int id){
            return context.Users.FirstOrDefault(x => x.id == id);
        }
        public User GetUserByName(string Name){
            return context.Users.FirstOrDefault(x => x.Name == Name);
        }
        

        public void DeleteUser(int id){
            context.Users.Remove(new User() { id = id });
        }

        public void SaveUser(User newCategory){
            if (newCategory.id == default){
                context.Entry(newCategory).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Added;
            }
            else{
                context.Entry(newCategory).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}
