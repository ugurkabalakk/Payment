using System.Threading.Tasks;
using Domain.Entities.Payment;
using Infrastructure.Persistence.DB;
using Infrastructure.Persistence.Repository;
using MongoDB.Bson;

namespace Domain.Repositories
{
    public class PaymentRepository : Repository<PaymentEntity>, IPaymentRepository
    {
        public PaymentRepository(IDatabase database, string collectionName = "payments") : base(
            database, collectionName)
        {
        }

        public async Task InsertPayment(PaymentEntity entity)
        {
            await InsertAsync(entity);
        }

        public async Task<PaymentEntity> GetPayment(string paymentId)
        {
            return await FindOneAsync(t => t.Id == new ObjectId(paymentId));
        }
    }
}