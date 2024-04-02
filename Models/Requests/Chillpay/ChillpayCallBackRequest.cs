namespace App.Models.Requests;

public class ChillpayCallBackRequest
{
    public string? TransactionId { get; set; }
    public required int Amount { get; set; }
    public required string OrderNo { get; set; }
    public required string CustomerId { get; set; }
    public required string BankCode { get; set; }
    public required string PaymentDate { get; set; }
    public required int PaymentStatus { get; set; }
    public required string BankRefCode { get; set; }
    public required string CurrentDate { get; set; }
    public required string CurrentTime { get; set; }
    public required string PaymentDescription { get; set; }
    public required string CreditCardToken { get; set; }
    public required string Currency { get; set; }
    public required string CheckSum { get; set; }
}