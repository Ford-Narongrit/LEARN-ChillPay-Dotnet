using App.Helpers;
using App.Models;
using App.Models.Dtos;
using App.Models.Enums;
using App.Models.Requests;
using AutoMapper;

namespace App.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // PaymentHistory
            CreateMap<PaymentHistory, GetPaymentHistoryDto>();
            CreateMap<AddPaymentHistoryDto, PaymentHistory>();
            CreateMap<AddPaymentHistoryRequest, AddPaymentHistoryDto>()
                .ForMember(dest => dest.PaymentMethod, opt =>
                {
                    EPaymentMethod paymentMethod;
                    opt.MapFrom(src => Enum.TryParse(src.PaymentMethod, out paymentMethod) ? paymentMethod : 0); // 0 mean invalid
                });

            // Chillpay
            CreateMap<ChillpayRequest, ChillpayPostBodyRequest>();

            // PaymentHistory -> Chillpay
            CreateMap<AddPaymentHistoryRequest, ChillpayRequest>()
                .ForMember(dest => dest.OrderNo, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => NumberConverter.ConvertFloatToInt(src.Amount)))
                .ForMember(dest => dest.ChannelCode, opt =>
                {
                    EPaymentMethod paymentMethod;
                    opt.MapFrom(src => Enum.TryParse(src.PaymentMethod, out paymentMethod) ? EnumMapper.MapPaymentMethod(paymentMethod) : 0); // 0 mean invalid
                })
                .ForMember(dest => dest.Currency, opt =>
                {
                    ECurrencyCode currency;
                    opt.MapFrom(src => Enum.TryParse(src.Currency.ToString(), out currency) ? currency : 0); // 0 mean invalid
                });
        }
    }
}