using AbpApp.Application.DTOs;
using AbpApp.Domain.Entities;

namespace AbpApp.Application.Interfaces
{
    public interface IExperimentService
    {
        public Task<ExperimentResponseDTO> GetExperiment(string deviceToken, Key key, CancellationToken cancellationToken);
        public Task<StatisticDTO> GetStatistics(Key key, CancellationToken cancellationToken);
    }
}
