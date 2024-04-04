namespace App.Models.Requests;
public class AddPaymentHistoryRequest
{
    // PaymentHistory
    public required string OrderId { get; set; }
    public float PaidPoint { get; set; }
    public float Amount { get; set; }
    public decimal PointConversionValue { get; set; }
    public decimal CurrencyConversionValue { get; set; }
    public string? PaymentMethod { get; set; }

    // Chillpay
    public required string CustomerId { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Description { get; set; }
    public required string ChannelCode { get; set; }
    public required int Currency { get; set; }
    public string? LangCode { get; set; }
    public required int RouteNo { get; set; }
    public string? TokenFlag { get; set; }
    public string? CreditToken { get; set; }
    public string? CreditMonth { get; set; }
    public string? ShopId { get; set; }
    public string? ProductImageUrl { get; set; }
    public string? CustEmail { get; set; }
    public string? CardType { get; set; }
}