using App.Data;
using App.Helpers;
using App.Models;
using App.Models.Dtos;
using App.Models.Requests;
using AutoMapper;

namespace App.Services;
public interface IPaymentHistoryServices
{
    OperationResult<List<GetPaymentHistoryDto>> GetAll();
    OperationResult<GetPaymentHistoryDto> Get(int paymentHistoryId);
    OperationResult<GetPaymentHistoryDto> Add(AddPaymentHistoryRequest request);
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

    public OperationResult<GetPaymentHistoryDto> Get(int paymentHistoryId)
    {
        try
        {
            var result = _dbContext.PaymentHistories.FirstOrDefault(x => x.Id == paymentHistoryId);
            if (result == null)
            {
                return OperationResult<GetPaymentHistoryDto>.FailureResult("Payment history not found");
            }
            var resultDto = _mapper.Map<PaymentHistory, GetPaymentHistoryDto>(result);

            return OperationResult<GetPaymentHistoryDto>.SuccessResult(resultDto);
        }
        catch (Exception ex)
        {
            return OperationResult<GetPaymentHistoryDto>.FailureResult(ex.Message);
        }
    }

    public OperationResult<GetPaymentHistoryDto> Add(AddPaymentHistoryRequest request)
    {
        try
        {
            var paymentHistory = _mapper.Map<AddPaymentHistoryRequest, PaymentHistory>(request);
            paymentHistory.CreateDatetime = DateTime.Now;
            paymentHistory.UpdateDatetime = DateTime.Now;

            _dbContext.PaymentHistories.Add(paymentHistory);
            _dbContext.SaveChanges();

            var resultDto = _mapper.Map<PaymentHistory, GetPaymentHistoryDto>(paymentHistory);

            return OperationResult<GetPaymentHistoryDto>.SuccessResult(resultDto);
        }
        catch (Exception ex)
        {
            return OperationResult<GetPaymentHistoryDto>.FailureResult(ex.Message);
        }
    }
}