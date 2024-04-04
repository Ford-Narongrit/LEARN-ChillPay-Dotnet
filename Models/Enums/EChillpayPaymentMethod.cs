namespace App.Models.Enums
{
    public enum EChillpayPaymentMethod
    {
        internetbank_bay = 0, //ช่องทางชำระเงินผ่าน ธนาคารกรุงศรี (BAY)
        internetbank_bbl = 1, //ช่องทางชำระเงินผ่าน ธนาคารกรุงเทพ (BBL)
        internetbank_scb = 2, //ช่องทางชำระเงินผ่าน ธนาคารไทยพาณิชย์ (SCB)
        internetbank_ktb = 3, //ช่องทางชำระเงินผ่าน ธนาคารกรุงไทย (KTB)
        internetbank_ttb = 4, //ช่องทางชำระเงินผ่าน ธนาคารทหารไทยธนชาต (TTB)
        payplus_kbank = 5, //ช่องทางชำระเงินผ่าน K-PLUS (Mobile Banking ของ ธ.กสิกรไทย)
        mobilebank_scb = 6, //ช่องทางชำระเงินผ่าน SCB Easy App (Mobile Banking ของ ธ.ไทยพาณิชย์)
        mobilebank_bay = 7, //ช่องทางชำระเงินผ่าน KMA App (Mobile Banking ของ ธ.กรุงศรี)
        mobilebank_bbl = 8, //ช่องทางชำระเงินผ่าน Bualuang mBanking (Mobile Banking ของ ธ.กรุงเทพ)
        mobilebank_ktb = 9, //ช่องทางชำระเงินผ่าน Krungthai NEXT (Mobile Banking ของ ธ.กรุงไทย)
        creditcard = 10, //ช่องทางชำระเงินผ่าน บัตรเครดิต Visa, Master Card, JCB, CUP(China Union Pay)
        epayment_alipay = 11, //ช่องทางชำระเงินผ่าน Alipay
        epayment_wechatpay = 12, //ช่องทางชำระเงินผ่าน WeChat Pay
        epayment_linepay = 13, //ช่องทางชำระเงินผ่าน Rabbit LINE Pay
        epayment_truemoney = 14, //ช่องทางชำระเงินผ่านทรูมันนี่ วอลเล็ท
        epayment_shopeepay = 15, //ช่องทางชำระเงินผ่าน ShopeePay 
        bank_qrcode = 16, //ช่องทางชำระเงินผ่าน QR Code Payment
        billpayment_cenpay = 17, //ช่องทางชำระเงินผ่าน Bill Payment (CenPay)
        billpayment_counter = 18, //ช่องทางชำระเงินผ่าน Counter Bill Payment
        installment_kbank = 19, //ช่องทางชำระเงินแบบผ่อนชำระผ่านธนาคารกสิกรไทย
        installment_ktc_flexi = 20, //ช่องทางชำระเงินแบบผ่อนชำระผ่าน KTC FLEXI
        installment_krungsri = 21, //ช่องทางชำระเงินแบบผ่อนชำระผ่าน Krungsri Consumer
        installment_firstchoice = 22, //ช่องทางชำระเงินแบบผ่อนชำระผ่าน First Choice
        installment_scb = 23, //ช่องทางชำระเงินแบบผ่อนชำระผ่านธนาคารไทยพาณิชย์
        billpayment_boonterm = 24, //ช่องทางชำระเงินผ่าน ตู้บุญเติม
        point_ktc_forever = 25, //ช่องทางชำระเงินแบบใช้คะแนนสะสมผ่าน KTC FOREVER
    }
}