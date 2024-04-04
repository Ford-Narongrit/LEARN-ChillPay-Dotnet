using App.Helpers;
using App.Models.Dtos;
using App.Models.Requests;
using AutoMapper;

namespace App.Services;

public interface IChillpayService
{
    Task<OperationResult<ChillpayResponseDto>> Payment(ChillpayRequest request, string remoteIpAddress);
}

public class ChillpayService : IChillpayService
{
    private readonly IHttpClientFactory _httpClient;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;


    public ChillpayService(
        IHttpClientFactory httpClient,
        IConfiguration configuration,
        IMapper mapper)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _mapper = mapper;
    }

    public async Task<OperationResult<ChillpayResponseDto>> Payment(ChillpayRequest request, string remoteIpAddress)
    {
        // pack payload
        var chillpayBody = _mapper.Map<ChillpayRequest, ChillpayPostBodyDto>(request);
        chillpayBody.IPAddress = remoteIpAddress;
        chillpayBody.MerchantCode = _configuration["ChillpaySettings:MerchantCode"]!;
        chillpayBody.ApiKey = _configuration["ChillpaySettings:ApiKey"]!;
        chillpayBody.CheckSum = chillpayBody.GetCheckSum(_configuration["ChillpaySettings:MD5SecretKey"]!);

        // call Chillpay API
        string baseUrl = "https://sandbox-appsrv2.chillpay.co/api/v2/Payment/";
        HttpResponseMessage responseMessage = await _httpClient.CreateClient().PostAsJsonAsync(baseUrl, chillpayBody);
        if (!responseMessage.IsSuccessStatusCode)
        {
            return OperationResult<ChillpayResponseDto>.FailureResult("Failed to call Chillpay API");
        }

        var responseData = await responseMessage.Content.ReadFromJsonAsync<ChillpayResponseDto>();
        if (responseData == null)
        {
            return OperationResult<ChillpayResponseDto>.FailureResult("Failed to read response from Chillpay API");
        }

        return OperationResult<ChillpayResponseDto>.SuccessResult(responseData);
    }
}