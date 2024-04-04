namespace App.Models.Enums
{
    public enum EChillpayPaymentMethod
    {
        invalid = 0, //ช่องทางชำระเงินไม่ถูกต้อง
        internetbank_bay = 1, //ช่องทางชำระเงินผ่าน ธนาคารกรุงศรี (BAY)
        internetbank_bbl = 2, //ช่องทางชำระเงินผ่าน ธนาคารกรุงเทพ (BBL)
        internetbank_scb = 3, //ช่องทางชำระเงินผ่าน ธนาคารไทยพาณิชย์ (SCB)
        internetbank_ktb = 4, //ช่องทางชำระเงินผ่าน ธนาคารกรุงไทย (KTB)
        internetbank_ttb = 5, //ช่องทางชำระเงินผ่าน ธนาคารทหารไทยธนชาต (TTB)
        payplus_kbank = 6, //ช่องทางชำระเงินผ่าน K-PLUS (Mobile Banking ของ ธ.กสิกรไทย)
        mobilebank_scb = 7, //ช่องทางชำระเงินผ่าน SCB Easy App (Mobile Banking ของ ธ.ไทยพาณิชย์)
        mobilebank_bay = 8, //ช่องทางชำระเงินผ่าน KMA App (Mobile Banking ของ ธ.กรุงศรี)
        mobilebank_bbl = 9, //ช่องทางชำระเงินผ่าน Bualuang mBanking (Mobile Banking ของ ธ.กรุงเทพ)
        mobilebank_ktb = 10, //ช่องทางชำระเงินผ่าน Krungthai NEXT (Mobile Banking ของ ธ.กรุงไทย)
        creditcard = 11, //ช่องทางชำระเงินผ่าน บัตรเครดิต Visa, Master Card, JCB, CUP(China Union Pay)
        epayment_alipay = 12, //ช่องทางชำระเงินผ่าน Alipay
        epayment_wechatpay = 13, //ช่องทางชำระเงินผ่าน WeChat Pay
        epayment_linepay = 14, //ช่องทางชำระเงินผ่าน Rabbit LINE Pay
        epayment_truemoney = 15, //ช่องทางชำระเงินผ่านทรูมันนี่ วอลเล็ท
        epayment_shopeepay = 16, //ช่องทางชำระเงินผ่าน ShopeePay 
        bank_qrcode = 17, //ช่องทางชำระเงินผ่าน QR Code Payment
        billpayment_cenpay = 18, //ช่องทางชำระเงินผ่าน Bill Payment (CenPay)
        billpayment_counter = 19, //ช่องทางชำระเงินผ่าน Counter Bill Payment
        installment_kbank = 20, //ช่องทางชำระเงินแบบผ่อนชำระผ่านธนาคารกสิกรไทย
        installment_ktc_flexi = 21, //ช่องทางชำระเงินแบบผ่อนชำระผ่าน KTC FLEXI
        installment_krungsri = 22, //ช่องทางชำระเงินแบบผ่อนชำระผ่าน Krungsri Consumer
        installment_firstchoice = 23, //ช่องทางชำระเงินแบบผ่อนชำระผ่าน First Choice
        installment_scb = 24, //ช่องทางชำระเงินแบบผ่อนชำระผ่านธนาคารไทยพาณิชย์
        billpayment_boonterm = 25, //ช่องทางชำระเงินผ่าน ตู้บุญเติม
        point_ktc_forever = 26, //ช่องทางชำระเงินแบบใช้คะแนนสะสมผ่าน KTC FOREVER
    }
}