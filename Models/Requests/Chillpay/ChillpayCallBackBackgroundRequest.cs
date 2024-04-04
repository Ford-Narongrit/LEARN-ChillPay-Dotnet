namespace App.Models.Requests;

public class ChillpayCallBackBackgroundRequest
{
    public int? TransactionId { get; set; }
    public decimal? Amount { get; set; }
    public string? OrderNo { get; set; }
    public string? CustomerId { get; set; }
    public string? BankCode { get; set; }
    public string? PaymentDate { get; set; }
    public int? PaymentStatus { get; set; }
    public string? BankRefCode { get; set; }
    public string? CurrentDate { get; set; }
    public string? CurrentTime { get; set; }
    public string? PaymentDescription { get; set; }
    public string? CreditCardToken { get; set; }
    public string? Currency { get; set; }
    public string? CustomerName { get; set; }
    public string? CheckSum { get; set; }
}