using System.Security.Cryptography;
using System.Text;

namespace App.Models.Requests;

public class ChillpayStatusPostBodyRequest
{
    public string MerchantCode { get; set; }
    public int TransactionId { get; set; }
    public string ApiKey { get; set; }
    public string CheckSum { get; set; }

    public string GetCheckSum(string MD5Secret)
    {
        try
        {
            string SumString = $"{MerchantCode}{TransactionId}{ApiKey}";
            byte[] hashBytes = MD5.HashData(Encoding.UTF8.GetBytes(SumString + MD5Secret));
            string CheckSum = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            return CheckSum;
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to generate CheckSum", ex);
        }
    }

    public ChillpayStatusPostBodyRequest(string merchantCode, int transactionId, string apiKey, string md5Secret)
    {
        MerchantCode = merchantCode;
        TransactionId = transactionId;
        ApiKey = apiKey;
        CheckSum = GetCheckSum(md5Secret);
    }
}