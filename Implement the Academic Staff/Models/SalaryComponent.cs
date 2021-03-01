using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PositionDatabase.Models
{
    public class SalaryComponent
    {
        public enum SalaryType { Basic = 1, Gross=2 }
        public int Id { get; set; }
        public SalaryType Type { get; set; }
        public decimal Value { get; set; }

        public Guid PersonId { get; set; }

        public Person Person { get; set; }
    }
}
