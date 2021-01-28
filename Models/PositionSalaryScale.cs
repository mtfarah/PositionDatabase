using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PositionDatabase.Models
{
    public class PositionSalaryScale
    {
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public int SalaryScaleId { get; set; }
        public SalaryScale SalaryScale { get; set; }
    }
}
