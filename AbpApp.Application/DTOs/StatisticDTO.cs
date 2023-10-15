using AbpApp.Domain.Entities;

namespace AbpApp.Application.DTOs
{
    public class StatisticDTO
    {
        public int Devices { get; set; }
        // Dictionary key is for option value name, dictionary value is for grouped options amount
        public Dictionary<string, int> ValueDistribution { get; set; }
        public List<Experiment> Experiments { get; set; }
    }
}
