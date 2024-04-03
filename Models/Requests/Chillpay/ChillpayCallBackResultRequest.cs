namespace App.Models.Requests;

public class ChillpayCallBackResultRequest
{
    public required string OrderNo { get; set; }
    public required string Status { get; set; }
    public int? RespCode { get; set; }
    public int? TransNo { get; set; }
}