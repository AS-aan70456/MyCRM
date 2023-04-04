using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRM.Domain.Entity{
    public class Record {

        public int id { get; set; }

        public int UserId { get; set; }

        public string NameCategory { get; set; }

        public string Name { get; set; }

        public int Pirse { get; set; }

        public bool Income { get; set; }

        public string DataCreate { get; set; }
    }
}
