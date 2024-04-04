using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;
[ApiController]
[Route("[Controller]")]
public class IpAddressController : ControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public IpAddressController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var remoteIpAddress = _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();
        if (string.IsNullOrEmpty(remoteIpAddress))
        {
            return BadRequest("Remote IP Address is empty");
        }
        return Ok(remoteIpAddress);
    }
}