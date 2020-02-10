using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.RustStore.Payment;
using PayPal.v1.Payments;

namespace EasyShop.Interfaces.Payments.RustPaymentServices
{
    public interface IRustPaymentService
    {
        Task<Payment> CreatePaymentAsync(RustStoreTopUpBalanceViewModel model);

        Task<Payment> ExecutePaymentAsync(string paymentId, string token, string PayerID);
    }
}
