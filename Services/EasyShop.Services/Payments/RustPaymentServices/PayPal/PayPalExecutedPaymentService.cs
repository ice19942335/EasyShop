using EasyShop.DAL.Context;
using EasyShop.Interfaces.Payments.RustPaymentServices.PayPal;

namespace EasyShop.Services.Payments.RustPaymentServices.PayPal
{
    public class PayPalExecutedPaymentService : IPayPalExecutedPaymentService
    {
        private readonly EasyShopContext _easyShopContext;

        public PayPalExecutedPaymentService(EasyShopContext easyShopContext)
        {
            _easyShopContext = easyShopContext;
        }


    }
}