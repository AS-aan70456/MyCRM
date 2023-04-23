using Microsoft.EntityFrameworkCore;
using MyCRM.Domain.Entity;
using MyCRM.Domain.Reposetory.interfeises;
using System;
using System.Collections.Generic;
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

        public void SaveUser(User User){
            if (User.id == default)
                context.Entry(User).State = EntityState.Added;
            else
                context.Entry(User).State = EntityState.Modified;
            
            context.SaveChanges();
        }
    }
}
