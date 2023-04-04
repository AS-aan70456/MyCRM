using Microsoft.EntityFrameworkCore;
using MyCRM.Domain.Entity;
using MyCRM.Domain.Reposetory.interfeises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRM.Domain.Reposetory.RepModel{
    public class CategoriesReposetory : IAllCategories{
        public AppDbContext context;

        public CategoriesReposetory(AppDbContext context){
            this.context = context;
        }

        public IQueryable<Categori> GetCategories(){
            return context.Categories;
        }

        public Categori GetCategoriesById(int id){
            return context.Categories.FirstOrDefault(x => x.id == id);
        }

        public IQueryable<Categori> GetCategoriesByUserId(int id){
            return context.Categories.Where(x => x.UserId == id);
        }

        public Categori GetCategoriesByName(string Name) {
            return context.Categories.FirstOrDefault(x => x.Name == Name);
        }

        public void DeleteCategories(int id){
            context.Categories.Remove(new Categori() { id = id });
        }

        public void SaveCategories(Categori newCategory){
            if (newCategory.id == default)
                context.Entry(newCategory).State = EntityState.Added;
            else
                context.Entry(newCategory).State = EntityState.Modified;
            
            context.SaveChanges();
        }
    }
}
