namespace App.Models.Dtos;
public class ChillpayStatusResponseDto
{

    public required int TransactionId { get; set; }
    public required int Amount { get; set; }
    public required string OrderNo { get; set; }
    public required string CustomerId { get; set; }
    public required string BackCode { get; set; }
    public required string PaymentDate { get; set; }
    public required int PaymentStatus { get; set; }
    public required string BankRefCode { get; set; }
    public required string CurrentDate { get; set; }
    public required string CurrentTime { get; set; }
    public required string PaymentDescription { get; set; }
    public required string CreditCardToken { get; set; }
    public required int Currency { get; set; }
    public required string CustomerName { get; set; }
    public required string CheckSum { get; set; }
}