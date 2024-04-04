using App.Helpers;
using App.Models.Dtos;
using App.Models.Enums;
using App.Models.Requests;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;
[ApiController]
[Route("[Controller]")]
public class ChillpayController : ControllerBase
{

    private readonly IChillpayService _chillpayService;
    private readonly IPaymentHistoryServices _paymentHistoryServices;
    public ChillpayController(
        IChillpayService chillpayService,
        IPaymentHistoryServices paymentHistoryServices)
    {
        _chillpayService = chillpayService;
        _paymentHistoryServices = paymentHistoryServices;
    }

    [HttpPost, Route("CallBack/Result")]
    public IActionResult CallBackResult([FromForm] ChillpayCallBackResultRequest request)
    {
        try
        {
            return Ok(request);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred: " + ex.Message);
        }
    }

    [HttpPost, Route("CallBack/Background")]
    public IActionResult CallBackBackground([FromForm] ChillpayCallBackBackgroundRequest request)
    {
        try
        {
            return Ok(request);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred: " + ex.Message);
        }
    }

    
}