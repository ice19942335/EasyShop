using System.Threading.Tasks;
using EasyShop.Domain.Dto.PayPal;

namespace EasyShop.Interfaces.Services.Payments.RustPaymentServices.PayPal
{
    public interface IRustStorePaymentService
    {
        Task<PayPalPaymentCreationResultDto> CreatePayPalPaymentAsync(string amountToPay);

        Task<PayPalPaymentExecuteResultDto> ExecutePayPalPaymentAsync(string paymentId, string token, string payerId);
    }
}
