using App.Models.Dtos;
using App.Models.Requests;
using App.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;
[ApiController]
[Route("[Controller]")]
public class PaymentHistoryController : ControllerBase
{
    private readonly IPaymentHistoryServices _paymentHistoryServices;
    private readonly IMapper _mapperService;
    private readonly IChillpayService _chillPayServices;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public PaymentHistoryController(
        IMapper mapperService,
        IPaymentHistoryServices paymentHistoryServices,
        IChillpayService chillPayServices,
        IHttpContextAccessor httpContextAccessor)
    {
        _chillPayServices = chillPayServices;
        _httpContextAccessor = httpContextAccessor;
        _paymentHistoryServices = paymentHistoryServices;
        _mapperService = mapperService;
    }
    [HttpGet, Route("GetPaymentHistories")]
    public IActionResult GetPaymentHistories()
    {
        try
        {
            var result = _paymentHistoryServices.GetAll();
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

    [HttpGet, Route("GetPaymentHistoryById/{id}")]
    public IActionResult GetPaymentHistoryById(int id)
    {
        try
        {
            var result = _paymentHistoryServices.GetById(id);
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

    [HttpPost, Route("CreatePaymentHistory")]
    public async Task<IActionResult> CreatePaymentHistory(AddPaymentHistoryRequest request)
    {
        try
        {
            var remoteIpAddress = _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();
            if (string.IsNullOrEmpty(remoteIpAddress))
            {
                return BadRequest("Remote IP Address is empty");
            }

            var newPaymentHistory = _mapperService.Map<AddPaymentHistoryRequest, AddPaymentHistoryDto>(request);
            var paymentResult = _paymentHistoryServices.Create(newPaymentHistory);

            if (!paymentResult.Success)
            {
                return BadRequest(paymentResult.ErrorMessage);
            }

            var newChillpayRequest = _mapperService.Map<AddPaymentHistoryRequest, ChillpayRequest>(request);
            var ChillpayResult = await _chillPayServices.Payment(newChillpayRequest, remoteIpAddress);
            if (ChillpayResult.Success)
            {
                return Ok(ChillpayResult.Result);
            }
            else
            {
                return BadRequest(ChillpayResult.ErrorMessage);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred: " + ex.Message);
        }
    }

    [HttpDelete, Route("DeletePaymentHistory/{id}")]
    public IActionResult DeletePaymentHistory(int id)
    {
        try
        {
            var result = _paymentHistoryServices.Delete(id);
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
}