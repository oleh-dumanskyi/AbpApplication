using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpApp.Domain.Entities
{
    public class Option
    {
        public int Id { get; set; }
        public Key Key { get; set; }
        public string Value { get; set; }
        public int Weight { get; set; }
    }
}
