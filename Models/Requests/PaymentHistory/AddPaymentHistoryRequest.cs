namespace App.Models.Requests;
public class AddPaymentHistoryRequest
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
    public DateTime CreateDatetime { get; set; }
    public DateTime UpdateDatetime { get; set; }
}