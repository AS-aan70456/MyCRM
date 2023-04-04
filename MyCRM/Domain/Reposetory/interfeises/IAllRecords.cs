using MyCRM.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRM.Domain.Reposetory.interfeises{
    public interface IAllRecords{
        IQueryable<Record> GetRecords();
        Record GetRecordsById(int id);
        IQueryable<Record> GetRecordsByUserId(int id);
        Record GetRecordsByName(string Name);
        void SaveRecords(Record entity);
        void DeleteRecords(int id);
    }
}
