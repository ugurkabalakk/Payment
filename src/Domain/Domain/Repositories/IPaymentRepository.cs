using System.Threading.Tasks;
using Domain.Entities.Payment;

namespace Domain.Repositories
{
    public interface IPaymentRepository
    {
        Task InsertPayment(PaymentEntity entity);
        Task<PaymentEntity> GetPayment(string paymentId);
    }
}