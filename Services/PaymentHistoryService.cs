using App.Data;
using App.Helpers;
using App.Models;
using App.Models.Dtos;
using App.Models.Enums;
using App.Models.Requests;
using AutoMapper;

namespace App.Services;
public interface IPaymentHistoryServices
{
    OperationResult<List<GetPaymentHistoryDto>> GetAll();
    OperationResult<GetPaymentHistoryDto> GetById(int paymentHistoryId);
    OperationResult<GetPaymentHistoryDto> GetByOrderId(string OrderNo);
    OperationResult<GetPaymentHistoryDto> Create(AddPaymentHistoryDto request);
    OperationResult<GetPaymentHistoryDto> ChangeStatusToSuccess(string orderNo);
    OperationResult<GetPaymentHistoryDto> ChangeStatusToFail(string orderNo);
    OperationResult<string> Delete(int paymentHistoryId);
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

    public OperationResult<GetPaymentHistoryDto> GetById(int paymentHistoryId)
    {
        try
        {
            var result = _dbContext.PaymentHistories.FirstOrDefault(x => x.Id == paymentHistoryId);
            if (result == null)
            {
                return OperationResult<GetPaymentHistoryDto>.FailureResult("Payment history not found", StatusCodes.Status404NotFound);
            }
            var resultDto = _mapper.Map<PaymentHistory, GetPaymentHistoryDto>(result);

            return OperationResult<GetPaymentHistoryDto>.SuccessResult(resultDto);
        }
        catch (Exception ex)
        {
            return OperationResult<GetPaymentHistoryDto>.FailureResult(ex.Message);
        }
    }

    public OperationResult<GetPaymentHistoryDto> GetByOrderId(string OrderNo)
    {
        try
        {
            var result = _dbContext.PaymentHistories.FirstOrDefault(x => x.OrderId == OrderNo);
            if (result == null)
            {
                return OperationResult<GetPaymentHistoryDto>.FailureResult("Payment history not found", StatusCodes.Status404NotFound);
            }
            var resultDto = _mapper.Map<PaymentHistory, GetPaymentHistoryDto>(result);
            return OperationResult<GetPaymentHistoryDto>.SuccessResult(resultDto);
        }
        catch (Exception ex)
        {
            return OperationResult<GetPaymentHistoryDto>.FailureResult(ex.Message);
        }
    }

    public OperationResult<GetPaymentHistoryDto> Create(AddPaymentHistoryDto request)
    {
        try
        {
            var paymentHistory = _mapper.Map<AddPaymentHistoryDto, PaymentHistory>(request);
            paymentHistory.CreateDatetime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));
            paymentHistory.UpdateDatetime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));

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

    public OperationResult<GetPaymentHistoryDto> ChangeStatusToSuccess(string orderNo)
    {
        try
        {
            var paymentHistory = _dbContext.PaymentHistories.FirstOrDefault(x => x.OrderId == orderNo);
            if (paymentHistory == null)
            {
                return OperationResult<GetPaymentHistoryDto>.FailureResult("Payment history not found");
            }

            paymentHistory.PaymentStatus = EPaymentStatus.SUCCESS;
            paymentHistory.UpdateDatetime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));

            _dbContext.SaveChanges();

            var resultDto = _mapper.Map<PaymentHistory, GetPaymentHistoryDto>(paymentHistory);
            return OperationResult<GetPaymentHistoryDto>.SuccessResult(resultDto);
        }
        catch (Exception ex)
        {
            return OperationResult<GetPaymentHistoryDto>.FailureResult(ex.Message);
        }
    }

    public OperationResult<GetPaymentHistoryDto> ChangeStatusToFail(string orderNo)
    {
        try
        {
            var paymentHistory = _dbContext.PaymentHistories.FirstOrDefault(x => x.OrderId == orderNo);
            if (paymentHistory == null)
            {
                return OperationResult<GetPaymentHistoryDto>.FailureResult("Payment history not found");
            }

            paymentHistory.PaymentStatus = EPaymentStatus.FAILED;
            paymentHistory.UpdateDatetime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));

            _dbContext.SaveChanges();

            var resultDto = _mapper.Map<PaymentHistory, GetPaymentHistoryDto>(paymentHistory);
            return OperationResult<GetPaymentHistoryDto>.SuccessResult(resultDto);
        }
        catch (Exception ex)
        {
            return OperationResult<GetPaymentHistoryDto>.FailureResult(ex.Message);
        }
    }

    public OperationResult<string> Delete(int paymentHistoryId)
    {
        try
        {
            var paymentHistory = _dbContext.PaymentHistories.FirstOrDefault(x => x.Id == paymentHistoryId);
            if (paymentHistory == null)
            {
                return OperationResult<string>.FailureResult("Payment history not found", StatusCodes.Status404NotFound);
            }

            _dbContext.PaymentHistories.Remove(paymentHistory);
            _dbContext.SaveChanges();

            return OperationResult<string>.SuccessResult("Payment history deleted");
        }
        catch (Exception ex)
        {
            return OperationResult<string>.FailureResult(ex.Message);
        }
    }
}