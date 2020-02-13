using System.Threading.Tasks;
using EasyShop.Domain.Dto.PayPal;
using EasyShop.Domain.ViewModels.RustStore.Payment;
using PayPal.v1.Payments;

namespace EasyShop.Interfaces.Payments.RustPaymentServices.PayPal
{
    public interface IRustStorePaymentService
    {
        Task<Payment> CreatePayPalPaymentAsync(string amountToPay);

        Task<PaymentExecuteResultDto> ExecutePayPalPaymentAsync(string paymentId, string token, string payerId);
    }
}
