using MyCRM.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRM.Domain.Reposetory.interfeises{
    public interface IAllCategories{
        IQueryable<Categori> GetCategories();
        Categori GetCategoriesById(int id);
        IQueryable<Categori> GetCategoriesByUserId(int id);
        Categori GetCategoriesByName(string Name);
        void SaveCategories(Categori entity);
        void DeleteCategories(int id);
    }
}
