namespace App.Models.Requests;

public class ChillpayPostBodyDto
{
    public required string MerchantCode { get; set; }
    public required string OrderNo { get; set; }
    public required string CustomerId { get; set; }
    public required int Amount { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Description { get; set; }
    public required string ChannelCode { get; set; }
    public required int Currency { get; set; }
    public string? LangCode { get; set; }
    public required string RouteNo { get; set; }
    public required string IPAddress { get; set; }
    public required string ApiKey { get; set; }
    public string? TokenFlag { get; set; }
    public string? CreditToken { get; set; }
    public string? CreditMonth { get; set; }
    public string? ShopId { get; set; }
    public string? ProductImageUrl { get; set; }
    public string? CustEmail { get; set; }
    public string? CardType { get; set; }
    public required string CheckSum { get; set; }

    public string GetCheckSum(string MD5Secret)
    {
        
        return "";
    }
}