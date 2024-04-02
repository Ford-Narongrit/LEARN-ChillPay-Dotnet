using App.Models.Requests;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;
[ApiController]
[Route("[Controller]")]
public class ChillpayController : ControllerBase
{

    private readonly IChillpayService _chillpayService;
    public ChillpayController(IChillpayService chillpayService)
    {
        _chillpayService = chillpayService;
    }

    [HttpPost, Route("Payment")]
    public async Task<IActionResult> Payment(ChillpayRequest request)
    {
        try
        {
            var result = await _chillpayService.Payment(request);
            if (result.Success)
            {
                return Ok(result.Result);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred: " + ex.Message);
        }
    }

    [HttpPost, Route("CallBack")]
    public IActionResult CallBack(ChillpayCallBackRequest request)
    {
        try
        {
            Console.WriteLine("CallBack Work!!!");
            return Ok("Success");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred: " + ex.Message);
        }
    }
}