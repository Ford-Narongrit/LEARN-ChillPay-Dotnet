using App.Data;
using App.Helpers;
using App.Models;
using App.Models.Dtos;
using AutoMapper;

namespace App.Services;
public interface IPaymentHistoryServices
{
    OperationResult<List<GetPaymentHistoryDto>> GetAll();
}

public class PaymentHistoryServices : IPaymentHistoryServices
{
    private readonly ApplicationDBContext _dbContext;
    private readonly IMapper _mapper;

    public PaymentHistoryServices(
        ApplicationDBContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public OperationResult<List<GetPaymentHistoryDto>> GetAll()
    {
        try
        {
            var result = _dbContext.PaymentHistories
                .OrderByDescending(x => x.CreateDatetime)
                .ToList();
            var resultDto = _mapper.Map<List<PaymentHistory>, List<GetPaymentHistoryDto>>(result);

            return OperationResult<List<GetPaymentHistoryDto>>.SuccessResult(resultDto);
        }
        catch (Exception ex)
        {
            return OperationResult<List<GetPaymentHistoryDto>>.FailureResult(ex.Message);
        }
    }
}