namespace App.Models.Dtos;
public class ChillpayResponseDto
{
    public required int Status { get; set; }
    public required int Code { get; set; }
    public required string Message { get; set; }
    public required int Amount { get; set; }
    public required string OrderNo { get; set; }
    public required string CustomerId { get; set; }
    public string? ReturnUrl { get; set; }
    public string? PaymentUrl { get; set; }
    public string? IpAddress { get; set; }
    public required string Token { get; set; }
    public required int TransactionId { get; set; }
    public required string ChannelCode { get; set; }
    public required string CreatedDate { get; set; }
    public required string ExpiredDate { get; set; }
}