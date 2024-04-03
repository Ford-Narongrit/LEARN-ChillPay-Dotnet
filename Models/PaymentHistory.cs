using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Models.Enums;

namespace App.Models;

[Table("trn_payment_history")]
public class PaymentHistory
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required string OrderId { get; set; }
    [Required]
    public float PaidPoint { get; set; }
    [Required]
    public float Amount { get; set; }
    [Required]
    public decimal PointConversionValue { get; set; }
    [Required]
    public decimal CurrencyConversionValue { get; set; }
    public decimal? ChillpayTransactionId { get; set; }
    public EPaymentMethod PaymentMethod { get; set; }
    public EPaymentStatus PaymentStatus { get; set; }
    public DateTime? ChillpayExpiredDatetime { get; set; }
    [Required]
    public DateTime CreateDatetime { get; set; }
    [Required]
    public DateTime UpdateDatetime { get; set; }

    public PaymentHistory()
    {
        CreateDatetime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));
        UpdateDatetime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));
    }
}