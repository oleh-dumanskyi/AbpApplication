using AbpApp.Application.DTOs;
using AbpApp.Application.Interfaces;
using AbpApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AbpApp.WebAPI.Controllers
{
    [ApiController]
    [Route("")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ExperimentController : ControllerBase
    {
        private readonly IExperimentService _experimentService;

        public ExperimentController(IExperimentService experimentService)
        {
            _experimentService = experimentService;
        }

        /// <summary>
        /// Get button color experiment data for provided device token.
        /// </summary>
        /// <param name="deviceToken">User device token</param>
        /// <param name="cancellationToken">Token to notify asynchronous operation cancellation</param>
        /// <returns>Returns experiment key and value.</returns>
        /// <response code="200">Successful execution. Returns experiment data.</response>
        /// <response code="400">Bad request. Provided data is invalid. Returns error message.</response>
        /// <response code="404">Not found. Requested experiment or related data was not found. Returns error message.</response>
        [HttpGet("[controller]/button-color/")]
        [ProducesResponseType(typeof(ExperimentResponseDTO), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> GetColorExperiment([FromQuery(Name = "device-token")] string deviceToken, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _experimentService.GetExperiment(deviceToken, Key.button_color, cancellationToken));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get price experiment data for provided device token.
        /// </summary>
        /// <param name="deviceToken">User device token</param>
        /// <param name="cancellationToken">Token to notify asynchronous operation cancellation</param>
        /// <returns>Returns experiment key and value strings.</returns>
        /// <response code="200">Successful execution. Returns experiment data.</response>
        /// <response code="400">Bad request. Provided data is invalid. Returns error message.</response>
        /// <response code="404">Not found. Requested experiment or related data was not found. Returns error message.</response>
        [HttpGet("[controller]/price/")]
        [ProducesResponseType(typeof(ExperimentResponseDTO), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> GetPriceExperiment([FromQuery(Name = "device-token")] string deviceToken, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _experimentService.GetExperiment(deviceToken, Key.price, cancellationToken));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get price experiment statistics with grouping by option values.
        /// </summary>
        /// <param name="cancellationToken">Token to notify asynchronous operation cancellation</param>
        /// <returns>Returns JSON-formatted data.</returns>
        /// <response code="200">Successful execution. Returns experiment data.</response>
        /// <response code="404">Not found. Requested statistics data was not found. Returns error message.</response>
        [HttpGet("[controller]/[action]")]
        [ProducesResponseType(typeof(StatisticDTO), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> GetPriceStatistics(CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _experimentService.GetStatistics(Key.price, cancellationToken));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// Get button color experiment statistics with grouping by option values.
        /// </summary>
        /// <param name="cancellationToken">Token to notify asynchronous operation cancellation</param>
        /// <returns>Returns JSON-formatted data.</returns>
        /// <response code="200">Successful execution. Returns experiment data.</response>
        /// <response code="404">Not found. Requested statistics data was not found. Returns error message.</response>
        [HttpGet("[controller]/[action]")]
        [ProducesResponseType(typeof(StatisticDTO), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> GetColorStatistics(CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _experimentService.GetStatistics(Key.button_color, cancellationToken));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
