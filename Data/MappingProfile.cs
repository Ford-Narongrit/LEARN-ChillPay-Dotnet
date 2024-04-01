using App.Models;
using App.Models.Dtos;
using AutoMapper;

namespace App.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PaymentHistory, GetPaymentHistoryDto>();
        }
    }
}