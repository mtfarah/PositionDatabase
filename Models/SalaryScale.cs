using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PositionDatabase.Models
{
    public class SalaryScale
    {
        [Key]
        public int SalaryScaleId { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public ICollection<PositionSalaryScale> PositionSalaryScales { get; set; }
    }
}
