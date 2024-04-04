using App.Models.Enums;

public class EnumMapper
{
    private static readonly Dictionary<EPaymentMethod, EChillpayPaymentMethod> paymentMethodMap =
        new Dictionary<EPaymentMethod, EChillpayPaymentMethod>
        {
            { EPaymentMethod.QRCODE, EChillpayPaymentMethod.bank_qrcode },
            { EPaymentMethod.CREDIT_CARD, EChillpayPaymentMethod.creditcard }
        };

    public static EChillpayPaymentMethod MapPaymentMethod(EPaymentMethod paymentMethod)
    {
        return paymentMethodMap.GetValueOrDefault(paymentMethod);
    }
}