using System.Threading.Tasks;
using PayPal.v1.Payments;

namespace EasyShop.Interfaces.Payments.RustPaymentServices
{
    public interface IRustPaymentService
    {
        Task<Payment> CreatePaymentAsync(decimal amountToPay);

        Task<Payment> ExecutePaymentAsync(string paymentId, string token, string PayerID);
    }
}
