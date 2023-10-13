using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpApp.Domain.Entities
{
    public class Experiment
    {
        public Guid Id { get; set; }
        public string DeviceToken { get; set; }
        public Option Option { get; set; }
    }
}
