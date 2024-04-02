using App.Helpers;
using App.Models.Dtos;
using App.Models.Requests;
using AutoMapper;

namespace App.Services;

public interface IChillpayService
{
    Task<OperationResult<ChillpayResponseDto>> Payment(ChillpayRequest request);
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

    public async Task<OperationResult<ChillpayResponseDto>> Payment(ChillpayRequest request)
    {
        // Call Chillpay API
        string baseUrl = "https://sandbox-appsrv2.chillpay.co/api/v2/Payment/";
        string merchantCode = _configuration["ChillpaySettings:MerchantCode"]!;
        string apiKey = _configuration["ChillpaySettings:ApiKey"]!;
        string MD5Secret = _configuration["ChillpaySettings:MD5Secret"]!;

        var chillpayBody = _mapper.Map<ChillpayRequest, ChillpayPostBodyDto>(request);
        chillpayBody.MerchantCode = merchantCode;
        chillpayBody.ApiKey = apiKey;
        chillpayBody.CheckSum = chillpayBody.GetCheckSum(MD5Secret);

        HttpResponseMessage responseMessage = await _httpClient.CreateClient().PostAsJsonAsync(baseUrl, request);
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