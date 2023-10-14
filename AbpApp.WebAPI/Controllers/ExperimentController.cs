using AbpApp.Application.Interfaces;
using AbpApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AbpApp.WebAPI.Controllers
{
    [ApiController]
    [Route("")]
    public class ExperimentController : ControllerBase
    {
        private readonly IAppDbContext _context;
        private readonly IExperimentService _experimentService;

        public ExperimentController(IAppDbContext context, IExperimentService experimentService)
        {
            _context = context;
            _experimentService = experimentService;
        }

        [HttpGet("[controller]/button-color/")]
        public async Task<IActionResult> GetColorExperiment([FromQuery(Name = "device-token")] string deviceToken, CancellationToken cancellationToken)
        {
            try
            {
                
                var result = await _experimentService.GetExperiment(deviceToken, Key.button_color, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[controller]/price/")]
        public async Task<IActionResult> GetPriceExperiment([FromQuery(Name = "device-token")] string deviceToken, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _experimentService.GetExperiment(deviceToken, Key.price, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> GetPriceStatistics(CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _experimentService.GetStatistics(Key.price, cancellationToken));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> GetColorStatistics(CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _experimentService.GetStatistics(Key.button_color, cancellationToken));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
