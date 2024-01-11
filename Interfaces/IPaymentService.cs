using PositronAPI.Models.Payment;

namespace PositronAPI.Interfaces;

public interface IPaymentService
{
    Task<PaymentModelDTO> CreatePayment(PaymentImportDTO paymentImportDto);
}