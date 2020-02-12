using System.Threading.Tasks;
using PayPal.v1.Payments;

namespace EasyShop.Interfaces.Payments.RustPaymentServices.PayPal
{
    public interface IPayPalExecutedPaymentService
    {
        Task CreateAsync(Payment paymentExecutionResult);
    }
}