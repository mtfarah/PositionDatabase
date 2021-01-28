using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PositionDatabase.Models
{
    public enum CType { FullTime, PartTime }
    public class Position
    {
        [Key]
        public int PositionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }        

        public CType? ContractType { get; set; }

        //[DataType(DataType.Date)]
        //public DateTime StartDate { get; set; }

        public int PersonId { get; set; }

        public Person Person { get; set; }

        public ICollection<PositionSalaryScale> PositionSalaryScales { get; set; }


    }


}
