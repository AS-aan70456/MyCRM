using MyCRM.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRM.ViewModel{
    public class PlanningViewModel{

        public IQueryable<Categori> allCategory { get; set; }
        public int planmoney { get; set; }

    }
}
