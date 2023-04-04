using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRM.Domain.Entity{
    public class Categori{

        public int id { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public int Limit { get; set; }

        public int bill { get; set; }
    }
}
