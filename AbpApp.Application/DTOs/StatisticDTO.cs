using AbpApp.Domain.Entities;

namespace AbpApp.Application.DTOs
{
    public class StatisticDTO
    {
        public int Devices { get; set; }
        public Dictionary<string, int> ValueDistribution { get; set; }
        public List<Experiment> Experiments { get; set; }
    }
}
