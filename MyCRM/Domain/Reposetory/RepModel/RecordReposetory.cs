using Microsoft.EntityFrameworkCore;
using MyCRM.Domain.Entity;
using MyCRM.Domain.Reposetory.interfeises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRM.Domain.Reposetory.RepModel{
    public class RecordReposetory : IAllRecords{

        public AppDbContext context;

        public RecordReposetory(AppDbContext context){
            this.context = context;
        }

        public IQueryable<Record> GetRecords(){
            return context.Records;
        }

        public Record GetRecordsById(int id){
            return context.Records.FirstOrDefault(x => x.id == id);
        }

        public IQueryable<Record> GetRecordsByUserId(int id){
            return context.Records.Where(x => x.UserId == id);
        }

        public Record GetRecordsByName(string Name){
            return context.Records.FirstOrDefault(x => x.Name == Name);
        }

        public void DeleteRecords(int id){
            context.Records.Remove(new Record() { id = id });
        }

        public void SaveRecords(Record newCategory){
            if (newCategory.id == default)
                context.Entry(newCategory).State = EntityState.Added;
            else
                context.Entry(newCategory).State = EntityState.Modified;

            context.SaveChanges();
        }

    }
}
