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
            CreateMap<AddPaymentHistoryRequest, PaymentHistory>();

            // Chillpay
            CreateMap<ChillpayRequest, ChillpayPostBodyRequest>();
        }
    }
}