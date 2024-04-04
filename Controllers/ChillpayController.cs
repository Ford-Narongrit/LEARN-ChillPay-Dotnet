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

    [HttpPost, Route("CheckPaymentStatus/{transactionId}")]
    public async Task<IActionResult> CheckPaymentStatus(int transactionId)
    {
        try
        {
            var result = await _chillpayService.PaymentStatus(transactionId);
            if (result.Success)
            {
                //TODO save payment status
                return Ok(result.Result);
            }

            return BadRequest(result.ErrorMessage);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred: " + ex.Message);
        }
    }

    [HttpPost, Route("CallBack/Result")]
    public IActionResult CallBackResult([FromForm] ChillpayCallBackResultRequest request)
    {
        try
        {
            Console.WriteLine("CallBack/Result");
            if (request.RespCode == (int)EChillpayPaymentStatus.SUCCESS)
            {
                var paymentHistory = _paymentHistoryServices.ChangeStatusToSuccess(request.OrderNo);
            }
            else
            {
                var paymentHistory = _paymentHistoryServices.ChangeStatusToFail(request.OrderNo);
            }

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
            Console.WriteLine("CallBack/Background");
            if (request.PaymentStatus == (int)EChillpayPaymentStatus.SUCCESS)
            {
                var paymentHistory = _paymentHistoryServices.ChangeStatusToSuccess(request.OrderNo!);
            }
            else
            {
                var paymentHistory = _paymentHistoryServices.ChangeStatusToFail(request.OrderNo!);
            }
            return Ok(request);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred: " + ex.Message);
        }
    }
}