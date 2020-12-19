using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PositionDatabase.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }
        public string ContractType { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        public int PersonId { get; set; }

        public Person Person { get; set; }
       
    }

    
}
