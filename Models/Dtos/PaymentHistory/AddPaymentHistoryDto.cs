namespace App.Models.Dtos;
public class AddPaymentHistoryDto
{
    public required string OrderId { get; set; }
    public float PaidPoint { get; set; }
    public float Amount { get; set; }
    public decimal PointConversionValue { get; set; }
    public decimal CurrencyConversionValue { get; set; }
    public decimal? ChillpayTransactionId { get; set; }
    public string? PaymentMethod { get; set; }
    public string? PaymentStatus { get; set; }
    public DateTime? ChillpayExpiredDatetime { get; set; }
}