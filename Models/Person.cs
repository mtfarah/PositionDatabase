using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PositionDatabase.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeId { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public ICollection<Position> Positions { get; set; }

        

    }
    
}
