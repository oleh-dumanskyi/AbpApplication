using AbpApp.Application.DTOs;
using AbpApp.Application.Interfaces;
using AbpApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AbpApp.Application.Services
{
    public class ExperimentService : IExperimentService
    {
        private readonly IAppDbContext _context;
        private readonly Random _random = Random.Shared;

        public ExperimentService(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ExperimentResponseDTO> GetExperiment(string deviceToken, Key key,
            CancellationToken cancellationToken)
        {
            var experiment = await _context.Experiments
                    .Include(o=>o.Option)
                    .FirstOrDefaultAsync(t => t.DeviceToken == deviceToken 
                                              && t.Option.Key == key, cancellationToken);
            if (experiment != null)
            {
                return new ExperimentResponseDTO
                {
                    Key = experiment.Option.Key.ToString(),
                    Value = experiment.Option.Value
                };
            }

            var newExperiment = await CreateExperiment(deviceToken, key, cancellationToken);
            return new ExperimentResponseDTO
            {
                Key = newExperiment.Option.Key.ToString(),
                Value = newExperiment.Option.Value
            };
        }

        private async Task<Option> GetOptionGroup(Key key, CancellationToken cancellationToken)
        {
            var options = await _context.Options.Where(k => k.Key == key).ToListAsync(cancellationToken);
            if (options == null)
                throw new ArgumentNullException(nameof(options), "Options not found");
            var optionWeights = options.Select(k => k.Weight).ToList();

            decimal weightSum = 0;
            decimal cumulativeWeight = 0;
            decimal allowedErrorMargin = 0.1M;

            foreach (var option in optionWeights)
            {
                weightSum += option;
            }

            var weightDifference = Math.Abs(100 - weightSum);
            if (weightDifference > allowedErrorMargin)
                throw new ArgumentException("Incorrect weights", paramName: nameof(weightDifference));

            var randomValue = _random.Next(0, 100);

            for (int i = 0; i < options.Count; i++)
            {
                cumulativeWeight += optionWeights[i];
                if (randomValue < cumulativeWeight)
                    return options[i];
            }

            return null;
        }

        private async Task<Experiment> CreateExperiment(string deviceToken, Key key,
            CancellationToken cancellationToken)
        {
            var experiment = new Experiment
            {
                DeviceToken = deviceToken,
                Id = Guid.NewGuid(),
                Option = await GetOptionGroup(key, cancellationToken)
            };
            if (experiment == null || experiment.Option == null)
                throw new ArgumentNullException(nameof(experiment), "Experiment creation error");

            await _context.Experiments.AddAsync(experiment, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return experiment;
        }

        public async Task<StatisticDTO> GetStatistics(Key key, CancellationToken cancellationToken)
        {
            var experiments = await _context.Experiments.Include(o => o.Option).ToListAsync(cancellationToken);
            if (experiments == null)
                throw new ArgumentNullException(nameof(experiments), "Experiments not found");
            var groupedOptions = experiments.Select(o => o.Option).GroupBy(o=>o.Value).ToList();
            if (groupedOptions == null)
                throw new ArgumentNullException(nameof(groupedOptions), "Options grouping error");
            var optionsStatistics = new Dictionary<string, int>();
            foreach (var option in groupedOptions)
            {
                optionsStatistics.Add(option.Key, option.Count());
            }

            var statistics = new StatisticDTO
            {
                Devices = experiments.Count,
                Experiments = experiments,
                ValueDistribution = optionsStatistics
            };
            return statistics;
        }
    }
}
