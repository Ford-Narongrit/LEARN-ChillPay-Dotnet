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

    [HttpPost, Route("Payment")]
    public async Task<IActionResult> Payment(ChillpayRequest request)
    {
        try
        {
            var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress?.ToString();
            if (string.IsNullOrEmpty(remoteIpAddress))
            {
                return BadRequest("Remote IP Address is empty");
            }

            var result = await _chillpayService.Payment(request, remoteIpAddress);
            if (result.Success)
            {
                var response = result.Result!;
                var newPayment = _paymentHistoryServices.Add(
                    new AddPaymentHistoryRequest
                    {
                        OrderId = response.OrderNo,
                        Amount = response.Amount,
                        PaidPoint = response.Amount,
                        PointConversionValue = 1,
                        CurrencyConversionValue = 1,
                        PaymentMethod = "QRCODE",
                        PaymentStatus = "PENDING",
                        ChillpayTransactionId = response.TransactionId,
                        ChillpayExpiredDatetime = DateTimeHelper.ParseDateTime(response.ExpiredDate),
                    }
                );
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
    public IActionResult CallBack([FromForm] ChillpayCallBackResultRequest request)
    {
        try
        {
            if (request.RespCode == 0) // success
            {
                var result = _paymentHistoryServices.ChangeStatusToSuccess(request.OrderNo);
                if (result.Success)
                {
                    return Ok(result.Result);
                }
                else
                {
                    return BadRequest(result.ErrorMessage);
                }
            }
            else
            {
                var result = _paymentHistoryServices.ChangeStatusToFail(request.OrderNo);
                if (result.Success)
                {
                    return Ok(result.Result);
                }
                else
                {
                    return BadRequest(result.ErrorMessage);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred: " + ex.Message);
        }
    }
}