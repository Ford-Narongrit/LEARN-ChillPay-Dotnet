using App.Models.Requests;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;
[ApiController]
[Route("[Controller]")]
public class PaymentHistoryController : ControllerBase
{
    private readonly IPaymentHistoryServices _paymentHistoryServices;
    public PaymentHistoryController(IPaymentHistoryServices paymentHistoryServices)
    {
        _paymentHistoryServices = paymentHistoryServices;
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
    public IActionResult CreatePaymentHistory(AddPaymentHistoryRequest request)
    {
        try
        {
            var result = _paymentHistoryServices.Create(request);
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