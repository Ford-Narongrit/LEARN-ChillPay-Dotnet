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
        _paymentHistoryServices = paymentHistoryServices;

    }

    [HttpPost, Route("Payment")]
    public async Task<IActionResult> Payment(ChillpayRequest request)
    {
        try
        {
            var result = await _chillpayService.Payment(request);
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
                        ChillpayExpiredDatetime = DateTime.Now,
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
            if (request.Status == "SUCCESS")
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