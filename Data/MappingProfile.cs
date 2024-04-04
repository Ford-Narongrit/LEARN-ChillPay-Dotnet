using App.Helpers;
using App.Models;
using App.Models.Dtos;
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
            CreateMap<AddPaymentHistoryRequest, AddPaymentHistoryDto>();

            // Chillpay
            CreateMap<ChillpayRequest, ChillpayPostBodyRequest>();

            // PaymentHistory -> Chillpay
            CreateMap<AddPaymentHistoryRequest, ChillpayRequest>()
                .ForMember(dest => dest.OrderNo, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => NumberConverter.ConvertFloatToInt(src.Amount)));
        }
    }
}